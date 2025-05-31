using System;
using System.Collections.Generic;
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
        CajaConsola.Text += string.Concat($"\n{DateTime.Now.ToLongDateString()} // {DateTime.Now:hh:mm:ss}\n");
        // Carga el tema oscuro por defecto
        gZDBDarkToolStripMenuItem_Click(null, null);
    }

    #region Funcionalidad del compilador (Compilación de código y limpiar editor de código)

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

    private void BtnLimpiar_Click(object sender, EventArgs e)
    {
        var resultado = MessageBox.Show(this, @"Se limpiará el editor de texto completamente.",
            @"¿Estás seguro?",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (resultado == DialogResult.Yes) CajaEditor.Text = "";
    }

    #endregion

    #region Generar código intermedio y objecto

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
        // Limpia la caja de texto cada vez que se ejecuta de nuevo
        CajaIntObj.Text = "";
        foreach (var instr in instrucciones) CajaIntObj.Text += $@"{string.Join("", instr + "\n")}";

        // Habilita la opción de codigo objeto
        generarCódigoObjetoToolStripMenuItem.Enabled = true;
    }

    private void generarCódigoObjetoToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // Obtener el código intermedio desde la caja de texto o desde el visitor
        var codigoIntermedio = CajaIntObj.Text;

        // Parsear o procesar el código intermedio
        var instruccionesIntermedias =
            codigoIntermedio.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

        // Crear el generador de código objeto
        var generadorCodigoObjeto = new CodigoObjeto();

        // Generar instrucciones de código objeto
        var codigoObjeto = generadorCodigoObjeto.GenerarCodigoObjeto(instruccionesIntermedias);

        // Mostrar el código objeto en la caja de texto correspondiente
        CajaIntObj.Text = string.Join("\r\n", codigoObjeto);
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

    #endregion

    private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e) => new InfoForm().ShowDialog();
}