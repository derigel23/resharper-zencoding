using JetBrains.ActionManagement;
using JetBrains.Application;
using JetBrains.DocumentModel;
using JetBrains.UI.Interop;
using JetBrains.Util;

namespace JetBrains.ReSharper.PowerToys.ZenCoding
{
  [ActionHandler("PowerToys.ZenCoding")]
  public class ZenCodingAction : ZenCodingActionBase
  {
    public override void Execute(IDataContext context, DelegateExecute nextExecute)
    {
      var solution = context.GetData(IDE.DataConstants.SOLUTION);
      Assertion.Assert(solution != null, "solution != null");
      var textControl = context.GetData(IDE.DataConstants.TEXT_CONTROL);
      Assertion.Assert(textControl != null, "textControl != null");

      using (CommandCookie.Create("ZenCoding"))
      {
        using (var cookie = DocumentManager.GetInstance(solution).EnsureWritable(textControl.Document))
        {
          if (cookie.EnsureWritableResult != EnsureWritableResult.SUCCESS)
            return;

          string abbr;
          TextRange abbrRange = textControl.Selection.DocRange;
          if (abbrRange.IsValid && !abbrRange.IsEmpty)
          {
            abbr = textControl.Document.GetText(abbrRange);
          }
          else
          {
            var coords = textControl.Caret.PositionValue.ToDocLineColumn();
            int start;
            abbr = Engine.FindAbbreviationInLine(textControl.Document.GetLineText(coords.Line), (int)coords.Column, out start);
            if (start == -1)
            {
              Win32Declarations.MessageBeep(MessageBeepType.Error);
              return;
            }
            abbrRange = TextRange
              .FromLength(textControl.Caret.PositionValue.ToDocOffset(), -abbr.Length)
              .Normalized();
          }

          int insertPoint;
          var expanded = Engine.ExpandAbbreviation(abbr, GetDocTypeForFile(GetProjectFile(context)), out insertPoint);
          CheckAndIndent(textControl, abbrRange, expanded, insertPoint);
        }
      }
    }
  }
}