using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCarlos
{
    [TestFixture]
    public class OperacionNUnitTest
    {
        [Test]
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
            Assert.That(resultados, Is.EqualTo(99));
        }

        [Test]
        [TestCase(3, ExpectedResult = false)]
        [TestCase(5, ExpectedResult = false)]
        [TestCase(7, ExpectedResult = false)]
        [TestCase(9, ExpectedResult = false)]
        public bool IsValorPar_RetFalse(int intNumeroImpar)
        {
            //1.- Arrange
            Operacion op = new();

            //2.- Act
            return op.IsValorPar(intNumeroImpar);
        }

        [Test]
        [TestCase(4)]
        [TestCase(6)]
        [TestCase(20)]
        public void IsValorPar_InputNumeroPar_GetReturnTrue(int intNumeroPar)
        {
            //1.- Arrange
            Operacion op = new Operacion();

            //2.- Act
            bool isPar = op.IsValorPar(intNumeroPar);

            //3.- Assert
            Assert.IsTrue(isPar);
            //Assert.That(isPar, Is.EqualTo(true));


        }

        [Test]
        public void ReturnString_InputString_ReturnLowerString()
        {
            // Arrange
            Operacion objOperacion = new Operacion();
            string strNombre = "CaRloS";

            // Act
            string strResultado = objOperacion.ReturnString(strNombre);

            // Assert
            Assert.That(strResultado, Is.EqualTo("carlos"));
        }

        [Test]
        [TestCase(2.2, 1.2)] // 4
        [TestCase(2.23, 1.24)] // 3.47
        public void SumarDouble_InputTwoNumbers(double douNumero1, double douNumero2)
        {
            Operacion objOp = new();

            double resultado = objOp.SumarDouble(douNumero1, douNumero2);

            Assert.AreEqual(3.4, resultado, 0.1);

        }

        [Test]
        public void GetListaNumerosImpares_InputMinAndMax_ReturnsListaImpares()
        {
            // arrange
            Operacion objOperacion = new();
            List<int> lstNumeroImparesEsperados = new() { 5,7,9 };

            // act
            List<int> lstResultados = objOperacion.GetListaNumerosImpares(5, 10);

            // assert
            Assert.That(lstResultados, Is.EquivalentTo(lstNumeroImparesEsperados));
            Assert.AreEqual(lstNumeroImparesEsperados, lstResultados);
            Assert.That(lstResultados, Does.Contain(5));
            Assert.Contains(5, lstResultados);
            Assert.That(lstResultados, Is.Not.Empty);
            Assert.That(lstResultados.Count, Is.EqualTo(3));
            Assert.That(lstResultados, Has.No.Member(100));
            Assert.That(lstResultados, Is.Ordered.Ascending);
            Assert.That(lstResultados, Is.Unique);


        }
    }
}
