using System;
using System.Collections.Generic;
using System.IO;

using JetBrains.ActionManagement;
using JetBrains.DocumentModel;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Services.FormatSettings;
using JetBrains.TextControl;
using JetBrains.UI.Interop;
using JetBrains.Util;

namespace JetBrains.ReSharper.PowerToys.ZenCoding
{
  public abstract class ZenCodingActionBase : IActionHandler
  {
    static readonly IDictionary<ProjectFileType, DocType> ourFileTypes =
      new Dictionary<ProjectFileType, DocType>
      {
        { ProjectFileType.ASP, DocType.Html },
        { ProjectFileType.XML, DocType.Xsl },
      };

    static readonly IDictionary<string, DocType> ourFileTypesBasedOnExtension =
      new Dictionary<string, DocType>
      {
        { ".spark", DocType.Html },
        { ".css", DocType.Css },
      };

    static ZenCodingEngine ourEngine;

    protected static ZenCodingEngine Engine
    {
      get { return ourEngine ?? (ourEngine = new ZenCodingEngine()); }
    }

    public virtual bool Update(IDataContext context, ActionPresentation presentation, DelegateUpdate nextUpdate)
    {
      // Check that we have a solution
      if (!context.CheckAllNotNull(IDE.DataConstants.SOLUTION, IDE.DataConstants.TEXT_CONTROL))
      {
        return nextUpdate();
      }

      return IsSupportedFile(GetProjectFile(context)) || nextUpdate();
    }

    protected bool IsSupportedFile(IProjectFile file)
    {
      var fileExtension = Path.GetExtension(file.Name);

      return ourFileTypes.ContainsKey(file.LanguageType) ||
             (fileExtension != null && ourFileTypesBasedOnExtension.ContainsKey(fileExtension));
    }

    protected DocType GetDocTypeForFile(IProjectFile file)
    {
      if (!IsSupportedFile(file))
      {
        throw new NotSupportedException(String.Format("The file {0} is not supported", file.Name));
      }

      if (ourFileTypes.ContainsKey(file.LanguageType))
      {
        return ourFileTypes[file.LanguageType];
      }

      return ourFileTypesBasedOnExtension[Path.GetExtension(file.Name)];
    }

    protected static IProjectFile GetProjectFile(IDataContext context)
    {
      return DocumentManager.GetInstance(context.GetData(IDE.DataConstants.SOLUTION))
        .GetProjectFile(context.GetData(IDE.DataConstants.DOCUMENT));
    }

    public abstract void Execute(IDataContext context, DelegateExecute nextExecute);

    protected static void CheckAndIndent(ITextControl textControl, TextRange abbrRange, string expanded, int insertPoint)
    {
      if (expanded.IsEmpty())
      {
        Win32Declarations.MessageBeep(MessageBeepType.Error);
        return;
      }

      var indentSize = GlobalFormatSettingsHelper.GetService().GetSettingsForLanguage(PsiLanguageType.ANY).IndentSize;
      expanded = Engine.PadString(expanded, (int)textControl.Document.GetCoordsByOffset(abbrRange.StartOffset).Column / indentSize);
      textControl.Document.ReplaceText(abbrRange, expanded);
      if (insertPoint != -1)
      {
        textControl.Caret.MoveTo(abbrRange.StartOffset + insertPoint, CaretVisualPlacement.Generic);
      }
    }
  }
}
