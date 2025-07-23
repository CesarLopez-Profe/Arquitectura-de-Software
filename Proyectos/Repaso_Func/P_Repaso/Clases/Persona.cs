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
            get => id; set => id = validarId(value) ? value : throw new Exception("Id No Válido");
            
        }

        private Func<string, bool> validarId = (value) =>
            !(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < Concesionario.long_min_id_top )? true : false;

        public string Nombre
        {
            get => nombre; set => nombre = validarNombre(value) ? value : throw new Exception("Nombre No Válido");
        }

        private Func<string, bool> validarNombre = (value) =>
            !(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < Concesionario.long_min_nom )? true : false;


    }
}