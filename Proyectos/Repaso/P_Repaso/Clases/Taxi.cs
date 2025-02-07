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



        public Taxi(string placa, string marca, string modelo, ushort ano, ushort cilindraje, byte nro_puestos, byte nro_puertas,
            ulong valor_bruto, string nro_traj_oper, string empresa) :
            base(placa, marca, modelo, ano, cilindraje, nro_puestos, nro_puertas, valor_bruto)
        {

            Empresa = empresa;
            Nro_tarj_oper = nro_traj_oper;
        }

        public string Nro_tarj_oper
        {
            get => nro_tarj_oper; set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < 5)
                    throw new Exception("Tarjeta de opeación no Válida");
                else nro_tarj_oper = value;
            }
        }
        public string Empresa
        {
            get => empresa; set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < 6)
                    throw new Exception("Empresa No Válida");
                else empresa = value;
            }
        }

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