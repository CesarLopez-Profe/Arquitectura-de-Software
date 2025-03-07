using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_est_decora_capas.Interfaces;

namespace p_est_decora_capas.Clases
{
    public abstract class DecoradorPagos:IProcesadorPagosBase
    //Esta clase base permite que cualquier decorador se "envuelva" alrededor de otro IProcesadorPagosBase
    {
        protected IProcesadorPagosBase procesadorWrapper; 

        public DecoradorPagos(IProcesadorPagosBase procesador)
        {
            procesadorWrapper = procesador;
        }

        public virtual void ProcesarPago(double monto)
        {
            procesadorWrapper.ProcesarPago(monto);
        }
        
    }
}