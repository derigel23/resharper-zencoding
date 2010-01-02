using System;
using System.Windows.Forms;

using JetBrains.Application;
using JetBrains.ReSharper.PowerToys.ZenCoding.Options.Model;

namespace JetBrains.ReSharper.PowerToys.ZenCoding.Options
{
  public partial class EditFileAssociationForm : Form
  {
    readonly EditFileAssociationControl _editor;

    public EditFileAssociationForm(FileAssociation fileAssociation)
    {
      InitializeComponent();

      _editor = new EditFileAssociationControl(fileAssociation)
                     {
                       Dock = DockStyle.Fill
                     };

      _panel.Controls.Add(_editor);

      Icon = Shell.Instance.Descriptor.ProductIcon;
    }

    public FileAssociation FileAssociation
    {
      get { return _editor.FileAssociation; }
    }

    protected override void OnClosed(EventArgs e)
    {
    }
  }
}