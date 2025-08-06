using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P_Repaso.Interfaces;

namespace P_Repaso.Clases
{
    internal abstract class Persona
    {
        
        private readonly IValidaPersona validador_persona;  //Inyección de dependencia
        private readonly IValidaNombre validador_nombre;  //Inyección de dependencia
        
        private string id;
        private string nombre;

        protected Persona(string id, string nombre, IValidaPersona validador_persona, IValidaNombre validador_nombre)
        {
            this.validador_persona = validador_persona ?? throw new ArgumentNullException(nameof(validador_persona));
            this.validador_nombre = validador_nombre ?? throw new ArgumentNullException(nameof(validador_nombre));
            Id = id;
            Nombre = nombre;
        }

        public string Id
        {
            get => id; set => id = validador_persona.ValidarId(value) ? value : throw new Exception("Id No Válido");
            
        }

        public string Nombre
        {
            get => nombre; set => nombre = validador_nombre.ValidarNombre(value) ? value : throw new Exception("Nombre No Válido");
        }

    }
}