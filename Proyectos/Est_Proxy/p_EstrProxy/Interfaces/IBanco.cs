using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p_EstrProxy.Interfaces
{
    public interface IBanco
    {
        void RetirarDinero(string usuario, int cantidad);
    }
}