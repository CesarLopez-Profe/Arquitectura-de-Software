using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_est_decorator.Interfaces;

namespace p_est_decorator.Clases
{
    public class SillaCuero:DecoradorAuto
    {
        public SillaCuero(IAuto auto):base(auto)
        {
        
        }

        public override string ObtenerDescripcion()
        {
            return auto.ObtenerDescripcion() + ", con sillas de cuero";
        }

        public override uint ObtenerCosto()
        {
            return auto.ObtenerCosto() + ListaPrecio.silla_cuero;
        }       
    
        
    }
}