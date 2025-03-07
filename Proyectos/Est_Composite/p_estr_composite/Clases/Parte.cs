using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_estr_composite.Interfaces;

namespace p_estr_composite.Clases
{
    public class Parte: IComponenteAuto // Implementación de una parte individual del auto
    {
        private string _nombre;

        public Parte(string nombre)
        {
            _nombre = nombre;
        }

        public void MostrarDetalles()
        {
            Console.WriteLine($"Parte: {_nombre}");
        }
    
        
    }
}