using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FreyaDX
{
    public class ErrorListener : BaseErrorListener
    {
        public List<string> Errores { get; } = new();

        public override void SyntaxError(
            TextWriter output,
            IRecognizer recognizer,
            IToken offendingSymbol,  
            int line,
            int charPositionInLine,
            string msg,
            RecognitionException e)
        {
            Errores.Add($"Error sintáctico en línea {line}, columna {charPositionInLine}: {msg}");
        }
    }
}

