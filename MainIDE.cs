using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace FreyaDX
{
    public partial class MainIDE : Form
    {
        private SyntaxHighlighter highlighter;

        public MainIDE()
        {
            InitializeComponent();

            highlighter = new SyntaxHighlighter(CajaEditor);

            CajaEditor.Text = @":i shMsg(""Hola Mundo"")";

            // Opcional: resaltar al cambiar texto
            // CajaEditor.TextChanged += (s, e) => { highlighter.Highlight(); };
        }

        private void MainIDE_Load(object sender, EventArgs e)
        {
            CajaConsola.Text += string.Format(@"

{0} // {1:hh:mm:ss}
            ", DateTime.Now.ToLongDateString(),
                DateTime.Now);
            gZDBDarkToolStripMenuItem_Click(null, null);
        }

        /// <summary>
        /// Función que se actuliza cada vez que el texto cambia.
        /// Util para pintar el texto de colores al escribir una palabra reservada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CajaEditor_TextChanged(object sender, EventArgs e)
        {
            // CajaEditor.TextChanged += (s, e) => { highlighter.Highlight(); };
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(this, @"Se limpiará el editor de texto completamente.",
                @"¿Estás seguro?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultado == DialogResult.Yes) CajaEditor.Text = "";
        }

        private void BtnCompilar_Click(object sender, EventArgs e)
        {
            string codigo = CajaEditor.Text; // Obtiene el código del RichTextInput

            AntlrInputStream inputStream = new AntlrInputStream(codigo);
            FreyaLexer lexer = new FreyaLexer(inputStream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            FreyaParser parser = new FreyaParser(tokens);

            if (!string.IsNullOrEmpty(codigo)) // var tree = parser.codeParse();
            {
                object resultado = new CodigoBase().AnalizarCodigo(parser);

                //    if (resultado is not null)
                CajaConsola.Text += new StringBuilder().Append("\n>>> ")
                    .Append((string)resultado);
            }
            else
                MessageBox.Show(@"No hay código escrito para compilar.", @"Esto no se puede compilar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gZDBDarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CajaEditor.BackColor = Color.FromArgb(34, 40, 32);
            CajaEditor.ForeColor = Color.FromArgb(241, 242, 243);

            BackColor = Color.FromArgb(57, 89, 111);
        }

        private void sLADELightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CajaEditor.BackColor = Color.Cornsilk;
            CajaEditor.ForeColor = Color.FromName("ControlText");

            BackColor = Color.FromName("ControlLightLight");
        }

        private int _toasty = 1;

        private void FreyaPic_Click(object sender, EventArgs e)
        {
            if (_toasty == 3)
            {
                FreyaPic.Image = Properties.Resources.Toasty_MK3;
                try
                {
                    new SoundPlayer(@"c:\Users\gameg\Downloads\Toasty!.wav").Play();
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            else
                _toasty += 1;
        }
    }
}