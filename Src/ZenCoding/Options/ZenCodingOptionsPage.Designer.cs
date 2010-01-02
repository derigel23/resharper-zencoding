﻿using System.Windows.Forms;

namespace JetBrains.ReSharper.PowerToys.ZenCoding.Options
{
  partial class ZenCodingOptionsPage
  {
    ToolStrip _buttons;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.Panel _fileAssociations;
      System.Windows.Forms.Panel _container;
      this._rules = new System.Windows.Forms.Panel();
      this._buttons = new System.Windows.Forms.ToolStrip();
      this._reset = new System.Windows.Forms.Button();
      _fileAssociations = new System.Windows.Forms.Panel();
      _container = new System.Windows.Forms.Panel();
      _fileAssociations.SuspendLayout();
      _container.SuspendLayout();
      this.SuspendLayout();
      // 
      // _fileAssociations
      // 
      _fileAssociations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      _fileAssociations.Controls.Add(this._rules);
      _fileAssociations.Controls.Add(this._buttons);
      _fileAssociations.Location = new System.Drawing.Point(3, 3);
      _fileAssociations.Name = "_fileAssociations";
      _fileAssociations.Size = new System.Drawing.Size(767, 696);
      _fileAssociations.TabIndex = 12;
      // 
      // _rules
      // 
      this._rules.Dock = System.Windows.Forms.DockStyle.Fill;
      this._rules.Location = new System.Drawing.Point(0, 25);
      this._rules.Name = "_rules";
      this._rules.Size = new System.Drawing.Size(767, 671);
      this._rules.TabIndex = 1;
      // 
      // _buttons
      // 
      this._buttons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this._buttons.Location = new System.Drawing.Point(0, 0);
      this._buttons.Name = "_buttons";
      this._buttons.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this._buttons.Size = new System.Drawing.Size(767, 25);
      this._buttons.TabIndex = 0;
      this._buttons.Text = "_buttons";
      // 
      // _reset
      // 
      this._reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this._reset.Location = new System.Drawing.Point(3, 705);
      this._reset.Name = "_reset";
      this._reset.Size = new System.Drawing.Size(94, 23);
      this._reset.TabIndex = 0;
      this._reset.Text = "Reset defaults";
      this._reset.UseVisualStyleBackColor = true;
      this._reset.Click += new System.EventHandler(this._reset_Click);
      // 
      // _container
      // 
      _container.Controls.Add(this._reset);
      _container.Controls.Add(_fileAssociations);
      _container.Dock = System.Windows.Forms.DockStyle.Fill;
      _container.Location = new System.Drawing.Point(0, 0);
      _container.Name = "_container";
      _container.Size = new System.Drawing.Size(773, 731);
      _container.TabIndex = 0;
      // 
      // ZenCodingOptionsPage
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(_container);
      this.Name = "ZenCodingOptionsPage";
      this.Size = new System.Drawing.Size(773, 731);
      _fileAssociations.ResumeLayout(false);
      _fileAssociations.PerformLayout();
      _container.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private Button _reset;
    private Panel _rules;
  }
}