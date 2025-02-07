using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P_Repaso.Clases
{
    internal abstract class Persona
    {
        private string id;
        private string nombre;

        protected Persona(string id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public string Id
        {
            get => id; set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < 5)
                    throw new Exception("Id No Válido");
                else id = value;
            }
        }
        public string Nombre
        {
            get => nombre; set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < 10)
                    throw new Exception("Nombre No Válido");
                else nombre = value;
            }
        }

    }
}