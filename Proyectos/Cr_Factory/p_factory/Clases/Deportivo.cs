using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_factory.Interfaces;

namespace p_factory.Clases
{
    public class Deportivo:IAutomovil
    {
        public void MostrarDetalles()
        {
            Console.WriteLine("Esto es un Deportivo");
        }
    }
}