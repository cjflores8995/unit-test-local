using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCarlos
{
    public interface ILoggerGeneral
    {
        public int PrioridadLogger { get; set; }
        public string TipoLogger { get; set; }

        void Message(string message);
        bool LogDatabase(string message);
        bool LogBalanceDespuesRetiro(int balanceDespuesRetiro);

        string MessageConReturnString(string message);
        bool MessageConOutParametroReturnBoolean(string str, out string outputStr);
        bool MessageConObjetoReferenciaParametroReturnBoolean(ref Cliente cliente);
    }

    public class LoggerGeneral : ILoggerGeneral
    {
        public int PrioridadLogger { get; set; }
        public string TipoLogger { get; set; }

        public bool LogBalanceDespuesRetiro(int balanceDespuesRetiro)
        {
            if(balanceDespuesRetiro >= 0)
            {
                Console.WriteLine("exito");
                return true;
            }
            else
            {
                Console.WriteLine("error");
                return false;
            }
        }

        public bool LogDatabase(string message)
        {
            Console.WriteLine(message);

            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public bool MessageConObjetoReferenciaParametroReturnBoolean(ref Cliente cliente)
        {
            return true;
        }

        public bool MessageConOutParametroReturnBoolean(string str, out string outputStr)
        {
            outputStr = "Hola" + str;

            return true;
        }

        public string MessageConReturnString(string message)
        {
            Console.WriteLine(message);

            return message.ToLower();
        }
    }

    public class LoggerFake : ILoggerGeneral
    {
        public int PrioridadLogger { get; set; }
        public string TipoLogger { get; set; }

        public bool LogBalanceDespuesRetiro(int balanceDespuesRetiro)
        {
            throw new NotImplementedException();
        }

        public bool LogDatabase(string message)
        {
            throw new NotImplementedException();
        }

        public void Message(string message)
        {
            
        }

        public bool MessageConObjetoReferenciaParametroReturnBoolean(ref Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public bool MessageConOutParametroReturnBoolean(string str, out string outputStr)
        {
            throw new NotImplementedException();
        }

        public string MessageConReturnString(string message)
        {
            return message;
        }
    }
}
