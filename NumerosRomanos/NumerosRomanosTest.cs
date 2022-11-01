using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NumerosRomanos
{
    public class NumerosRomanosTest
    {
        [TestCase("I", 1)]
        [TestCase("V", 5)]
        [TestCase("X", 10)]
        [TestCase("L", 50)]
        [TestCase("C", 100)]
        [TestCase("D", 500)]
        [TestCase("M", 1000)]
        [TestCase("III", 3)]
        [TestCase("LVIII", 58)]
        [TestCase("MCMXCIV", 1994)]
        public void Teste(string numeroRomano, int numeroInteiroEsperado)
        {
            //Arrange

            //Act
            var resultado = NumeroRomanoParaInteiro(numeroRomano);

            //Assert
            Assert.AreEqual(numeroInteiroEsperado, resultado);
        }

        /*
        Numeros romanos s�o repreentados por 7 diferentes simbolos: I, V, X, L, C, D e M.

        Simbolo     ValorValue
        I            1
        V            5
        X            10
        L            50
        C            100
        D            500
        M            1000

        Por exemplo, 2 � escrito II em romando, apenas dois 1's e somam-se. 12 � escrito XII, onde � simplesmente X(10) + II(2).
        O n�mero 27 � escrito XXVII, onde XX(20) + V(5) + II(2)
        
        Numeros romanos s�o geralmente escritos do mais alto para o mais baixo da esquerda para a direita
        Por�m o n�mero 4 n�o � IIII, e sim IV. Desta maneira, o I(1) � menor que V(5), o que gera 5-1, que � 4

        O mesmo princ�pio se aplica ao n�mero 9, que � escrito IX
        
        H� seis intancias onde a subtra��o � usada:
            I pode ser colocado antes de um V (5) e X (10) para gerar 4 e 9. 
            X pode ser colocado antes de um L (50) e C (100) para gerar 40 e 90. 
            C pode ser colocado antes de um D (500) e M (1000) para gerar 400 e 900.
            
        Visto isto, crie um m�todo que converta um numero romano num inteiro

            Exemplo 1:
            Input: s = "III"
            Output: 3
            Explica��o: III = 3.

            Exemplo 2:
            Input: s = "LVIII"
            Output: 58
            Explica��o: L = 50, V= 5, III = 3.

            Exemplo 3:
            Input: s = "MCMXCIV"
            Output: 1994
            Explica��o: M = 1000, CM = 900, XC = 90 and IV = 4. 

        Restri��es:
            O tamanho do n�mero romano enviado 1 <= s.length <= 15
            s cont�m apenas os caracteres a seguir ('I', 'V', 'X', 'L', 'C', 'D', 'M').
            � garantido que somente ser�o enviados n�meros romanos no seguinte intervalo [1, 3999].
        */
        private int NumeroRomanoParaInteiro(string numeroRomano)
        {
            int sum = 0;
            Dictionary<char, int> dicionarioRomanoInteiro = new Dictionary<char, int>()
            {
                {'I', 1 },
                {'V', 5 },
                {'X', 10 },
                {'L', 50 },
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };
            for(int i = 0; i < numeroRomano.Length; i++)
            {
                char romanoAtual = numeroRomano[i];
                dicionarioRomanoInteiro.TryGetValue(romanoAtual, out int num);
                if(i + 1 < numeroRomano.Length && dicionarioRomanoInteiro[numeroRomano[i + 1]] > dicionarioRomanoInteiro[romanoAtual])
                {
                    sum -= num;
                }
                else
                {
                    sum += num;
                }
            }
            return sum;

            throw new NotImplementedException();
        }
    }
}