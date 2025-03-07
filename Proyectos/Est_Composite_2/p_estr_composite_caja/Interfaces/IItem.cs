using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p_estr_composite_caja
{
    public interface IItem //Representa cualquier objeto que tenga un precio (Producto y Caja implementan esta interfaz).
    {
        decimal ObtenerPrecio();
        //float ObtenerPeso();
    }

    

}