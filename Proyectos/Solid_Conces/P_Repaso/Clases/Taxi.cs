using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P_Repaso.Clases;
using P_Repaso.Interfaces;

namespace P_Repaso.Clases
{
    internal class Taxi:Automovil
    {
        private string nro_tarj_oper;
        private string empresa;
        internal readonly static byte long_min_top = 6, long_nombempr_tax = 6;



        public Taxi(string placa, string marca, string modelo, ushort ano, ushort cilindraje, byte nro_puestos, byte nro_puertas,
            ulong valor_bruto, IValidaAutomovil validador_auto ,string nro_traj_oper, string empresa) :
            base(placa, marca, modelo, ano, cilindraje, nro_puestos, nro_puertas, valor_bruto, validador_auto)
        {

            Empresa = empresa;
            Nro_tarj_oper = nro_traj_oper;
        }

        
        public string Nro_tarj_oper
        {
            get => nro_tarj_oper; set => nro_tarj_oper = validarNro_tarj_oper(value) ? value : throw new Exception("Id No Válido");
            
        }

        private Func<string, bool> validarNro_tarj_oper = (value) =>
            !(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < long_min_top )? true : false;

        public string Empresa
        {
            get => empresa; set => empresa = validarEmpresa(value) ? value : throw new Exception("Nombre de empresa taxi No Válido");
            
        }

        private Func<string, bool> validarEmpresa = (value) =>
            !(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length != long_nombempr_tax) ? true : false;

        public override string Consultar_plan_mtto()
        {
            try
            {
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception("ocurró un error consulta plan mtto, Taxi");
            }
        }

    }
}