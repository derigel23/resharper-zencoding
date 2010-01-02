using System.Windows.Forms;

namespace JetBrains.ReSharper.PowerToys.ZenCoding.Options
{
  partial class ZenCodingOptionsPage
  {
    ToolStrip _buttons;
    Panel _fileAssociations;
    Panel _rules;

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
      this._fileAssociations = new System.Windows.Forms.Panel();
      this._rules = new System.Windows.Forms.Panel();
      this._buttons = new System.Windows.Forms.ToolStrip();
      this._panel = new System.Windows.Forms.Panel();
      this._reset = new System.Windows.Forms.Button();
      this._fileAssociations.SuspendLayout();
      this._panel.SuspendLayout();
      this.SuspendLayout();
      // 
      // _fileAssociations
      // 
      this._fileAssociations.Controls.Add(this._rules);
      this._fileAssociations.Controls.Add(this._buttons);
      this._fileAssociations.Dock = System.Windows.Forms.DockStyle.Fill;
      this._fileAssociations.Location = new System.Drawing.Point(0, 0);
      this._fileAssociations.Name = "_fileAssociations";
      this._fileAssociations.Size = new System.Drawing.Size(502, 393);
      this._fileAssociations.TabIndex = 12;
      // 
      // _rules
      // 
      this._rules.Dock = System.Windows.Forms.DockStyle.Fill;
      this._rules.Location = new System.Drawing.Point(0, 25);
      this._rules.Name = "_rules";
      this._rules.Size = new System.Drawing.Size(502, 368);
      this._rules.TabIndex = 2;
      // 
      // _buttons
      // 
      this._buttons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this._buttons.Location = new System.Drawing.Point(0, 0);
      this._buttons.Name = "_buttons";
      this._buttons.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this._buttons.Size = new System.Drawing.Size(502, 25);
      this._buttons.TabIndex = 1;
      this._buttons.Text = "_buttons";
      // 
      // _panel
      // 
      this._panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this._panel.Controls.Add(this._fileAssociations);
      this._panel.Location = new System.Drawing.Point(0, 0);
      this._panel.Margin = new System.Windows.Forms.Padding(0);
      this._panel.Name = "_panel";
      this._panel.Size = new System.Drawing.Size(502, 393);
      this._panel.TabIndex = 0;
      // 
      // _reset
      // 
      this._reset.Location = new System.Drawing.Point(3, 403);
      this._reset.Name = "_reset";
      this._reset.Size = new System.Drawing.Size(94, 23);
      this._reset.TabIndex = 1;
      this._reset.Text = "Reset defaults";
      this._reset.UseVisualStyleBackColor = true;
      this._reset.Click += new System.EventHandler(this._reset_Click);
      // 
      // ZenCodingOptionsPage
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this._reset);
      this.Controls.Add(this._panel);
      this.Name = "ZenCodingOptionsPage";
      this.Size = new System.Drawing.Size(502, 438);
      this._fileAssociations.ResumeLayout(false);
      this._fileAssociations.PerformLayout();
      this._panel.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private Panel _panel;
    private Button _reset;
  }
}