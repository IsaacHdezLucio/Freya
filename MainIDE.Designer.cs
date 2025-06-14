﻿namespace FreyaDX
{
    partial class MainIDE
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainIDE));
            this.CajaEditor = new System.Windows.Forms.RichTextBox();
            this.CajaConsola = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarCodigoIntermedioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarCódigoObjetoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logDeErroresoptimizaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optimizaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnCompilar = new System.Windows.Forms.ToolStripButton();
            this.BtnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnAbrir = new System.Windows.Forms.ToolStripButton();
            this.BtnNuevo = new System.Windows.Forms.ToolStripButton();
            this.BtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.gZDBDarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sLADELightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CajaIntObj = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CajaEditor
            // 
            this.CajaEditor.AcceptsTab = true;
            this.CajaEditor.BackColor = System.Drawing.Color.Cornsilk;
            this.CajaEditor.Cursor = System.Windows.Forms.Cursors.Default;
            this.CajaEditor.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CajaEditor.Location = new System.Drawing.Point(12, 52);
            this.CajaEditor.Name = "CajaEditor";
            this.CajaEditor.Size = new System.Drawing.Size(597, 490);
            this.CajaEditor.TabIndex = 1;
            this.CajaEditor.Text = "";
            // 
            // CajaConsola
            // 
            this.CajaConsola.AutoWordSelection = true;
            this.CajaConsola.BackColor = System.Drawing.Color.Black;
            this.CajaConsola.Cursor = System.Windows.Forms.Cursors.No;
            this.CajaConsola.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CajaConsola.ForeColor = System.Drawing.Color.Lime;
            this.CajaConsola.Location = new System.Drawing.Point(615, 290);
            this.CajaConsola.Name = "CajaConsola";
            this.CajaConsola.ReadOnly = true;
            this.CajaConsola.Size = new System.Drawing.Size(466, 252);
            this.CajaConsola.TabIndex = 2;
            this.CajaConsola.Text = "// --------------------------------------------\n//\n// Freya: Belleza hecha código" +
    "\n//\n// --------------------------------------------";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.herramientasToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1104, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarCodigoIntermedioToolStripMenuItem,
            this.generarCódigoObjetoToolStripMenuItem,
            this.logDeErroresoptimizaciónToolStripMenuItem});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // generarCodigoIntermedioToolStripMenuItem
            // 
            this.generarCodigoIntermedioToolStripMenuItem.Name = "generarCodigoIntermedioToolStripMenuItem";
            this.generarCodigoIntermedioToolStripMenuItem.Size = new System.Drawing.Size(281, 26);
            this.generarCodigoIntermedioToolStripMenuItem.Text = "Generar código intermedio";
            this.generarCodigoIntermedioToolStripMenuItem.Click += new System.EventHandler(this.generarCodigoIntermedioToolStripMenuItem_Click);
            // 
            // generarCódigoObjetoToolStripMenuItem
            // 
            this.generarCódigoObjetoToolStripMenuItem.Enabled = false;
            this.generarCódigoObjetoToolStripMenuItem.Name = "generarCódigoObjetoToolStripMenuItem";
            this.generarCódigoObjetoToolStripMenuItem.Size = new System.Drawing.Size(281, 26);
            this.generarCódigoObjetoToolStripMenuItem.Text = "Generar código objeto";
            this.generarCódigoObjetoToolStripMenuItem.Click += new System.EventHandler(this.generarCódigoObjetoToolStripMenuItem_Click);
            // 
            // logDeErroresoptimizaciónToolStripMenuItem
            // 
            this.logDeErroresoptimizaciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.erroresToolStripMenuItem,
            this.optimizaciónToolStripMenuItem});
            this.logDeErroresoptimizaciónToolStripMenuItem.Name = "logDeErroresoptimizaciónToolStripMenuItem";
            this.logDeErroresoptimizaciónToolStripMenuItem.Size = new System.Drawing.Size(281, 26);
            this.logDeErroresoptimizaciónToolStripMenuItem.Text = "Log de errores/optimización";
            // 
            // erroresToolStripMenuItem
            // 
            this.erroresToolStripMenuItem.Name = "erroresToolStripMenuItem";
            this.erroresToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.erroresToolStripMenuItem.Text = "Errores";
            this.erroresToolStripMenuItem.Click += new System.EventHandler(this.erroresToolStripMenuItem_Click);
            // 
            // optimizaciónToolStripMenuItem
            // 
            this.optimizaciónToolStripMenuItem.Name = "optimizaciónToolStripMenuItem";
            this.optimizaciónToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.optimizaciónToolStripMenuItem.Text = "Optimización";
            this.optimizaciónToolStripMenuItem.Click += new System.EventHandler(this.optimizaciónToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.acercaDeToolStripMenuItem.Text = "Acerca de Freya";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnCompilar,
            this.BtnLimpiar,
            this.toolStripSeparator1,
            this.BtnAbrir,
            this.BtnNuevo,
            this.BtnGuardar,
            this.toolStripSeparator2,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1104, 27);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnCompilar
            // 
            this.BtnCompilar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnCompilar.Image = global::FreyaDX.Properties.Resources.compile;
            this.BtnCompilar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCompilar.Name = "BtnCompilar";
            this.BtnCompilar.Size = new System.Drawing.Size(29, 24);
            this.BtnCompilar.Text = "Compilar";
            this.BtnCompilar.Click += new System.EventHandler(this.BtnCompilar_Click);
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnLimpiar.Image = global::FreyaDX.Properties.Resources.text;
            this.BtnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(29, 24);
            this.BtnLimpiar.Text = "Limpiar texto";
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // BtnAbrir
            // 
            this.BtnAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnAbrir.Image = global::FreyaDX.Properties.Resources.open;
            this.BtnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAbrir.Name = "BtnAbrir";
            this.BtnAbrir.Size = new System.Drawing.Size(29, 24);
            this.BtnAbrir.Text = "toolStripButton1";
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnNuevo.Image = global::FreyaDX.Properties.Resources.newarchive;
            this.BtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(29, 24);
            this.BtnNuevo.Text = "toolStripButton1";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnGuardar.Image = global::FreyaDX.Properties.Resources.save;
            this.BtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(29, 24);
            this.BtnGuardar.Text = "toolStripButton2";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gZDBDarkToolStripMenuItem,
            this.sLADELightToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::FreyaDX.Properties.Resources.palette_generate;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(34, 24);
            this.toolStripDropDownButton1.Text = "Color del Editor";
            // 
            // gZDBDarkToolStripMenuItem
            // 
            this.gZDBDarkToolStripMenuItem.Name = "gZDBDarkToolStripMenuItem";
            this.gZDBDarkToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.gZDBDarkToolStripMenuItem.Text = "GZDB Dark";
            this.gZDBDarkToolStripMenuItem.Click += new System.EventHandler(this.gZDBDarkToolStripMenuItem_Click);
            // 
            // sLADELightToolStripMenuItem
            // 
            this.sLADELightToolStripMenuItem.Name = "sLADELightToolStripMenuItem";
            this.sLADELightToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.sLADELightToolStripMenuItem.Text = "SLADE (Light)";
            this.sLADELightToolStripMenuItem.Click += new System.EventHandler(this.sLADELightToolStripMenuItem_Click);
            // 
            // CajaIntObj
            // 
            this.CajaIntObj.AutoWordSelection = true;
            this.CajaIntObj.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.CajaIntObj.Cursor = System.Windows.Forms.Cursors.No;
            this.CajaIntObj.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CajaIntObj.Location = new System.Drawing.Point(615, 53);
            this.CajaIntObj.Name = "CajaIntObj";
            this.CajaIntObj.ReadOnly = true;
            this.CajaIntObj.Size = new System.Drawing.Size(466, 231);
            this.CajaIntObj.TabIndex = 9;
            this.CajaIntObj.Text = "";
            this.CajaIntObj.TextChanged += new System.EventHandler(this.CajaIntObj_TextChanged);
            // 
            // MainIDE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1104, 554);
            this.Controls.Add(this.CajaIntObj);
            this.Controls.Add(this.CajaEditor);
            this.Controls.Add(this.CajaConsola);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainIDE";
            this.Text = "Freya: Belleza hecha código";
            this.Load += new System.EventHandler(this.MainIDE_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem generarCódigoObjetoToolStripMenuItem;

        private System.Windows.Forms.RichTextBox CajaIntObj;

        private System.Windows.Forms.ToolStripMenuItem generarCodigoIntermedioToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem sLADELightToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem gZDBDarkToolStripMenuItem;

        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

        #endregion

        private System.Windows.Forms.RichTextBox CajaEditor;
        private System.Windows.Forms.RichTextBox CajaConsola;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnCompilar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BtnAbrir;
        private System.Windows.Forms.ToolStripButton BtnGuardar;
        private System.Windows.Forms.ToolStripButton BtnNuevo;
        private System.Windows.Forms.ToolStripButton BtnLimpiar;
        private System.Windows.Forms.ToolStripMenuItem logDeErroresoptimizaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erroresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optimizaciónToolStripMenuItem;
    }
}

