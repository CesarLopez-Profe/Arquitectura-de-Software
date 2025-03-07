using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_estr_bridge.Interfaces;

namespace p_estr_bridge.Clases
{
    public abstract class Auto
    {
        protected IMotor motor;

        public Auto(IMotor motor)
        {
            this.motor = motor;
        }

        public abstract void Conducir();
    }
}