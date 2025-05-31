using System.Collections.Generic;

namespace FreyaDX;

public class CodigoObjeto
{
    public List<string> GenerarCodigoObjeto(IEnumerable<string> instruccionesIntermedias)
    {
        var codigoObjeto = new List<string>();

        foreach (var instruccion in instruccionesIntermedias)
        {
            // Aquí debes implementar la lógica para traducir cada instrucción intermedia
            // a una o varias instrucciones de código objeto.

            // Ejemplo simple: si la instrucción intermedia es "t1 = 1 + 1"
            // traducir a instrucciones tipo ensamblador simplificado.

            if (instruccion.Contains("+"))
            {
                var partes = instruccion.Split('=');
                var variable = partes[0].Trim();
                var expresion = partes[1].Trim();

                var operandos = expresion.Split('+');
                var op1 = operandos[0].Trim();
                var op2 = operandos[1].Trim();

                codigoObjeto.Add(LoadOperand(op1));
                codigoObjeto.Add(LoadOperand(op2));
                codigoObjeto.Add("ADD");
                codigoObjeto.Add($"STORE {variable}");
            }
            else if (instruccion.Contains("="))
            {
                var partes = instruccion.Split('=');
                var variable = partes[0].Trim();
                var valor = partes[1].Trim();

                codigoObjeto.Add(LoadOperand(valor));
                codigoObjeto.Add($"STORE {variable}");
            }
            else codigoObjeto.Add($"; {instruccion}"); // Otras instrucciones o comentarios
        }

        return codigoObjeto;
    }

    private string LoadOperand(string operando)
    {
        if (int.TryParse(operando, out int valor)) return $"LOAD_CONST {valor}";
        return $"LOAD {operando}";
    }
}