using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace LibreriaCarlos
{
    public class OperacionXUnitTest
    {
        [Fact]
        public void SumarNumeros_InputDosNumeros_GetValorCorrecto()
        {
            //1. arrange
            ////Inicializar las variables o componentes que ejecutan el test
            Operacion op = new Operacion();
            int numero1Tst = 50;
            int numero2Test = 49;

            //2. act
            ////Ejecucion de la operacion
            int resultados = op.SumarNumeros(numero1Tst, numero2Test);

            //3. assert
            ////Validar el resultado obtenido
            Assert.Equal(99, resultados);
        }

        [Theory]
        [InlineData(3, false)]
        [InlineData(5, false)]
        [InlineData(7, false)]
        [InlineData(9, false)]
        public void IsValorPar_RetFalse(int intNumeroImpar, bool expectedResult)
        {
            //1.- Arrange
            Operacion op = new();
            var resultado = op.IsValorPar(intNumeroImpar);

            //2.- Act
            Assert.Equal(expectedResult, resultado);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(20)]
        public void IsValorPar_InputNumeroPar_GetReturnTrue(int intNumeroPar)
        {
            //1.- Arrange
            Operacion op = new Operacion();

            //2.- Act
            bool isPar = op.IsValorPar(intNumeroPar);

            //3.- Assert
            Assert.True(isPar);
            //Assert.That(isPar, Is.EqualTo(true));


        }

        [Fact]
        public void ReturnString_InputString_ReturnLowerString()
        {
            // Arrange
            Operacion objOperacion = new Operacion();
            string strNombre = "CaRloS";

            // Act
            string strResultado = objOperacion.ReturnString(strNombre);

            // Assert
            Assert.Equal("carlos", strResultado);
        }

        [Theory]
        [InlineData(2.2, 1.2)] // 4
        [InlineData(2.23, 1.24)] // 3.47
        public void SumarDouble_InputTwoNumbers(double douNumero1, double douNumero2)
        {
            Operacion objOp = new();

            double resultado = objOp.SumarDouble(douNumero1, douNumero2);

            Assert.Equal(3.4, resultado, 0.1);

        }

        [Fact]
        public void GetListaNumerosImpares_InputMinAndMax_ReturnsListaImpares()
        {
            // arrange
            Operacion objOperacion = new();
            List<int> lstNumeroImparesEsperados = new() { 5, 7, 9 };

            // act
            List<int> lstResultados = objOperacion.GetListaNumerosImpares(5, 10);

            // assert
            Assert.Equal(lstNumeroImparesEsperados, lstResultados);

            Assert.Contains(5, lstResultados);

            // saber si no esta vacia
            Assert.NotEmpty(lstResultados);

            // cantidad de elementos
            Assert.Equal(3, lstResultados.Count);

            // si un elemento no pertenece
            Assert.DoesNotContain(100, lstResultados);

            // si la coleccion es ordenada
            Assert.Equal(lstResultados.OrderBy(u => u), lstResultados);



        }
    }
}
