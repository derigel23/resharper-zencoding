using JetBrains.ActionManagement;
using JetBrains.IDE;
using JetBrains.TextControl;
using JetBrains.TextControl.Coords;
using JetBrains.Util;

namespace JetBrains.ReSharper.PowerToys.MenuItem
{
  [ActionHandler]
  internal class AddMenuItem_ShowCurrentLineNumberAction : IActionHandler
  {
    #region IActionHandler Members

    public void Execute(IDataContext context, DelegateExecute nextExecute)
    {
      ITextControl textControl = context.GetData(DataConstants.TEXT_CONTROL);
      if(textControl == null)
      {
        MessageBox.ShowError("Text control unavailable."); // Note: shouldn't actually get here due to Update() handling
        return;
      }

      // Fetch caret line number
      ITextControlPos caretOffset = textControl.Caret.Position.Value;
      var nTextControlLine = (int)caretOffset.ToTextControlLineColumn().Line;
      var nDocLine = (int)caretOffset.ToDocLineColumn().Line;

      // Note that we increment line number by one because "line number" in our API starts from zero
      string message;
      if(nTextControlLine == nDocLine)
        message = string.Format("Current line number is {0:N0}.", nTextControlLine + 1);
      else
        message = string.Format("Current text control line number is {0:N0}.\nCurrent document line number is {1:N0}.\n\nProbably, you have some hidden regions in the text editor. Hence the difference in line numbers.", nTextControlLine, nDocLine);
      MessageBox.ShowInfo(message, "AddMenuItem Sample Plugin");
    }

    public bool Update(IDataContext context, ActionPresentation presentation, DelegateUpdate nextUpdate)
    {
      // fetch focused text editor control
      ITextControl textControl = context.GetData(DataConstants.TEXT_CONTROL);

      // enable this action if we are in text editor, disable otherwise
      return textControl != null;
    }

    #endregion
  }
}