using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_est_decora_capas.Interfaces;

namespace p_est_decora_capas.Clases
{
    public class ProcesadorPagosBase:IProcesadorPagosBase
    {
        public void ProcesarPago(double monto)
        {
            Console.WriteLine($"Procesando pago por un monto de: ${monto}");
        }
    }
}