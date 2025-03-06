using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_prototype.Interfaces;

namespace p_prototype.Clases
{
public class Factura : IPrototype<Factura>
    {
        public Cliente Cliente { get; set; }
        public List<Articulo> Articulos { get; set; }
        public DateTime Fecha { get; set; }

        public Factura(Cliente cliente, List<Articulo> articulos)
        {
            Cliente = cliente;
            Articulos = articulos;
            Fecha = DateTime.Now;
        }

        public Factura Clone()
        {
            /*Clonación superficial, no clona la estructura solo bit a bit 
            return new Factura(Cliente, Articulos, Fecha)
            */


            // Clonamos el Cliente y los Artículos para evitar referencias compartidas
            // Clonación profunda
            return new Factura(Cliente.Clone(), new List<Articulo>(Articulos.ConvertAll(a => a.Clone())))
            {
                Fecha = this.Fecha
            };
        }

        public override string ToString()
        {
            string facturaInfo = $"📄 Factura - Fecha: {Fecha}\n{Cliente}\n";
            foreach (var articulo in Articulos)
            {
                facturaInfo += $"{articulo}\n";
            }
            facturaInfo += $"Total a Pagar: {CalcularTotal():C}";
            return facturaInfo;
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var articulo in Articulos)
            {
                total += articulo.Precio * articulo.Cantidad;
            }
            return total;
        }
    }
}