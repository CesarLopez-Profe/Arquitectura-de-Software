using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P_Repaso.Clases
{
    public abstract class RN_Concesionario
    {
        //Atributos reglas de negocio, tinen sentido en el contexto de este concesionario
        internal readonly static float descto_menor = 0.01f, descto_mayor = 0.025f;
        internal readonly static float comision_menor = 0.015f, comision_mayor = 0.02f;
        
    }
}