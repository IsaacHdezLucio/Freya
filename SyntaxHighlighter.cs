using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FreyaDX;

public class SyntaxHighlighter
{
    private RichTextBox rtb;
    private Dictionary<string, Color> keywordColors = new Dictionary<string, Color>();

    private List<string> keywords1 = new List<string>
    {
        "shMsg", "saySo", "SektStruk", "JIP_Execute", "JIP_ExecuteResult", "a_jumpif", "add", "sub", "div", "mul",
        "sqr", "rot"
    };

    private Color keywords1Color = ColorTranslator.FromHtml("#678CB1"); // fgColor="678CB1"

    // Puedes agregar más listas para Keywords2, Keywords3, etc.

    public SyntaxHighlighter(RichTextBox richTextBox)
    {
        rtb = richTextBox;

        // Inicializar diccionario con palabras clave y colores
        foreach (var kw in keywords1)
            keywordColors[kw] = keywords1Color;

        // Aquí puedes agregar más keywords y colores para otros grupos
    }

    public void Highlight()
    {
        int selectionStart = rtb.SelectionStart;
        int selectionLength = rtb.SelectionLength;

        rtb.SuspendLayout();

        // Guardar posición actual para restaurar después
        int originalSelectionStart = rtb.SelectionStart;
        int originalSelectionLength = rtb.SelectionLength;

        // Quitar formato previo
        rtb.SelectAll();
        rtb.SelectionColor = Color.Black;
        rtb.SelectionBackColor = Color.FromArgb(0, 0, 0, 0); // White;

        // Resaltar palabras clave
        foreach (var kw in keywordColors.Keys)
        {
            HighlightWord(kw, keywordColors[kw]);
        }

        // Restaurar selección
        rtb.SelectionStart = originalSelectionStart;
        rtb.SelectionLength = originalSelectionLength;

        rtb.ResumeLayout();
    }

    private void HighlightWord(string word, Color color)
    {
        Regex regex = new Regex($@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase);
        foreach (Match match in regex.Matches(rtb.Text))
        {
            rtb.Select(match.Index, match.Length);
            rtb.SelectionColor = color;
        }
    }
}