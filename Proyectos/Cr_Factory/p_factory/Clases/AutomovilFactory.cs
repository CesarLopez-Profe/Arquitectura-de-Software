using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_factory.Interfaces;

namespace p_factory.Clases
{
    public abstract class AutomovilFactory
    {
        public abstract IAutomovil CrearAutomovil();
    }
}