using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p_est_flyweight.Clases
{
    public class AutoFlyweight
    {
        public string marca { get; }
        public string modelo { get; }
        public string motor { get; }


        public AutoFlyweight(string _marca, string _modelo, string _motor)
        {
            marca = _marca;
            modelo = _modelo;
            motor = _motor;
        }

        public void MostrarDetalles(string color, string nro_chasis)
        {
            Console.WriteLine($"Detalles del Auto: {marca} {modelo}, Motor: {motor}, Color: {color}, Número Chasis: {nro_chasis}");
        }

    }
}