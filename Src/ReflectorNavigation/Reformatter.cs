using System;
using System.IO;
using System.Text;

using JetBrains.Annotations;
using JetBrains.Application;
using JetBrains.DocumentModel.Impl;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CodeStyle;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.CSharp.CodeStyle;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Services;
using JetBrains.Util;

namespace JetBrains.ReSharper.PowerToys.ReflectorNavigation
{
  public class Reformatter
  {
    public static void ReformatFile([NotNull] IPsiModule context, [NotNull] FileSystemPath path, bool reorderMembers)
    {
      if (context == null)
        throw new ArgumentNullException("context");
      if (path == null)
        throw new ArgumentNullException("path");
      if (!path.ExistsFile)
        throw new ArgumentException("File doesn't exist: " + path.FullPath, "path");

      var solution = context.GetSolution();

      var elementFactory = CSharpElementFactory.GetInstance(context, false);

      Encoding encoding;
      string content = DocumentUtil.ReadTextFromFile(path, true, out encoding);

      ICSharpFile file = elementFactory.CreateFile(content);
      if (file == null)
        return;

      DeclaredElementBinder declaredElementBinder = DeclaredElementBinder.Get(CSharpLanguageService.CSHARP);
      if (declaredElementBinder == null)
        return;

      using (WriteLockCookie.Create())
      {
        declaredElementBinder.BindDeclarations(file, context);

        ICSharpCodeFormatter codeFormatter = CSharpFormatterHelper.FormatterInstance;
        CodeStyleSettings codeStyleSettings = SolutionCodeStyleSettings.GetInstance(solution).CodeStyleSettings;

        codeFormatter.FormatFile(file, codeStyleSettings, CodeFormatProfile.DEFAULT);

        if (reorderMembers)
          file.ReorderMembersRecursively(codeStyleSettings);

        using (var sw = new StreamWriter(path.FullPath, false, encoding))
          sw.Write(file.GetText());
      }
    }
  }
}