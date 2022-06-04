using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCarlos
{
    [TestFixture]
    public class ProductoNUnitTests
    {
        [Test]
        public void GetPrecio_PremiumCliente_ReturnsPrecio80()
        {
            // arrange
            Producto producto = new Producto { Precio = 50};
            Cliente cliente = new Cliente { IsPremium = true };

            //act
            var resultado = producto.GetPrecio(cliente);

            // assert
            Assert.That(resultado, Is.EqualTo(40));

        }

        [Test]
        public void GetPrecio_PremiumClienteMoq_ReturnsPrecio80()
        {
            // arrange
            Producto producto = new Producto { Precio = 50 };
                     var cliente = new Mock<ICliente>();
            cliente.Setup(s => s.IsPremium).Returns(true);

            //act
            var resultado = producto.GetPrecio(cliente.Object);

            // assert
            Assert.That(resultado, Is.EqualTo(40));

        }
    }
}
