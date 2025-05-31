using System.ComponentModel;

namespace FreyaDX;

partial class Info
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Info));
        this.PictureEasterEgg = new System.Windows.Forms.PictureBox();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.PictureEasterEgg)).BeginInit();
        this.SuspendLayout();
        // 
        // PictureEasterEgg
        // 
        this.PictureEasterEgg.BackColor = System.Drawing.Color.Transparent;
        this.PictureEasterEgg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        this.PictureEasterEgg.Image = global::FreyaDX.Properties.Resources.FreyaSword;
        this.PictureEasterEgg.InitialImage = null;
        this.PictureEasterEgg.Location = new System.Drawing.Point(139, 144);
        this.PictureEasterEgg.Margin = new System.Windows.Forms.Padding(4);
        this.PictureEasterEgg.Name = "PictureEasterEgg";
        this.PictureEasterEgg.Size = new System.Drawing.Size(320, 200);
        this.PictureEasterEgg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.PictureEasterEgg.TabIndex = 0;
        this.PictureEasterEgg.TabStop = false;
        this.PictureEasterEgg.Click += new System.EventHandler(this.PictureEasterEgg_Click);
        // 
        // label1
        // 
        this.label1.BackColor = System.Drawing.Color.Transparent;
        this.label1.Font = new System.Drawing.Font("MV Boli", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
        this.label1.Location = new System.Drawing.Point(170, 9);
        this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(262, 50);
        this.label1.TabIndex = 1;
        this.label1.Text = "Compilador Freya";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label2
        // 
        this.label2.BackColor = System.Drawing.Color.Transparent;
        this.label2.Location = new System.Drawing.Point(197, 59);
        this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(223, 81);
        this.label2.TabIndex = 2;
        this.label2.Text = "Creado por:\r\nIsaac Hernández Lucio\r\nJovani de Jesús Rivera Camacho\r\nPaloma Guadal" + "upe Rangel Olvera\r\n";
        this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // Info
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.AutoSize = true;
        this.BackColor = System.Drawing.SystemColors.Window;
        this.BackgroundImage = global::FreyaDX.Properties.Resources.BG;
        this.ClientSize = new System.Drawing.Size(630, 447);
        this.Controls.Add(this.PictureEasterEgg);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Font = new System.Drawing.Font("MV Boli", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Margin = new System.Windows.Forms.Padding(4);
        this.MaximizeBox = false;
        this.Name = "Info";
        this.ShowInTaskbar = false;
        this.Text = "Acerca del compílador Freya";
        ((System.ComponentModel.ISupportInitialize)(this.PictureEasterEgg)).EndInit();
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.PictureBox PictureEasterEgg;

    #endregion
}