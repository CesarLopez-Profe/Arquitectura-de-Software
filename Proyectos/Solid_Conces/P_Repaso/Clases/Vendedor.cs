using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P_Repaso.Clases;
using P_Repaso.Interfaces;

namespace P_Repaso.Clases
{
    internal class Vendedor:Persona 
    {
        private float comision;
        public Vendedor(string id, string nombre, IValidaPersona validador_persona, IValidaNombre validador_nombre, float comision) 
        : base(id, nombre, validador_persona, validador_nombre) 
        {
            Comision = comision;
        }



        public float Comision
        {
            get => comision; set => comision = !(value < RN_Concesionario.comision_menor || value > RN_Concesionario.comision_mayor )? 
            value : throw new Exception("El valor de la Comisión no es válido");
            
        }
        
    }
}