using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_estr_bridge.Interfaces;

namespace p_estr_bridge.Clases
{
    public class Gasolina:IMotor 
    {
        public void Encender()
        {
            Console.WriteLine("Motor de gasolina encendido.");
        }

    public void Acelerar()
        {
            Console.WriteLine("Acelerando con motor de gasolina.");
        }
    }
}