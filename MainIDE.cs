using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using Antlr4.Runtime;
using FreyaDX.Properties;
using static System.Console;

namespace FreyaDX;

public partial class MainIDE : Form
{
    public MainIDE()
    {
        InitializeComponent();

        // Código de inicio y carga de colores
        new SyntaxHighlighter(CajaEditor);
        CajaEditor.Text = string.Concat(":i suma = %f(1 + 1)\n:i shMsg(\"Hola Mundo desde freya v\", suma)");
    }

    private void MainIDE_Load(object sender, EventArgs e)
    {
        // Imprime la fecha y hora al iniciar el programa
        CajaConsola.Text +=
            string.Concat($"\n{string.Format("{0} // {1:hh:mm:ss}", DateTime.Now.ToLongDateString(), DateTime.Now)}\n");

        // Carga el tema oscuro por defecto
        gZDBDarkToolStripMenuItem_Click(null, null);
    }

    #region Funcionalidad del compilador

    private void BtnLimpiar_Click(object sender, EventArgs e)
    {
        var resultado = MessageBox.Show(this, @"Se limpiará el editor de texto completamente.",
            @"¿Estás seguro?",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (resultado == DialogResult.Yes) CajaEditor.Text = "";
    }

    private void BtnCompilar_Click(object sender, EventArgs e)
    {
        var codigo = CajaEditor.Text; // Obtiene el código del RichTextInput

        var inputStream = new AntlrInputStream(codigo);
        var lexer = new FreyaLexer(inputStream);
        var tokens = new CommonTokenStream(lexer);
        var parser = new FreyaParser(tokens);

        if (!string.IsNullOrEmpty(codigo)) // var tree = parser.codeParse();
        {
            var resultado = new CodigoBase().AnalizarCodigo(parser);
            CajaConsola.Text += string.Concat($"\n>>> {resultado}");
        }
        else
            MessageBox.Show(@"No hay código escrito para compilar.", @"Esto no se puede compilar",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void generarCodigoIntermedioToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var codigoFuente = CajaEditor.Text;
        var inputStream = new AntlrInputStream(codigoFuente);
        var lexer = new FreyaLexer(inputStream);
        var tokens = new CommonTokenStream(lexer);
        var parser = new FreyaParser(tokens);
        var tree = parser.codeParse();

        var visitor = new FreyaIntermediateCodeVisitor();
        visitor.Visit(tree);

        var instrucciones = visitor.GetInstructions();
        cajaIntermedio.Text = ""; // Limpia la caja de texto cada vez que se ejecuta de nuevo
        foreach (var instr in instrucciones)
        {
            cajaIntermedio.Text += $@"{string.Join("", instr + "\n")}";
            WriteLine(instr); // Imprime la instrucción en la consola. (Modo desarrollador)
        }
    }

    #endregion

    #region Colores y tema de compilador

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
            FreyaPic.Image = Resources.Toasty_MK3;
            try
            {
                new SoundPlayer(@"c:\Users\gameg\Downloads\Toasty!.wav").Play();
            }
            catch (Exception)
            {
                // ignored
            }
        }
        else _toasty += 1;
    }

    #endregion
}