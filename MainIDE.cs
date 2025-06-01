using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        // Aquí agregas el errorListener
        var errorListener = new ErrorListener();
        parser.RemoveErrorListeners(); // Elimina listeners por defecto
        parser.AddErrorListener(errorListener);

        bool sinErrores = AnalizarCodigo();

        if (!sinErrores)
        {
            MessageBox.Show("Corrige los errores antes de continuar.", "Errores detectados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        else 

        if (errorListener.Errores.Count > 0)
        {
            foreach (var error in errorListener.Errores) ;

        }


        else if (!string.IsNullOrEmpty(codigo)) // var tree = parser.codeParse();
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

#region Errores y Optimizacion

    // Listas para almacenar mensajes
    private List<string> errores = new();
    private List<string> recomendaciones = new();

    private ErrorListener errorListener;

    private void LogConsola(string mensaje, bool esError = false)
    {
        CajaConsola.Invoke((MethodInvoker)delegate
        {
            CajaConsola.SelectionStart = CajaConsola.TextLength;
            CajaConsola.SelectionLength = 0;

            CajaConsola.SelectionColor = esError ? Color.Red : Color.Black;
            CajaConsola.AppendText(mensaje + Environment.NewLine);
            CajaConsola.SelectionColor = CajaConsola.ForeColor;
            CajaConsola.ScrollToCaret();
        });
    }


    private bool AnalizarCodigo()
    {
        CajaConsola.Clear();
        errores.Clear();
        recomendaciones.Clear();

        var codigo = CajaEditor.Text;
        if (string.IsNullOrWhiteSpace(codigo))
        {
            LogConsola("No hay código para analizar.", true);
            return false;
        }

        var inputStream = new AntlrInputStream(codigo);
        var lexer = new FreyaLexer(inputStream);
        var tokens = new CommonTokenStream(lexer);
        var parser = new FreyaParser(tokens);

        var errorListener = new ErrorListener();
        parser.RemoveErrorListeners();
        parser.AddErrorListener(errorListener);

        // Parsear una sola vez y guardar el árbol
        var tree = parser.codeParse();

        // Si hay errores sintácticos, mostrarlos y no continuar
        if (errorListener.Errores.Count > 0)
        {
            foreach (var error in errorListener.Errores)
            {
                LogConsola(error, true);
                errores.Add(error); // También guardar en lista global de errores si la usas
            }
            return false;
        }

        LogConsola("Análisis sintáctico correcto.", false);

        // Detectar variables no usadas y llenar recomendaciones
        DetectarVariablesNoUsadas(tree);

        return true; // No hay errores
    }

    private void ResaltarVariablesNoUsadas(List<string> variables)
    {
        foreach (var variable in variables)
        {
            int startIndex = 0;
            while (startIndex < CajaEditor.TextLength)
            {
                int wordStartIndex = CajaEditor.Find(variable, startIndex, RichTextBoxFinds.WholeWord);
                if (wordStartIndex != -1)
                {
                    CajaEditor.SelectionStart = wordStartIndex;
                    CajaEditor.SelectionLength = variable.Length;
                    CajaEditor.SelectionBackColor = Color.LightPink; // Marca en rosa claro
                    startIndex = wordStartIndex + variable.Length;
                }
                else
                {
                    break;
                }
            }
        }
        CajaEditor.SelectionLength = 0; // Quitar selección
    }

    private void DetectarVariablesNoUsadas(FreyaParser.CodeParseContext tree)
    {
        var visitor = new VariableUsageVisitor();
        visitor.Visit(tree);

        var variablesNoUsadas = visitor.VariablesDeclaradas
            .Where(v => !visitor.VariablesUsadas.Contains(v))
            .ToList();

        foreach (var variable in variablesNoUsadas)
        {
            recomendaciones.Add($"La variable '{variable}' está declarada pero no se usa.");
        }

        // Aquí llamas al método para resaltar en el editor las variables no usadas
        ResaltarVariablesNoUsadas(variablesNoUsadas);
    }


    private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e) => new InfoForm().ShowDialog();

    private void erroresToolStripMenuItem_Click(object sender, EventArgs e)
    {
        bool sinErrores = AnalizarCodigo();

        if (sinErrores)
        {
            CajaIntObj.Text = "No se encontraron errores sintácticos.";
        }
        else
        {
            if (errores.Count == 0)
            {
                CajaIntObj.Text = "No se encontraron errores sintácticos.";
            }
            else
            {
                CajaIntObj.Text = string.Join(Environment.NewLine, errores);
            }
        }
    }


    private void optimizaciónToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // Primero ejecuta el análisis para llenar la lista de recomendaciones
        bool sinErrores = AnalizarCodigo();

        if (!sinErrores)
        {
            // Si hay errores sintácticos, limpia o muestra mensaje en CajaIntObj
            CajaIntObj.Text = "No se pueden mostrar recomendaciones porque hay errores sintácticos.";
            return;
        }

        if (recomendaciones.Count == 0)
        {
            CajaIntObj.Text = "No se encontraron recomendaciones de optimización.";
        }
        else
        {
            // Muestra todas las recomendaciones en el control
            CajaIntObj.Text = string.Join(Environment.NewLine, recomendaciones);
        }
    }

    #endregion


    private void CajaIntObj_TextChanged(object sender, EventArgs e)
    {
        
    }
}