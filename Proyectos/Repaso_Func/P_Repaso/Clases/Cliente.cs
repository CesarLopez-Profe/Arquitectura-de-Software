using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P_Repaso.Clases;

namespace P_Repaso.Clases
{
    internal class Cliente:Persona
    {
        private float descuento;

        public Cliente(string id, string nombre, float descuento) : base(id, nombre)
        {
            this.Descuento = descuento;
        }

        public float Descuento
        {
            get => descuento; set
            {
                /*if (value < Concesionario.descto_menor || value > Concesionario.descto_mayor)
                    throw new Exception("Descuento No válido");
                else descuento = value;*/
                descuento = (value < Concesionario.descto_menor || value > Concesionario.descto_mayor)
                ? throw new Exception("Descuento No válido")
                : value;
            }
        }

    }
}