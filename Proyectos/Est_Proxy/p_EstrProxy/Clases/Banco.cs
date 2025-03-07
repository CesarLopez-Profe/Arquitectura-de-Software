using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_EstrProxy.Interfaces;

namespace p_EstrProxy.Clases
{
    public class Banco:IBanco
    {
        public void RetirarDinero(string usuario, int cantidad)
        {
            Console.WriteLine($"{usuario} ha retirado ${cantidad}.");
        }   
    }
}