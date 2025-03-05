using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_abstract_factory.Interfaces;

namespace p_abstract_factory.Clases
{
    public class MotorElectrico:IMotor  
    {
        public void Instalar()  
        {
            Console.WriteLine("Motor Electrico instalado");
        }
    }
    
}