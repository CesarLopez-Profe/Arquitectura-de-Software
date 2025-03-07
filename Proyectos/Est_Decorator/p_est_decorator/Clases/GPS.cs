using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_est_decorator.Interfaces;

namespace p_est_decorator.Clases
{
    public class GPS:DecoradorAuto 
    {
        public GPS(IAuto auto):base(auto)
        {
        
        }

        public override string ObtenerDescripcion()
        {
            return auto.ObtenerDescripcion() + ", con GPS";
        }

        public override uint ObtenerCosto()
        {
            return auto.ObtenerCosto() + ListaPrecio.gps;
        }       
    }
}