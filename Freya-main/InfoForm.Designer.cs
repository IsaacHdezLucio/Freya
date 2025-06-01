using System.ComponentModel;

namespace FreyaDX;

partial class InfoForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoForm));
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.FreyaPB = new System.Windows.Forms.PictureBox();
        ((System.ComponentModel.ISupportInitialize)(this.FreyaPB)).BeginInit();
        this.SuspendLayout();
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.BackColor = System.Drawing.Color.Transparent;
        this.label1.Font = new System.Drawing.Font("MV Boli", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
        this.label1.Location = new System.Drawing.Point(177, 9);
        this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(262, 39);
        this.label1.TabIndex = 1;
        this.label1.Text = "Compilador Freya";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.BackColor = System.Drawing.Color.Transparent;
        this.label2.Location = new System.Drawing.Point(208, 48);
        this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(202, 68);
        this.label2.TabIndex = 2;
        this.label2.Text = "Creado por:\r\nIsaac Hernández Lucio\r\nJovani de Jesús Rivera Camacho\r\nPaloma Guadal" + "upe Rangel Olvera\r\n";
        this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // FreyaPB
        // 
        this.FreyaPB.BackColor = System.Drawing.Color.Transparent;
        this.FreyaPB.Image = global::FreyaDX.Properties.Resources.Miniatura1;
        this.FreyaPB.Location = new System.Drawing.Point(155, 119);
        this.FreyaPB.Name = "FreyaPB";
        this.FreyaPB.Size = new System.Drawing.Size(302, 303);
        this.FreyaPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.FreyaPB.TabIndex = 3;
        this.FreyaPB.TabStop = false;
        this.FreyaPB.Click += new System.EventHandler(this.FreyaPB_Click);
        // 
        // Info
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.AutoSize = true;
        this.BackColor = System.Drawing.SystemColors.Window;
        this.BackgroundImage = global::FreyaDX.Properties.Resources.BG;
        this.ClientSize = new System.Drawing.Size(630, 447);
        this.Controls.Add(this.FreyaPB);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Font = new System.Drawing.Font("MV Boli", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Margin = new System.Windows.Forms.Padding(4);
        this.MaximizeBox = false;
        this.Name = "InfoForm";
        this.ShowInTaskbar = false;
        this.Text = "Acerca del compílador Freya";
        ((System.ComponentModel.ISupportInitialize)(this.FreyaPB)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.PictureBox FreyaPB;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    #endregion
}