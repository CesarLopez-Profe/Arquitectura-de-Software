using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p_est_decora_capas.Interfaces
{
    public interface IProcesadorPagosBase
    {
        void ProcesarPago(double monto);
    }
}