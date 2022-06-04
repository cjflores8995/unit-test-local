using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCarlos
{
    [TestFixture]
    public class ClienteNUnitTest
    {
        private Cliente objCliente;

        [SetUp]
        public void Setup()
        {
            objCliente = new Cliente();
        }

        [Test]
        public void CrearNombreCompleto_InputNombreApellido_ReturnNombreCompleto()
        {
            // arrange
         
            // act
            objCliente.CrearNombreCompleto("Carlos", "Flores");

            // assert
            Assert.Multiple(() =>
            {
                Assert.That(objCliente.StrClienteNombre, Is.EqualTo("Carlos Flores"));
                Assert.AreEqual(objCliente.StrClienteNombre, "Carlos Flores");
                Assert.That(objCliente.StrClienteNombre, Does.Contain("Car"));
                Assert.That(objCliente.StrClienteNombre, Does.Contain("car").IgnoreCase);
                Assert.That(objCliente.StrClienteNombre, Does.StartWith("Carlo"));
                Assert.That(objCliente.StrClienteNombre, Does.EndWith("res"));
            });
            
        }

        [Test]
        public void StrClienteNombre_NoValues_Returns_Null()
        {
            // arrange

            // act

            // assert
            Assert.IsNull(objCliente.StrClienteNombre);
        }

        [Test]
        public void DescuentoEvaluacion_DefaultCliente_ReturnsIntervalo()
        {
            int descuento = objCliente.Descuento;
            Assert.That(descuento, Is.InRange(5, 24));
        }

        [Test]
        public void CrearNombreCompleto_InputNombre_ReturnsNotNull()
        {
            // arrange


            // act
            objCliente.CrearNombreCompleto("Carlos", "");

            // assert
            Assert.IsNotNull(objCliente.StrClienteNombre);
            Assert.IsFalse(string.IsNullOrEmpty(objCliente.StrClienteNombre));

        }

        [Test]
        public void ClienteNombre_InputNombreEnBlanco_ThrowException()
        {
            Assert.Multiple(() =>
            {
                var excepiconDetalle = Assert.Throws<ArgumentException>(() => objCliente.CrearNombreCompleto("", "Flores"));
                Assert.AreEqual("El nombre esta el blanco", excepiconDetalle.Message.ToString());

                Assert.That(
                    () => 
                    objCliente.CrearNombreCompleto("", "Flores"), 
                    Throws.ArgumentException.With.Message.EqualTo("El nombre esta el blanco")
                );

                // Compara el objeto Excepcion sin tomar en cuenta el mensaje
                Assert.Throws<ArgumentException>(() => objCliente.CrearNombreCompleto("", "Flores"));
                Assert.That(
                    () =>
                    objCliente.CrearNombreCompleto("", "Flores"), Throws.ArgumentException
                );
            });

        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void GetClienteDetalle_CrearClienteConMenos500TotalOrder_ReturnsClienteBasico()
        {
            objCliente.OrderTotal = 150;
            var resultado = objCliente.GetClienteDetalle();

            Assert.That(resultado, Is.TypeOf<ClienteBasico>());
        }

        [Test]
        public void GetClienteDetalle_CrearClienteConMas500TotalOrder_ReturnsClienteBasico()
        {
            objCliente.OrderTotal = 600;
            var resultado = objCliente.GetClienteDetalle();

            Assert.That(resultado, Is.TypeOf<ClientePremium>());
        }

    }
}
