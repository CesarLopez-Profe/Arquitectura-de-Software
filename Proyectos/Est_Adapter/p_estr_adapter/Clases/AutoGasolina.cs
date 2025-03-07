using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_estr_adapter.Interfaces;

namespace p_estr_adapter.Clases
{
    public class AutoGasolina:IAutoGasolina
    {
        public void EncenderMotor()
        {
        Console.WriteLine("Motor de gasolina encendido.");
         }

    public void Acelerar()
        {
        Console.WriteLine("Acelerando auto de gasolina.");
        }
    }
}