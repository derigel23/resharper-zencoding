using System;

using JetBrains.ReSharper.PowerToys.ZenCoding.Options.Model;
using JetBrains.TreeModels;
using JetBrains.UI.RichText;
using JetBrains.UI.TreeView;

namespace JetBrains.ReSharper.PowerToys.ZenCoding.Options
{
  public class FileAssociationsTreeView : TreeModelPresentableView
  {
    TreeModelViewColumn _associationColumn;
    TreeModelViewColumn _patternTypeColumn;

    public FileAssociationsTreeView(TreeModel model, ITreeViewController controller) : base(model, controller)
    {
    }

    protected override void Initialize()
    {
      base.Initialize();
      ModelColumn.Name = "Pattern";
      ModelColumn.Caption = "Pattern";

      _patternTypeColumn = AddColumn();
      _patternTypeColumn.Name = "Pattern Type";
      _patternTypeColumn.Caption = "Pattern Type";
      _patternTypeColumn.Width = 50;

      _associationColumn = AddColumn();
      _associationColumn.Name = "Document Type";
      _associationColumn.Caption = "Document Type";
      _associationColumn.Width = 150;

      OptionsView.ShowColumns = true;
      OptionsView.ShowHorzLines = true;
      OptionsView.ShowRoot = false;
    }

    protected override void UpdateNodeCells(TreeModelViewNode viewNode, TreeModelNode modelNode, PresentationState state)
    {
      base.UpdateNodeCells(viewNode, modelNode, state);
      viewNode.SetValue(_patternTypeColumn, RichText.Empty);
      viewNode.SetValue(_associationColumn, RichText.Empty);

      var association = modelNode.DataValue as FileAssociation;
      if (association != null)
      {
        UpdateNodeCellsForResult(viewNode, association);
      }
    }

    void UpdateNodeCellsForResult(TreeModelViewNode viewNode, FileAssociation fileAssociation)
    {
      viewNode.SetValue(_patternTypeColumn, fileAssociation.PatternType);
      
      string docType = String.Format("{0}{1}",
                                     fileAssociation.DocType,
                                     fileAssociation.Enabled ? String.Empty : " (disabled)");
      viewNode.SetValue(_associationColumn, docType);
    }
  }
}