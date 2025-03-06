using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_prototype.Interfaces;

namespace p_prototype.Clases
{
public class Articulo : IPrototype<Articulo>
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        public Articulo(string nombre, decimal precio, int cantidad)
        {
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }

        public Articulo Clone()
        {
            return new Articulo(Nombre, Precio, Cantidad); // Clonación profunda
        }

        public override string ToString()
        {
            return $"Artículo: {Nombre}, Precio: {Precio:C}, Cantidad: {Cantidad}, Total: {Precio * Cantidad:C}";
        }
    }
}