using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_estr_bridge.Interfaces;

namespace p_estr_bridge.Clases
{
    public class Sedan:Auto
    {
        public Sedan(IMotor motor) : base(motor) { }

        public override void Conducir()
        {
            Console.WriteLine("Conduciendo un sedán...");
            motor.Encender();
            motor.Acelerar();
        }
    }
}