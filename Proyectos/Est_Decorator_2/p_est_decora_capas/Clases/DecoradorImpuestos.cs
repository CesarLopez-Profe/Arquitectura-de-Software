using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_est_decora_capas.Interfaces;

namespace p_est_decora_capas.Clases
{
    public class DecoradorImpuestos:DecoradorPagos
    {
        public DecoradorImpuestos(IProcesadorPagosBase procesador):base(procesador)
        {
        }

        public override void ProcesarPago(double monto)
        {
            double impuesto = monto * Informacion.val_impto;
            Console.WriteLine($"El impuesto a pagar es de: ${impuesto}");
            base.ProcesarPago(monto + impuesto);
        }
    
        
    }
}