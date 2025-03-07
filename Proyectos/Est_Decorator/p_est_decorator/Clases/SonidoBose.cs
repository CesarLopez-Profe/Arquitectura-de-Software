using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_est_decorator.Interfaces;

namespace p_est_decorator.Clases
{
    public class SonidoBose:DecoradorAuto 
    {
        public SonidoBose(IAuto auto):base(auto)
        {
        
        }

        public override string ObtenerDescripcion()
        {
            return auto.ObtenerDescripcion() + ", con Sonido Bose";
        }

        public override uint ObtenerCosto()
        {
            return auto.ObtenerCosto() + ListaPrecio.sonido_bose;
        }       
    
        
    }
}