using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p_est_flyweight.Clases
{
    public class AutoFlyweightFactory
    {
        // El diccionario almacena las instancias de los objetos reutilizables
        private Dictionary<string, AutoFlyweight> d_autos = new Dictionary<string, AutoFlyweight>();

        public AutoFlyweight BuscarAuto(string marca, string modelo, string motor)
        {
            string key = $"{marca}_{modelo}_{motor}";

            if (!d_autos.ContainsKey(key)) //Si no lo encuentra, lo crea
            {
                d_autos[key] = new AutoFlyweight(marca, modelo, motor);
                Console.WriteLine($"Creando nuevo flyweight for: {marca} {modelo} {motor}");
            }

            return d_autos[key];
        }
    }
}   
