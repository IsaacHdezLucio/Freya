using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FreyaDX;

/// <summary>
/// Clase que se actualiza cada vez que el texto cambia.
/// Util para pintar el texto de colores al escribir una palabra reservada.
/// </summary>
public class SyntaxHighlighter
{
    private RichTextBox _editor;

    #region styleset readonly

    // Colores definidos según el styleset "GZDoom Builder Dark"
    private readonly Color _backgroundColor = Color.FromArgb(34, 40, 42);
    private readonly Color _foregroundColor = Color.FromArgb(241, 242, 243);
    private readonly Color _selectionBackColor = Color.FromArgb(71, 71, 71);
    private readonly Color _selectionForeColor = Color.FromArgb(255, 255, 255);

    private readonly Color _preprocessorColor = Color.FromArgb(160, 130, 189);
    private readonly Color _commentColor = Color.FromArgb(102, 116, 123);
    private readonly Color _stringColor = Color.FromArgb(236, 118, 0);
    private readonly Color _keywordColor = Color.FromArgb(135, 206, 250);
    private readonly Color _constantColor = Color.FromArgb(147, 199, 99);
    private readonly Color _functionColor = Color.FromArgb(103, 140, 177);
    private readonly Color _numberColor = Color.FromArgb(255, 205, 34);
    private readonly Color _operatorColor = Color.FromArgb(241, 242, 243);

    #endregion

    // Palabras clave y funciones internas Freya
    private HashSet<string> _keywords = new() { "script", "endfunction", "Puke" };
    private static HashSet<string> _internalFunctions = new() { "shMsg" };

    #region Regex para tokens

    private Regex _regexSingleLineComment = new(@"--.*?$", RegexOptions.Multiline | RegexOptions.Compiled);
    private Regex _regexMultiLineComment = new(@"/\*.*?\*/", RegexOptions.Singleline | RegexOptions.Compiled);
    private Regex _regexString = new(@"%s\(""[^""]*""\)|""([^""\\]|\\.)*""", RegexOptions.Compiled);
    private Regex _regexChar = new("'.*?'", RegexOptions.Compiled);
    private Regex _regexNumber = new(@"%[if]\(\d+(\.\d+)?\)", RegexOptions.Compiled);
    private Regex _regexInstruction = new(@":i\b", RegexOptions.Compiled);
    private Regex _regexKeywords = new(@"\b\w+\b", RegexOptions.Compiled);
    private Regex _regexOperator = new(@"[+\-*/%=!<>&|^~?:]", RegexOptions.Compiled);


    private Regex _regexInternalFunctions =
        new(@"\b(" + string.Join("|", _internalFunctions.Select(Regex.Escape)) + @")\b", RegexOptions.Compiled);

    #endregion

    public SyntaxHighlighter(RichTextBox editor)
    {
        _editor = editor;
        _editor.BackColor = _backgroundColor;
        _editor.ForeColor = _foregroundColor;
        _editor.SelectionBackColor = _selectionBackColor;
        _editor.SelectionColor = _selectionBackColor;
        // _editor.Font = new Font("Consolas", 10);
        _editor.TextChanged += Editor_TextChanged;
    }

    private void Editor_TextChanged(object sender, EventArgs e)
    {
        int selectionStart = _editor.SelectionStart;
        int selectionLength = _editor.SelectionLength;

        // Desactivar eventos para evitar recursividad
        _editor.TextChanged -= Editor_TextChanged;

        // Guardar scroll para restaurar luego
        int scrollPos = GetScrollPos(_editor.Handle, SB_VERT);

        // Guardar selección actual
        _editor.SuspendLayout();

        // Aplicar color base
        _editor.SelectAll();
        _editor.SelectionColor = _foregroundColor;

        #region texto y función de resaltado

        string text = _editor.Text;

        // Mini función de resaltado de texto
        void ResaltarTexto(int index, int length, Color color)
        {
            _editor.Select(index, length);
            _editor.SelectionColor = color;
        }

        #endregion

        #region Aplicación de colores

        // Aplicar números
        foreach (Match m in _regexNumber.Matches(text)) ResaltarTexto(m.Index, m.Length, _numberColor);

        // Aplicar operadores
        foreach (Match m in _regexOperator.Matches(text)) ResaltarTexto(m.Index, m.Length, _operatorColor);

        // Color de instrucción de preprocesador (:i)
        foreach (Match m in _regexInstruction.Matches(text)) ResaltarTexto(m.Index, m.Length, _preprocessorColor);

        // Aplicar strings
        foreach (Match m in _regexString.Matches(text))
            ResaltarTexto(m.Index, m.Length, _stringColor);
        // Aplicar caracteres
        foreach (Match m in _regexChar.Matches(text)) ResaltarTexto(m.Index, m.Length, _stringColor);

        // Palabras clave
        foreach (Match m in _regexKeywords.Matches(text))
        {
            string word = m.Value;
            if (_keywords.Contains(word)) ResaltarTexto(m.Index, m.Length, _keywordColor);
        }

        // Aplicar color a funciones internas
        foreach (Match m in _regexInternalFunctions.Matches(text)) ResaltarTexto(m.Index, m.Length, _functionColor);

        // Comentarios línea
        foreach (Match m in _regexSingleLineComment.Matches(text)) ResaltarTexto(m.Index, m.Length, _commentColor);
        // Comentarios multilínea
        foreach (Match m in _regexMultiLineComment.Matches(text)) ResaltarTexto(m.Index, m.Length, _commentColor);

        #endregion

        // Restaurar selección original
        _editor.SelectionStart = selectionStart;
        _editor.SelectionLength = selectionLength;

        _editor.ResumeLayout();

        // Restaurar scroll
        SetScrollPos(_editor.Handle, SB_VERT, scrollPos, true);
        SendMessage(_editor.Handle, WM_VSCROLL, (IntPtr)(SB_THUMBPOSITION + 0x10000 * scrollPos), IntPtr.Zero);

        // Reactivar evento
        _editor.TextChanged += Editor_TextChanged;
    }

    // Importaciones para manejo scroll y evitar salto al recolorear
    private const int SB_VERT = 1;
    private const int WM_VSCROLL = 0x115;
    private const int SB_THUMBPOSITION = 4;

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern int GetScrollPos(IntPtr hWnd, int nBar);

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
}