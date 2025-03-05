using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_abstract_factory.Interfaces;

namespace p_abstract_factory.Clases
{
    public class CarroceriaGasolina:ICarroceria 
    {
        public void Ensamblar()
        {
            Console.WriteLine("Carroceria Gasolina ensamblado");
        }
    }
    
}