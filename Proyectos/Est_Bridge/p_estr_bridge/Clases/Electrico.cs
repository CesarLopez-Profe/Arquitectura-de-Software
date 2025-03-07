using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_estr_bridge.Interfaces;

namespace p_estr_bridge.Clases
{
    public class Electrico:IMotor 
    {
        public void Encender()
        {
            Console.WriteLine("Motor eléctrico encendido.");
        }

    public void Acelerar()
        {
            Console.WriteLine("Acelerando con motor eléctrico.");
        }
    
        
    }
}