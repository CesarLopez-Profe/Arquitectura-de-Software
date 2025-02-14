using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P_Repaso.Clases
{
    public abstract class RN_Automovil
    {
        internal static readonly ulong valor_minimo_nuevo = 80000000;
        internal readonly static byte long_marca_min = 2;
        internal readonly static byte long_mod_min = 2;
        internal readonly static byte gap_ano = 2;
        internal readonly static short cil_min = 1000;
        internal readonly static short cil_max = 6000;
        internal readonly static byte nro_pues_min = 2;
        internal readonly static byte nro_pues_max = 7;
        internal readonly static byte nro_ptas_2 = 2;
        internal readonly static byte nro_ptas_3 = 3;
        internal readonly static byte nro_ptas_5 = 5;
        internal readonly static byte nro_ptas_7 = 7;
        internal readonly static byte long_min_nom = 5; 
        internal readonly static byte long_min_dir = 10; 
        internal readonly static byte long_min_id_top = 5; 
        internal readonly static byte long_placa = 6;

    }
}