using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_est_decora_capas.Interfaces;

namespace p_est_decora_capas.Clases
{
    public class DecoradorNotificacion:DecoradorPagos
    {
        public DecoradorNotificacion(IProcesadorPagosBase procesador):base(procesador)
        {
        }

        public override void ProcesarPago(double monto)
        {
            Console.WriteLine("Enviando notificación de pago");
            base.ProcesarPago(monto);
        }
    
    }
}