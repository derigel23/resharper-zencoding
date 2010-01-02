using System;

using JetBrains.ReSharper.PowerToys.ZenCoding.Options.Model;
using JetBrains.UI.CommonControls;

namespace JetBrains.ReSharper.PowerToys.ZenCoding.Options
{
  public partial class EditFileAssociationControl : SafeUserControl
  {
    bool _updateCookie;

    public EditFileAssociationControl()
    {
    }

    public EditFileAssociationControl(FileAssociation fileAssociation)
    {
      InitializeComponent();

      SetUpValues(fileAssociation);
      SetUpValueChangedHandlers();
    }

    public FileAssociation FileAssociation
    {
      get;
      private set;
    }

    void SetUpValues(FileAssociation fileAssociation)
    {
      FileAssociation = fileAssociation;

      _pattern.Text = FileAssociation.Pattern;
      _enabled.Checked = FileAssociation.Enabled;

      switch (FileAssociation.DocType)
      {
        case DocType.Html:
          _html.Checked = true;
          break;
        case DocType.Css:
          _css.Checked = true;
          break;
        case DocType.Xsl:
          _xsl.Checked = true;
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }

      switch (FileAssociation.PatternType)
      {
        case PatternType.FileExtension:
          _fileExtension.Checked = true;
          break;
        case PatternType.Regex:
          _regex.Checked = true;
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    void SetUpValueChangedHandlers()
    {
      _pattern.TextChanged += ParamsChanged;

      _fileExtension.CheckedChanged += ParamsChanged;
      _regex.CheckedChanged += ParamsChanged;

      _html.CheckedChanged += ParamsChanged;
      _css.CheckedChanged += ParamsChanged;
      _xsl.CheckedChanged += ParamsChanged;

      _enabled.CheckedChanged += ParamsChanged;
    }

    void ParamsChanged(object sender, EventArgs e)
    {
      if (!_updateCookie)
      {
        _updateCookie = true;

        FileAssociation.Pattern = _pattern.Text;

        if (_fileExtension.Checked)
        {
          FileAssociation.PatternType = PatternType.FileExtension;
        }

        if (_regex.Checked)
        {
          FileAssociation.PatternType = PatternType.Regex;
        }

        if (_html.Checked)
        {
          FileAssociation.DocType = DocType.Html;
        }

        if (_css.Checked)
        {
          FileAssociation.DocType = DocType.Css;
        }

        if (_xsl.Checked)
        {
          FileAssociation.DocType = DocType.Xsl;
        }

        FileAssociation.Enabled = _enabled.Checked;

        _updateCookie = false;
      }
    }
  }
}