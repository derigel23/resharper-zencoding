using System.Windows.Forms;
using JetBrains.ActionManagement;
using JetBrains.Application;
using JetBrains.DocumentModel;
using JetBrains.IDE;
using JetBrains.TextControl;
using JetBrains.Threading;
using JetBrains.UI;
using JetBrains.UI.Interop;
using JetBrains.UI.PopupWindowManager;
using JetBrains.Util;

namespace JetBrains.ReSharper.PowerToys.ZenCoding
{
  [ActionHandler("PowerToys.ZenCodingWrap")]
  public class ZenCodingWrapAction : ZenCodingActionBase
  {
    public override bool Update(IDataContext context, ActionPresentation presentation, DelegateUpdate nextUpdate)
    {
      return context.CheckAllNotNull(IDE.DataConstants.DOCUMENT_SELECTION) &&
        base.Update(context, presentation, nextUpdate);
    }

    public override void Execute(IDataContext context, DelegateExecute nextExecute)
    {
      var solution = context.GetData(IDE.DataConstants.SOLUTION);
      Assertion.AssertNotNull(solution, "solution == null");
      var textControl = context.GetData(IDE.DataConstants.TEXT_CONTROL);
      Assertion.AssertNotNull(textControl, "textControl == null");
      
      var windowContext = context.GetData(UI.DataConstants.POPUP_WINDOW_CONTEXT);
      // Layouter
      // Achtung! You MUST either pass the layouter to CreatePopupWindow or dispose of it, don't let it drift off
      IPopupWindowContext ctxToUse;
      IPopupLayouter layouterToUse;

      if (windowContext != null)
      {
        var ctxTextControl = windowContext as TextControlPopupWindowContext;
        if (ctxTextControl != null)
        {
          layouterToUse = new DockingLayouter(new TextControlAnchoringRect(ctxTextControl.TextControl, ctxTextControl.TextControl.Caret.Offset()), Anchoring2D.AnchorLeftOrRightOnly);
          ctxToUse = ctxTextControl;
        }
        else
        {
          layouterToUse = windowContext.CreateLayouter();
          ctxToUse = windowContext;
        }
      }
      else
      {
        ctxToUse = PopupWindowContext.Empty;
        layouterToUse = ctxToUse.CreateLayouter();
      }

      var form = new ZenCodingWrapForm();
      var window = PopupWindowManager.CreatePopupWindow(form, layouterToUse, ctxToUse, HideFlags.Escape, true);
      window.Closed += (sender, args) => ReentrancyGuard.Current.ExecuteOrQueue("ZenCodingWrap", () =>
      {
        try
        {
          if (form.DialogResult == DialogResult.Cancel)
            return;
          var abbr = form.TextBox.Text.Trim();
          if (abbr.IsEmpty())
          {
            Win32Declarations.MessageBeep(MessageBeepType.Error);
            return;
          }
          using (ReadLockCookie.Create())
          using (CommandCookie.Create("ZenCodingWrap"))
          {
            using (var cookie = DocumentManager.GetInstance(solution).EnsureWritable(textControl.Document))
            {
              if (cookie.EnsureWritableResult != EnsureWritableResult.SUCCESS)
                return;

              var selection = textControl.Selection.DocRange;
              Assertion.Assert(selection.IsValid, "selection is not valid");

              int insertPoint;
              var expanded = GetEngine(solution).WrapWithAbbreviation(
                abbr, textControl.Selection.GetSelectionText(), GetDocTypeForFile(GetProjectFile(context)), out insertPoint);
              CheckAndIndent(solution, textControl, selection, expanded, insertPoint);
            }
          }
        }
        finally
        {
          window.Dispose();
          form.Dispose();
        }
      });
      window.ShowWindow();
    }
  }
}
