using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace p_estr_composite_caja.Clases
{
    public class Caja:IItem
    {
        public string dimension;
        public decimal precio;

        public List<IItem> contenido { get; set; } = new List<IItem>();

        public Caja(string dimension, decimal precio)
        {
            this.dimension = dimension;
            this.precio = precio;
        }

        public void AgregarItem(IItem item) => contenido.Add(item);

        public decimal ObtenerPrecio() 
        {
            return precio + contenido.Sum(item => item.ObtenerPrecio());
        }
        

    }
}