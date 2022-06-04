using LibreriaCarlos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCarlosMSTest
{
    [TestClass]
    public class OperacionMSTest2
    {
        public void SumarNumeros_InputTwoNumbers_CorrectResult()
        {
            // Arrange
            Operacion objOperacion = new Operacion();
            int intNumero1 = 50;
            int intNumero2 = 50;

            // Act
            int intResultado = objOperacion.SumarNumeros(intNumero1, intNumero2);

            // Assert
            Assert.AreEqual(100, intResultado);
        }
    }
}
