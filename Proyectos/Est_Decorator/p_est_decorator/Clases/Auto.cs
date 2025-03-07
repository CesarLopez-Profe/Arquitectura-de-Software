using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_est_decorator.Interfaces;

namespace p_est_decorator.Clases
{
    public class Auto:IAuto
    {
        public string ObtenerDescripcion()
        {
            return "Auto Pelado";
        }

        public uint  ObtenerCosto()
        {
            return 150000000;
        }



    }
}