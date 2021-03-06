using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using JetBrains.Application;
using JetBrains.ComponentModel;
using JetBrains.ReSharper.PowerToys.ZenCoding.Options.Model.Handlers;
using JetBrains.Util;

namespace JetBrains.ReSharper.PowerToys.ZenCoding.Options.Model
{
  [ShellComponentInterface(ProgramConfigurations.VS_ADDIN)]
  [ShellComponentImplementation]
  public class Settings : IXmlExternalizableShellComponent
  {
    public static readonly Settings Default =
      new Settings
      {
        FileAssociations = new List<FileAssociation>
                           {
                             new FileAssociation
                             {
                               Pattern = @".*\.html?$",
                               PatternType = PatternType.Regex,
                               DocType = DocType.Html,
                               Enabled = true
                             },
                             new FileAssociation
                             {
                               Pattern = ".spark",
                               PatternType = PatternType.FileExtension,
                               DocType = DocType.Html,
                               Enabled = true
                             },
                             new FileAssociation
                             {
                               Pattern = ".css",
                               PatternType = PatternType.FileExtension,
                               DocType = DocType.Css,
                               Enabled = true
                             },
                             new FileAssociation
                             {
                               Pattern = @".*\.xslt?$",
                               PatternType = PatternType.Regex,
                               DocType = DocType.Xsl,
                               Enabled = true
                             }
                           }
      };

    private readonly IPatternHandler[] myHandlers;

    public Settings()
    {
      myHandlers = new IPatternHandler[] {new FileExtensionPatternHandler(), new RegexPatternHandler()};
    }

    public static Settings Instance
    {
      get { return Shell.Instance.GetComponent<Settings>(); }
    }

    public List<FileAssociation> FileAssociations { get; set; }

    #region IXmlExternalizableShellComponent Members

    void IComponent.Init() { }

    void IDisposable.Dispose() { }

    string IXmlExternalizableComponent.TagName
    {
      get { return "ZenCoding.Settings"; }
    }

    XmlExternalizationScope IXmlExternalizableComponent.Scope
    {
      get { return XmlExternalizationScope.UserSettings; }
    }

    void IXmlExternalizable.ReadFromXml(XmlElement element)
    {
      if (element == null)
      {
        FileAssociations = Default.FileAssociations;
        return;
      }

      try
      {
        var serializer = new XmlSerializer(GetType());
        using (XmlReader reader = XmlReader.Create(new StringReader(element.InnerXml)))
        {
          var settings = (Settings) serializer.Deserialize(reader);
          FileAssociations = settings.FileAssociations;
        }
      }
      catch (Exception ex)
      {
        Logger.LogException("Failed to load ZenCoding settings", ex);
      }
    }

    void IXmlExternalizable.WriteToXml(XmlElement element)
    {
      element.SetAttribute("version", "1");
      var serializer = new XmlSerializer(GetType());

      using (var sw = new StringWriter())
      {
        using (XmlWriter writer = XmlWriter.Create(sw))
        {
          serializer.Serialize(writer, this);
        }

        var document = new XmlDocument();
        document.LoadXml(sw.GetStringBuilder().ToString());

        element.InnerXml = document.DocumentElement.OuterXml;
      }
    }

    #endregion

    public bool IsSupportedFile(string fileName)
    {
      return FileAssociations.Any(a => HandlerMatch(a, fileName));
    }

    private bool HandlerMatch(FileAssociation a, string fileName)
    {
      return myHandlers.FirstOrDefault(x => x.Matches(a, fileName)) != null;
    }

    public DocType GetDocType(string fileName)
    {
      FileAssociation fileAssociation = FileAssociations.FirstOrDefault(a => HandlerMatch(a, fileName));
      if (fileAssociation != null)
      {
        return fileAssociation.DocType;
      }

      throw new NotSupportedException();
    }
  }
}