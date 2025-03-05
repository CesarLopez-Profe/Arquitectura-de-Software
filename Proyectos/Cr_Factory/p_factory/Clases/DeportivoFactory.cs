using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_factory.Interfaces;

namespace p_factory.Clases
{
    public class DeportivoFactory:AutomovilFactory
    {
        public override IAutomovil CrearAutomovil()
        {
            return new Deportivo();
        }
    }
}