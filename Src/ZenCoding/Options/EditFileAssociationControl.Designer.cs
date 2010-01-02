using System.Drawing;
using System.Windows.Forms;

namespace JetBrains.ReSharper.PowerToys.ZenCoding.Options
{
  partial class EditFileAssociationControl
  {
    CheckBox _enabled;
    TextBox _pattern;
    
    RadioButton _fileExtension;
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.Label _patternLabel;
      System.Windows.Forms.Label _patternTypeLabel;
      System.Windows.Forms.Label _associationLabel;
      this._fileExtension = new System.Windows.Forms.RadioButton();
      this._pattern = new System.Windows.Forms.TextBox();
      this._enabled = new System.Windows.Forms.CheckBox();
      this._regex = new System.Windows.Forms.RadioButton();
      this.panel1 = new System.Windows.Forms.Panel();
      this._xsl = new System.Windows.Forms.RadioButton();
      this._css = new System.Windows.Forms.RadioButton();
      this._html = new System.Windows.Forms.RadioButton();
      this.panel2 = new System.Windows.Forms.Panel();
      _patternLabel = new System.Windows.Forms.Label();
      _patternTypeLabel = new System.Windows.Forms.Label();
      _associationLabel = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // _patternLabel
      // 
      _patternLabel.AutoSize = true;
      _patternLabel.Location = new System.Drawing.Point(3, 6);
      _patternLabel.Name = "_patternLabel";
      _patternLabel.Size = new System.Drawing.Size(44, 13);
      _patternLabel.TabIndex = 0;
      _patternLabel.Text = "&Pattern:";
      // 
      // _patternTypeLabel
      // 
      _patternTypeLabel.AutoSize = true;
      _patternTypeLabel.Location = new System.Drawing.Point(4, 5);
      _patternTypeLabel.Name = "_patternTypeLabel";
      _patternTypeLabel.Size = new System.Drawing.Size(71, 13);
      _patternTypeLabel.TabIndex = 0;
      _patternTypeLabel.Text = "Pattern &Type:";
      // 
      // _associationLabel
      // 
      _associationLabel.AutoSize = true;
      _associationLabel.Location = new System.Drawing.Point(4, 6);
      _associationLabel.Name = "_associationLabel";
      _associationLabel.Size = new System.Drawing.Size(64, 13);
      _associationLabel.TabIndex = 0;
      _associationLabel.Text = "&Association:";
      // 
      // _fileExtension
      // 
      this._fileExtension.AutoSize = true;
      this._fileExtension.Location = new System.Drawing.Point(94, 3);
      this._fileExtension.Name = "_fileExtension";
      this._fileExtension.Size = new System.Drawing.Size(121, 17);
      this._fileExtension.TabIndex = 1;
      this._fileExtension.TabStop = true;
      this._fileExtension.Text = "File E&xtension (.html)";
      this._fileExtension.UseVisualStyleBackColor = true;
      // 
      // _pattern
      // 
      this._pattern.Location = new System.Drawing.Point(96, 3);
      this._pattern.Name = "_pattern";
      this._pattern.Size = new System.Drawing.Size(538, 20);
      this._pattern.TabIndex = 1;
      // 
      // _enabled
      // 
      this._enabled.AutoSize = true;
      this._enabled.Location = new System.Drawing.Point(3, 172);
      this._enabled.Name = "_enabled";
      this._enabled.Size = new System.Drawing.Size(95, 17);
      this._enabled.TabIndex = 4;
      this._enabled.Text = "&Enable pattern";
      this._enabled.UseVisualStyleBackColor = true;
      // 
      // _regex
      // 
      this._regex.AutoSize = true;
      this._regex.Location = new System.Drawing.Point(94, 26);
      this._regex.Name = "_regex";
      this._regex.Size = new System.Drawing.Size(159, 17);
      this._regex.TabIndex = 2;
      this._regex.TabStop = true;
      this._regex.Text = "&Regular Expression (.*\\.html)";
      this._regex.UseVisualStyleBackColor = true;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this._xsl);
      this.panel1.Controls.Add(this._css);
      this.panel1.Controls.Add(this._html);
      this.panel1.Controls.Add(_associationLabel);
      this.panel1.Location = new System.Drawing.Point(0, 83);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(262, 83);
      this.panel1.TabIndex = 3;
      // 
      // _xsl
      // 
      this._xsl.AutoSize = true;
      this._xsl.Location = new System.Drawing.Point(94, 50);
      this._xsl.Name = "_xsl";
      this._xsl.Size = new System.Drawing.Size(45, 17);
      this._xsl.TabIndex = 3;
      this._xsl.TabStop = true;
      this._xsl.Text = "X&SL";
      this._xsl.UseVisualStyleBackColor = true;
      // 
      // _css
      // 
      this._css.AutoSize = true;
      this._css.Location = new System.Drawing.Point(94, 27);
      this._css.Name = "_css";
      this._css.Size = new System.Drawing.Size(46, 17);
      this._css.TabIndex = 2;
      this._css.TabStop = true;
      this._css.Text = "&CSS";
      this._css.UseVisualStyleBackColor = true;
      // 
      // _html
      // 
      this._html.AutoSize = true;
      this._html.Location = new System.Drawing.Point(94, 4);
      this._html.Name = "_html";
      this._html.Size = new System.Drawing.Size(55, 17);
      this._html.TabIndex = 1;
      this._html.TabStop = true;
      this._html.Text = "&HTML";
      this._html.UseVisualStyleBackColor = true;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(_patternTypeLabel);
      this.panel2.Controls.Add(this._fileExtension);
      this.panel2.Controls.Add(this._regex);
      this.panel2.Location = new System.Drawing.Point(0, 29);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(263, 48);
      this.panel2.TabIndex = 2;
      // 
      // EditFileAssociationControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this._enabled);
      this.Controls.Add(this._pattern);
      this.Controls.Add(_patternLabel);
      this.Name = "EditFileAssociationControl";
      this.Size = new System.Drawing.Size(269, 199);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private RadioButton _regex;
    private Panel panel1;
    private RadioButton _xsl;
    private RadioButton _css;
    private RadioButton _html;
    private Panel panel2;
  }
}
