using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_prototype.Interfaces;

namespace p_prototype.Clases
{
    public class Cliente : IPrototype<Cliente>
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public Cliente(string nombre, string direccion)
        {
            Nombre = nombre;
            Direccion = direccion;
        }

        public Cliente Clone()
        {
            return new Cliente(Nombre, Direccion); // Clonación profunda
        }

        public override string ToString()
        {
            return $"Cliente: {Nombre}, Dirección: {Direccion}";
        }
    }

}