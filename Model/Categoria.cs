using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramaAurora
{
    class Categoria
    {
        public int fullHousePontos { get; set; }
        public int auroraPontos { get; set; }
        public int unsPontos { get; set; }
        public int doisPontos { get; set; }
        public int tresPontos { get; set; }
        public int quatroPontos { get; set; }
        public int cincoPontos { get; set; }
        public int seisPontos { get; set; }
        public int parPontos { get; set; }
        public int doisParesPontos { get; set; }
        public int trioPontos { get; set; }
        public int quadraPontos { get; set; }
        public int sequenciaMenorPontos { get; set; }
        public int sequenciaMaiorPontos { get; set; }
        public int pontosTotal { get; set; }

        private Dado ordenarDado(Dado dado)
        {
            Array.Sort(dado.Faces);
            Array.Sort(dado.FaceSequencia);
            return dado;
        }

        public int aurora(Dado dado)
        {
            ordenarDado(dado);
            auroraPontos = 0;
            Boolean iguais = false;

            for (int i = 0; i < 4; i++)
            {
                if (dado.Faces[i] == dado.Faces[i + 1])
                {
                    iguais = true;
                    continue;
                }

                else
                {
                    iguais = false;
                    break;
                }
            }

            if (iguais == true)
            {
                auroraPontos = 50;
                return auroraPontos;
            }

            else
            {
                return auroraPontos;
            }
        }

        public int fullHouse(Dado dado)
        {
            fullHousePontos = 0;

            if (par(dado) > 0 && trio(dado) > 0)
            {
                fullHousePontos = par(dado) + trio(dado);
                return fullHousePontos;
            }

            return fullHousePontos;
        }

        public int uns(Dado dado)
        {
            ordenarDado(dado);
            unsPontos = 0;

            foreach (var face in dado.Faces)
            {
                if (face == 1)
                {
                    unsPontos += face;
                }
            }
            return unsPontos;
        }

        public int dois(Dado dado)
        {
            ordenarDado(dado);
            doisPontos = 0;

            foreach (var face in dado.Faces)
            {
                if (face == 2)
                {
                    doisPontos += face;
                }
            }
            return doisPontos;
        }

        public int tres(Dado dado)
        {
            ordenarDado(dado);
            tresPontos = 0;

            foreach (var face in dado.Faces)
            {
                if (face == 3)
                {
                    tresPontos += face;
                }
            }
            return tresPontos;
        }

        public int quatro(Dado dado)
        {
            ordenarDado(dado);
            quatroPontos = 0;

            foreach (var face in dado.Faces)
            {
                if (face == 4)
                {
                    quatroPontos += face;
                }
            }
            return quatroPontos;
        }

        public int cinco(Dado dado)
        {
            ordenarDado(dado);
            cincoPontos = 0;

            foreach (var face in dado.Faces)
            {
                if (face == 5)
                {
                    cincoPontos += face;
                }
            }
            return cincoPontos;
        }

        public int seis(Dado dado)
        {
            ordenarDado(dado);
            seisPontos = 0;

            foreach (var face in dado.Faces)
            {
                if (face == 6)
                {
                    seisPontos += face;
                }
            }
            return seisPontos;
        }

        public int par(Dado dado)
        {
            parPontos = 0;

            var dados = dado.Faces.GroupBy(x => x).Select(a => new { Item = a.Key, Quant = a.Count() }).ToArray();

            foreach (var a in dados)
            {
                if (a.Quant == 2)
                {
                    parPontos = a.Item * 2;
                    return parPontos;
                }
            }
            return parPontos;
        }

        public int doisPares(Dado dado, int par)
        {
            Boolean primeiraVez = true;
            doisParesPontos = 0;
            var dados = dado.Faces.GroupBy(x => x).Select(a => new { Item = a.Key, Quant = a.Count() }).ToArray();

            foreach (var a in dados)
            {
                if (a.Quant == 2)
                {
                    if (primeiraVez)
                    {
                        primeiraVez = false;
                        continue;
                    }

                    else
                    {
                        doisParesPontos = a.Item * 2 + par;
                        return doisParesPontos;
                    }
                }
            }
            return doisParesPontos;
        }

        public int trio(Dado dado)
        {
            trioPontos = 0;

            var dados = dado.Faces.GroupBy(x => x).Select(a => new { Item = a.Key, Quant = a.Count() }).ToArray();

            foreach (var a in dados)
            {
                if (a.Quant == 3)
                {
                    trioPontos = a.Item * 3;
                    return trioPontos;
                }
            }

            return trioPontos;
        }

        public int quadra(Dado dado)
        {
            quadraPontos = 0;

            var dados = dado.Faces.GroupBy(x => x).Select(a => new { Item = a.Key, Quant = a.Count() }).ToArray();

            foreach (var a in dados)
            {
                if (a.Quant == 4)
                {
                    quadraPontos = a.Item * 4;
                    return quadraPontos;
                }
            }

            return quadraPontos;
        }

        public int sequenciaMenor(Dado dado)
        {
            ordenarDado(dado);
            int[] numTeste1 = new int[4] { 1, 2, 3, 4 };
            int[] numTeste2 = new int[4] { 2, 3, 4, 5 };
            int[] numTeste3 = new int[4] { 3, 4, 5, 6 };
            sequenciaMenorPontos = 0;

            eliminarRepeticoes(dado);           

            if (dado.FaceSequencia.Length >= 4)
            {
                if (dado.FaceSequencia[0] == numTeste1[0] &&
                dado.FaceSequencia[1] == numTeste1[1] &&
                dado.FaceSequencia[2] == numTeste1[2] &&
                dado.FaceSequencia[3] == numTeste1[3])
                {
                    return sequenciaMenorPontos = 15;
                }

                else if (dado.FaceSequencia[1] == numTeste1[0] &&
                  dado.FaceSequencia[2] == numTeste1[1] &&
                  dado.FaceSequencia[3] == numTeste1[2] &&
                  dado.FaceSequencia[4] == numTeste1[3])
                {
                    return sequenciaMenorPontos = 15;
                }

                else if (dado.FaceSequencia[1] == numTeste2[0] &&
                  dado.FaceSequencia[2] == numTeste2[1] &&
                  dado.FaceSequencia[3] == numTeste2[2] &&
                  dado.FaceSequencia[4] == numTeste2[3])
                {
                    return sequenciaMenorPontos = 15;
                }             
           
                else if (dado.FaceSequencia[0] == numTeste2[0] &&
                    dado.FaceSequencia[1] == numTeste2[1] &&
                    dado.FaceSequencia[2] == numTeste2[2] &&
                    dado.FaceSequencia[3] == numTeste2[3])
                {
                    return sequenciaMenorPontos = 15;
                }
                else if (dado.FaceSequencia[0] == numTeste3[0] &&
                    dado.FaceSequencia[1] == numTeste3[1] &&
                    dado.FaceSequencia[2] == numTeste3[2] &&
                    dado.FaceSequencia[3] == numTeste3[3])
                {
                    return sequenciaMenorPontos = 15;
                }
            }
            return sequenciaMenorPontos;
        }

        public int sequenciaMaior(Dado dado)
        {
            ordenarDado(dado);
            int[] numTeste1 = new int[5] { 1, 2, 3, 4, 5 };
            int[] numTeste2 = new int[5] { 2, 3, 4, 5, 6 };
            sequenciaMaiorPontos = 0;

            eliminarRepeticoes(dado);
            
            if (dado.FaceSequencia.Length == 5)
            {
                if (dado.FaceSequencia[0] == numTeste1[0] &&
                    dado.FaceSequencia[1] == numTeste1[1] &&
                    dado.FaceSequencia[2] == numTeste1[2] &&
                    dado.FaceSequencia[3] == numTeste1[3] &&
                    dado.FaceSequencia[4] == numTeste1[4])
                {
                    return sequenciaMaiorPontos = 20;
                }

                else if (dado.FaceSequencia[0] == numTeste2[0] &&
                    dado.FaceSequencia[1] == numTeste2[1] &&
                    dado.FaceSequencia[2] == numTeste2[2] &&
                    dado.FaceSequencia[3] == numTeste2[3] &&
                    dado.FaceSequencia[4] == numTeste2[4])
                {
                    return sequenciaMaiorPontos = 20;
                }
            }
            return sequenciaMaiorPontos;
        }

        public string Jogada(Dado dado)
        {
            fullHouse(dado);
            aurora(dado);
            uns(dado);
            dois(dado);
            tres(dado);
            quatro(dado);
            cinco(dado);
            seis(dado);
            par(dado);
            doisPares(dado, par(dado));
            trio(dado);
            quadra(dado);
            sequenciaMaior(dado);
            sequenciaMenor(dado);

            int[] pontos = new int[] {
                fullHousePontos,
                auroraPontos,
                unsPontos,
                doisPontos,
                tresPontos,
                quatroPontos,
                cincoPontos,
                seisPontos,
                parPontos,
                doisParesPontos,
                trioPontos,
                quadraPontos,
                sequenciaMenorPontos,
                sequenciaMaiorPontos
            };

            Array.Sort(pontos);

            pontosTotal = pontos[13];

            if (pontos[13] == aurora(dado))
            {
                return "Aurora";
            }

            else if (pontos[13] == fullHouse(dado))
            {
                return "Full House";
            }

            else if (pontos[13] == sequenciaMaior(dado))
            {
                return "Sequência maior";
            }

            else if (pontos[13] == sequenciaMenor(dado))
            {
                return "Sequência menor";
            }

            else if (pontos[13] == quadra(dado))
            {
                return "quadra";
            }

            else if (pontos[13] == trio(dado))
            {
                return "trio";
            }

            else if (pontos[13] == doisPares(dado, par(dado)))
            {
                return "dois pares";
            }

            else if (pontos[13] == par(dado))
            {
                return "par";
            }

            else if (pontos[13] == seis(dado))
            {
                return "seis";
            }

            else if (pontos[13] == cinco(dado))
            {
                return "cinco";
            }

            else if (pontos[13] == quatro(dado))
            {
                return "quatro";
            }

            else if (pontos[13] == tres(dado))
            {
                return "três";
            }

            else if (pontos[13] == dois(dado))
            {
                return "dois";
            }

            else if (pontos[13] == uns(dado))
            {
                return "uns";
            }            
            return null;
        }
        
        private Dado eliminarRepeticoes(Dado dado)
        {
            dado.FaceSequencia = dado.FaceSequencia.Distinct().ToArray();
            return dado;
        }
    }
}
