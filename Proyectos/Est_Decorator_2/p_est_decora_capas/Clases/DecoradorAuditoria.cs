using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_est_decora_capas.Interfaces;

namespace p_est_decora_capas.Clases
{
    public class DecoradorAuditoria:DecoradorPagos
    {
        public DecoradorAuditoria(IProcesadorPagosBase procesador):base(procesador)
        {
        }

        public override void ProcesarPago(double monto)
        {
            Console.WriteLine($"El monto a pagar es de: ${monto}");
            base.ProcesarPago(monto);
            Console.WriteLine("Se ha procesado el pago");
        }
    
        
    
        
    }
}