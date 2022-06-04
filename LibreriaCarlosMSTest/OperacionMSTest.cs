using LibreriaCarlos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCarlosMSTest
{
    [TestClass]
    public class OperacionMSTest
    {
        [TestMethod]
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
            Assert.AreEqual(99, resultados);
        }

    }
}
