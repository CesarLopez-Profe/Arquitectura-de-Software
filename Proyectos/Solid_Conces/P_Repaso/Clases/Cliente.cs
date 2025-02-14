using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P_Repaso.Clases;
using P_Repaso.Interfaces;

namespace P_Repaso.Clases
{
    internal class Cliente:Persona
    {
        private float descuento;

        public Cliente(string id, string nombre, IValidaPersona validador_persona, IValidaNombre validador_nombre,float descuento) 
        : base(id, nombre, validador_persona, validador_nombre)
        {
            this.Descuento = descuento;
        }

        public float Descuento
        {
            get => descuento; set
            {
                if (value < RN_Concesionario.descto_menor || value > RN_Concesionario.descto_mayor)
                    throw new Exception("Descuento No válido");
                else descuento = value;
            }
        }

    }
}