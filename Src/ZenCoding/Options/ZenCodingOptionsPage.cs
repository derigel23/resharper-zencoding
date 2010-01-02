using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

using JetBrains.ReSharper.Features.Common.Options;
using JetBrains.ReSharper.PowerToys.ZenCoding.Options.Model;
using JetBrains.TreeModels;
using JetBrains.UI;
using JetBrains.UI.Options;

namespace JetBrains.ReSharper.PowerToys.ZenCoding.Options
{
  [OptionsPage(ID,
    "Zen Coding",
    "JetBrains.ReSharper.PowerToys.ZenCoding.Options.zencoding.png",
    ParentId = CommonLanguagePage.PID)]
  public partial class ZenCodingOptionsPage : UserControl, IOptionsPage
  {
    const string ID = "ZenCoding-E439BB70-6F99-4C64-BA42-5D3DAEAC70E1";
    readonly FileAssociationsTreeView _view;

    public ZenCodingOptionsPage()
    {
      InitializeComponent();

      var model = BuildModel(Settings.Instance.FileAssociations);
      _view = new FileAssociationsTreeView(model,
                                           new FileAssociationViewController())
              {
                Presenter = new FileAssociationPresenter(),
                //Dock = DockStyle.Fill
              };
      _view.DoubleClick += EditFileAssociation;
      _rules.Controls.Add(_view);

      _buttons.Items.Add("Create",
                         ImageLoader.GetImage("Create", new Assembly[0]),
                         CreateFileAssociation);

      _buttons.Items.Add("Edit",
                         ImageLoader.GetImage("Edit", new Assembly[0]),
                         EditFileAssociation);

      _buttons.Items.Add("Remove",
                         ImageLoader.GetImage("Remove", new Assembly[0]),
                         RemoveFileAssociation);

      _buttons.Items.Add("Up",
                         ImageLoader.GetImage("Up", new Assembly[0]),
                         MoveUp);

      _buttons.Items.Add("Down",
                         ImageLoader.GetImage("Down", new Assembly[0]),
                         MoveDown);
    }

    public Control Control
    {
      get { return this; }
    }

    public string Id
    {
      get { return ID; }
    }

    public bool OnOk()
    {
      return true;
    }

    public bool ValidatePage()
    {
      return true;
    }

    void CreateFileAssociation(object sender, EventArgs e)
    {
      OpenEditor(new FileAssociation(),
                 form =>
                   {
                     Settings.Instance.FileAssociations.Add(form.FileAssociation);
                     BindModel();
                   });
    }

    void EditFileAssociation(object sender, EventArgs e)
    {
      FileAssociation selection = GetSelectedFileAssociation();
      if (selection == null)
      {
        return;
      }

      OpenEditor((FileAssociation) selection.Clone(), form => selection.CopyFrom(form.FileAssociation));
    }

    void OpenEditor(FileAssociation association, Action<EditFileAssociationForm> onClose)
    {
      using (var form = new EditFileAssociationForm(association))
      {
        if (form.ShowDialog(this) != DialogResult.OK)
        {
          return;
        }

        onClose(form);
        _view.UpdateAllNodesPresentation();
      }
    }

    void RemoveFileAssociation(object sender, EventArgs e)
    {
      FileAssociation selection = GetSelectedFileAssociation();
      if (selection == null)
      {
        return;
      }

      Settings.Instance.FileAssociations.Remove(selection);

      BindModel();
    }

    void MoveUp(object sender, EventArgs e)
    {
      FileAssociation selection = GetSelectedFileAssociation();
      if (selection == null)
      {
        return;
      }

      for (int i = 0; i < Settings.Instance.FileAssociations.Count; i++)
      {
        var association = Settings.Instance.FileAssociations[i];
        if (ReferenceEquals(selection, association) && i > 0)
        {
          Exchange(i, i - 1);
          BindModel();
          break;
        }
      }
    }

    void MoveDown(object sender, EventArgs e)
    {
      FileAssociation selection = GetSelectedFileAssociation();
      if (selection == null)
      {
        return;
      }

      for (int i = 0; i < Settings.Instance.FileAssociations.Count; i++)
      {
        var association = Settings.Instance.FileAssociations[i];
        if (ReferenceEquals(selection, association) && i + 1 < Settings.Instance.FileAssociations.Count)
        {
          Exchange(i, i + 1);
          BindModel();
          break;
        }
      }
    }

    static void Exchange(int first, int second)
    {
      var temp = Settings.Instance.FileAssociations[first];
      Settings.Instance.FileAssociations[first] = Settings.Instance.FileAssociations[second];
      Settings.Instance.FileAssociations[second] = temp;
    }

    FileAssociation GetSelectedFileAssociation()
    {
      TreeModelNode selection = _view.ModelFocusedNode;
      if (selection == null)
      {
        return null;
      }

      var association = selection.DataValue as FileAssociation;
      if (association == null)
      {
        return association;
      }
      return association;
    }

    void _reset_Click(object sender, EventArgs e)
    {
      Settings.Instance.FileAssociations = new List<FileAssociation>();

      foreach (var association in Settings.Default.FileAssociations)
      {
        Settings.Instance.FileAssociations.Add((FileAssociation) association.Clone());
      }

      BindModel();
    }

    static TreeSimpleModel BuildModel(IEnumerable<FileAssociation> fileAssociations)
    {
      var model = new TreeSimpleModel();

      foreach (var association in fileAssociations ?? new FileAssociation[0])
      {
        model.Insert(null, association);
      }

      return model;
    }

    void BindModel()
    {
      _view.Model = BuildModel(Settings.Instance.FileAssociations);
      _view.UpdateAllNodesPresentation();
    }
  }
}