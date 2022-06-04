

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace LibreriaCarlos
{
    public class ClienteXUnitTest
    {
        private Cliente objCliente;

        public ClienteXUnitTest()
        {
            objCliente = new Cliente();
        }

        [Fact]
        public void CrearNombreCompleto_InputNombreApellido_ReturnNombreCompleto()
        {
            // arrange

            // act
            objCliente.CrearNombreCompleto("Carlos", "Flores");

            // assert
            Assert.Multiple(() =>
            {
                Assert.Equal("Carlos Flores", objCliente.StrClienteNombre);
                Assert.Contains("Carlos Flores", objCliente.StrClienteNombre);
                Assert.StartsWith("Carlo", objCliente.StrClienteNombre);
                Assert.EndsWith("res", objCliente.StrClienteNombre);
            });

        }

        [Fact]
        public void StrClienteNombre_NoValues_Returns_Null()
        {
            // arrange

            // act

            // assert
            Assert.Null(objCliente.StrClienteNombre);
        }

        [Fact]
        public void DescuentoEvaluacion_DefaultCliente_ReturnsIntervalo()
        {
            int descuento = objCliente.Descuento;
            Assert.InRange(descuento, 5, 24);
        }

        [Fact]
        public void CrearNombreCompleto_InputNombre_ReturnsNotNull()
        {
            // arrange


            // act
            objCliente.CrearNombreCompleto("Carlos", "");

            // assert
            Assert.NotNull(objCliente.StrClienteNombre);
            Assert.False(string.IsNullOrEmpty(objCliente.StrClienteNombre));

        }

        [Fact]
        public void ClienteNombre_InputNombreEnBlanco_ThrowException()
        {
            Assert.Multiple(() =>
            {
                var excepiconDetalle = Assert.Throws<ArgumentException>(() => objCliente.CrearNombreCompleto("", "Flores"));
                Assert.Equal("El nombre esta el blanco", excepiconDetalle.Message.ToString());

                // Compara el objeto Excepcion sin tomar en cuenta el mensaje
                Assert.Throws<ArgumentException>(() => objCliente.CrearNombreCompleto("", "Flores"));
            });
        }


        [Fact]
        public void GetClienteDetalle_CrearClienteConMenos500TotalOrder_ReturnsClienteBasico()
        {
            objCliente.OrderTotal = 150;
            var resultado = objCliente.GetClienteDetalle();

            Assert.IsType<ClienteBasico>(resultado);
        }

        [Fact]
        public void GetClienteDetalle_CrearClienteConMas500TotalOrder_ReturnsClienteBasico()
        {
            objCliente.OrderTotal = 600;
            var resultado = objCliente.GetClienteDetalle();

            Assert.IsType<ClientePremium>(resultado);
        }

    }
}
