using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraPreguiçosa
{
    internal class Matematica
    {
        public string Calcular(string expressao)
        {
            string strCalc = expressao.Replace("÷", "/").Replace("×", "*");
            string resposta = "Erro de Sintaxe";

            DataTable tabela = new DataTable();
            try
            {
                var resultado = tabela.Compute(strCalc, "");

                if (double.TryParse(resultado.ToString(), out double numero))
                {
                    if (numero % 1 != 0)
                    {
                        resposta = $"Ah, {numero:F0} e uns quebrados...";
                        return resposta;
                    }
                }

                resposta = resultado.ToString();
                return resposta;
            }
            catch
            {
                return resposta;
            }
        }
    }
}
