using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P_Repaso.Interfaces
{
    public interface IValidaConcesionario
    {
        bool ValidarDireccion(string direccion);
    }
}