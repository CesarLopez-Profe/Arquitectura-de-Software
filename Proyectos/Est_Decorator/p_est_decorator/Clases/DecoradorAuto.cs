using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_est_decorator.Interfaces;

namespace p_est_decorator.Clases
{
    public abstract class DecoradorAuto:IAuto
    {
        protected IAuto auto;
        public DecoradorAuto(IAuto auto)
        {
            this.auto = auto;
        }

        public virtual string ObtenerDescripcion()
        {
            return auto.ObtenerDescripcion();
        }

        public virtual uint ObtenerCosto()
        {
            return auto.ObtenerCosto();
        }
    }
}