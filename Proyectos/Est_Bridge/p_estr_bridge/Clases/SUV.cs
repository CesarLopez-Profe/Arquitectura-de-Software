using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_estr_bridge.Interfaces;

namespace p_estr_bridge.Clases
{
    public class SUV:Auto
    {
        public SUV(IMotor motor) : base(motor) { }

        public override void Conducir()
        {
            Console.WriteLine("Conduciendo un SUV...");
            motor.Encender();
            motor.Acelerar();
        }
    }
}