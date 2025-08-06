using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P_Repaso.Clases;
using P_Repaso.Interfaces;

namespace P_Repaso.Clases
{
    internal class Deportivo:Automovil
    {
        private bool coupe;
        private bool descapotable;

        public Deportivo(string placa, string marca, string modelo, ushort ano, ushort cilindraje, byte nro_puestos, byte nro_puertas,
         ulong valor_bruto, IValidaAutomovil validador_auto, bool coupe=true, bool descapotable=true) :
         base(placa, marca, modelo, ano, cilindraje, nro_puestos, nro_puertas, valor_bruto, validador_auto)
        {

            this.descapotable = descapotable;
            this.coupe = coupe;

        }

        public bool Coupe { get => coupe; }
        public bool Descapotable { get => descapotable; }

        public override string Consultar_plan_mtto()
        {
            try
            {
                return "";                    ;
            }
            catch (Exception ex)
            {
                throw new Exception("ocurró un error consulta plan mtto, Camioneta");
            }
        }

    }
}