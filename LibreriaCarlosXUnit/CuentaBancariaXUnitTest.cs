using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace LibreriaCarlos
{
    public class CuentaBancariaXUnitTest
    {
        private CuentaBancaria cuenta;

        [Fact]
        public void Deposito_InputMonto100LoggerFake_ReturnsTrue()
        {
            CuentaBancaria cuentaBancaria = new CuentaBancaria(new LoggerFake());

            var resultado = cuentaBancaria.Deposito(100);
            Assert.True(resultado);
            Assert.Equal(100, cuentaBancaria.GetBalance());
        }

        [Fact]
        public void Deposito_InputMonto100Mocking_ReturnsTrue()
        {
            var mocking = new Mock<ILoggerGeneral>();


            CuentaBancaria cuentaBancaria = new CuentaBancaria(mocking.Object);

            var resultado = cuentaBancaria.Deposito(100);
            Assert.True(resultado);
            Assert.Equal(100, cuentaBancaria.GetBalance());
        }

        [Theory]
        [InlineData(200, 100)]
        [InlineData(200, 150)]
        public void Retiro_Retiro_100_Balance_200_Returns_True(int balance, int retiro)
        {
            var loggerMock = new Mock<ILoggerGeneral>();

            //seteo que el LogDatabase recibe un string
            loggerMock.Setup(x => x.LogDatabase(It.IsAny<string>())).Returns(true);

            // se pasa el saldo en valor entero y debe debolver true
            loggerMock.Setup(x => x.LogBalanceDespuesRetiro(It.Is<int>(x => x > 0))).Returns(true);

            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerMock.Object);
            cuentaBancaria.Deposito(balance);

            var resultado = cuentaBancaria.Retiro(retiro);

            Assert.True(resultado);

        }

        [Theory]
        [InlineData(200, 300)]
        public void Retiro_Retiro_300_Balance_200_Returns_False(int balance, int retiro)
        {
            var loggerMock = new Mock<ILoggerGeneral>();

            // se pasa el saldo en valor entero y debe debolver true
            //loggerMock.Setup(x => x.LogBalanceDespuesRetiro(It.Is<int>(x => x < 0))).Returns(false);
            loggerMock.Setup(x => x.LogBalanceDespuesRetiro(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerMock.Object);
            cuentaBancaria.Deposito(balance);

            var resultado = cuentaBancaria.Retiro(retiro);

            Assert.False(resultado);

        }

        [Fact]
        public void CuentaBancariaLoggerGeneral_LogMocking_ReturnTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            string textoPrueba = "hola mundo";

            loggerGeneralMock
                .Setup(x => x.MessageConReturnString(It.IsAny<string>()))
                .Returns<string>(str => str.ToLower());

            var resultado = loggerGeneralMock.Object.MessageConReturnString("hola muNdO");

            Assert.Equal(textoPrueba, resultado);
        }

        [Fact]
        public void CuentaBancariaLoggerGeneral_LogMocking_OutputParameter_Returns_True()
        {
            // arrange
            var loggerGeneral = new Mock<ILoggerGeneral>();
            string textoPrueba = "hola";

            loggerGeneral.Setup(x => x.MessageConOutParametroReturnBoolean(It.IsAny<string>(), out textoPrueba)).Returns(true);

            // act
            string parametroOut = "";
            var resultado = loggerGeneral.Object.MessageConOutParametroReturnBoolean("Carlos", out parametroOut);

            // assert
            Assert.True(resultado);
        }

        [Fact]
        public void CuentaBancariaLoggerGeneral_LogMockingObjetoRef_ReturnTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();

            Cliente cliente = new();
            Cliente clienteNoUsado = new();

            loggerGeneralMock
                .Setup(x => x.MessageConObjetoReferenciaParametroReturnBoolean(ref cliente))
                .Returns(true);

            Assert.True(loggerGeneralMock.Object.MessageConObjetoReferenciaParametroReturnBoolean(ref cliente));
            Assert.False(loggerGeneralMock.Object.MessageConObjetoReferenciaParametroReturnBoolean(ref clienteNoUsado));
        }

        [Fact]
        public void CuentaBancaria_LoggerGeneral_LogMockingPropiedadPrioridadTipo_ReturnsTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();

            loggerGeneralMock.Setup(x => x.TipoLogger).Returns("warning");
            loggerGeneralMock.Setup(x => x.PrioridadLogger).Returns(10);

            Assert.Equal("warning", loggerGeneralMock.Object.TipoLogger);
            Assert.Equal(10, loggerGeneralMock.Object.PrioridadLogger);

            // CALLBACKS
            int contador = 5;

            loggerGeneralMock
                .Setup(x => x.LogDatabase(It.IsAny<string>()))
                .Returns(true).Callback(() => contador++);

            loggerGeneralMock.Object.LogDatabase("flores"); // carlosflores

            Assert.Equal(6, contador);

        }

        [Fact]
        public void CuentaBancariaLogger_VerifyEjemplo()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();

            CuentaBancaria cuentaBancaria = new(loggerGeneralMock.Object);
            cuentaBancaria.Deposito(100);

            Assert.Equal(100, cuentaBancaria.GetBalance());

            // Verifica cuantas veces el mock esta llamando al metodo .message
            loggerGeneralMock.Verify(x => x.Message(It.IsAny<string>()), Times.Exactly(4));
            loggerGeneralMock.Verify(x => x.Message("Visita a Carlos"), Times.AtLeastOnce);
            loggerGeneralMock.VerifySet(x => x.PrioridadLogger = 100, Times.Once);

            loggerGeneralMock.VerifyGet(x => x.PrioridadLogger, Times.Once);
        }
    }
}
