using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGeraSimbolos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prova Rodolfo Terra");
            Console.WriteLine("Gerar Simbolos");

            Console.Beep();

            Console.ReadKey();

            var s1 = ":";
            var s2 = "#";
            var linhaTotal = 11;
            var ColunaTotal = 45;
            var linha = 0;
            var coluna = 0;
            var pintar = "";
            var posicaoIni = 22;
            var posicaoFim = 24;

            while (linha < linhaTotal)
            {

                while (coluna < ColunaTotal)
                {
                    coluna = coluna + 1;

                    if ((coluna > posicaoIni) && (coluna < posicaoFim) && (linha > 0))
                    {
                        pintar = s2;

                    }
                    else
                    {
                        pintar = s1;
                    }
                        
                    Console.Write(pintar);
                }

                if(coluna == ColunaTotal)
                {
                    Console.WriteLine(pintar);
                    coluna = 0;
                }

                linha = linha + 1;

                if ((linha > 1) && (linha < 6))
                {
                    posicaoIni = posicaoIni - 3;
                    posicaoFim = posicaoFim + 3;
                }
                else if(linha >= 6)
                {
                    posicaoIni = posicaoIni + 3;
                    posicaoFim = posicaoFim - 3;

                }



            }

            Console.Beep();
            Console.ReadKey();
        }
    }
}
