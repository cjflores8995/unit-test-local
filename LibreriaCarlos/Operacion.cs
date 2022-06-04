namespace LibreriaCarlos
{
    public class Operacion
    {
        public List<int> LstNumerosImpares = new List<int>();

        public int SumarNumeros(int numero1, int numero2)
        {
            return numero1 + numero2;
        }

        public bool IsValorPar(int numero)
        {
            return numero % 2 == 0;
        }

        public string ReturnString(string strString)
        {
            return strString.ToLower();
        }

        public double SumarDouble(double douNumero1, double douNumero2)
        {
            return douNumero1 + douNumero2;
        }

        public List<int> GetListaNumerosImpares(int intIntervaloMinimo, int intIntervaloMaximo)
        {
            LstNumerosImpares.Clear();

            for(int i = intIntervaloMinimo; i<= intIntervaloMaximo; i++)
            {
                if(i % 2 != 0)
                {
                    LstNumerosImpares.Add(i);
                }
            }

            return LstNumerosImpares;
        }
    }
}