using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p_estr_composite_caja.Clases
{
    public class Pedido
    {
        public List<IItem> l_items = new List<IItem>();

        public void AgregarItem(IItem item) => l_items.Add(item);

        public decimal ObtenerTotal()
        {
            return l_items.Sum(item => item.ObtenerPrecio());
        }

        

    }
}