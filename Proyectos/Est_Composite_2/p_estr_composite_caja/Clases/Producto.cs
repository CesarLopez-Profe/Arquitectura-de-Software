using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p_estr_composite_caja.Clases
{
    public class Producto: IItem
    {
        public string nombre;
        public decimal precio;

        public Producto(string nombre, decimal precio)
        {
            this.nombre = nombre;
            this.precio = precio;
        }

        public decimal ObtenerPrecio()
        {
            return precio;
        }


    }
}