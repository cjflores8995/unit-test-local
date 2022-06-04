using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCarlos
{
    public class CuentaBancaria
    {
        public int balance { get; set; }
        private readonly ILoggerGeneral _loggerGeneral;
        public CuentaBancaria(ILoggerGeneral loggerGeneral)
        {
            _loggerGeneral = loggerGeneral;
            balance = 0;
        }

        public bool Deposito(int monto)
        {
            _loggerGeneral.Message($"Esta depositando la cantidad de: {monto}");
            _loggerGeneral.Message($"Es otro texto");
            _loggerGeneral.Message($"Visita a Carlos");
            _loggerGeneral.PrioridadLogger = 100;
            var prioridad = _loggerGeneral.PrioridadLogger;

            balance += monto;
            return true;
        }

        public bool Retiro(int monto)
        {
            if(monto <= balance)
            {
                _loggerGeneral.LogDatabase("monto de retiro: " + monto.ToString());
                balance -= monto;
                return _loggerGeneral.LogBalanceDespuesRetiro(balance);
            }

            return _loggerGeneral.LogBalanceDespuesRetiro(balance-monto);
        }

        public  int GetBalance()
        {
            _loggerGeneral.Message($"El saldo actual de la cuenta es de: {balance}");
            return balance;
        }
    }
}
