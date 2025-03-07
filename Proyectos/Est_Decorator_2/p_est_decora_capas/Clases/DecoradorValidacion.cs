using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_est_decora_capas.Interfaces;

namespace p_est_decora_capas.Clases
{
    public class DecoradorValidacion:DecoradorPagos
    {
        public DecoradorValidacion(IProcesadorPagosBase procesador):base(procesador)
        {
        }

        public override void ProcesarPago(double monto)
        {
            if(monto > 0)
            {
                Console.WriteLine($"El monto a pagar es de: ${monto}");
                base.ProcesarPago(monto);
            }
            else
            {
                Console.WriteLine("El monto a pagar no es válido");
            }
        }
    
        
    }
}