using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p_builder_design.Clases
{
    public class Pizza //Producto
    {
    
        public string masa { get; set; }
        public string salsa { get; set; }
        public List<string> l_ingredientes { get; set; } = new List<string>();

        public void MostrarPizzaLista()
        {
            Console.WriteLine("Pizza preparada con:");
            Console.WriteLine($"- Masa: {masa}");
            Console.WriteLine($"- Salsa: {salsa}");
            Console.WriteLine($"- Ingredientes: {string.Join(", ", l_ingredientes)}");
            Console.WriteLine("---------------");
        }

    }
}