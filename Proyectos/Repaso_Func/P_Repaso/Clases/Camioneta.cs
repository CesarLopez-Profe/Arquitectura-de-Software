using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P_Repaso.Clases;
using P_Repaso.Interfaces;

namespace P_Repaso.Clases
{
    internal class Camioneta:Automovil
    {
        private bool doble = false;
        private byte nro_exploradoras;

        public Camioneta(string placa, string marca, string modelo, ushort ano, ushort cilindraje, byte nro_puestos, byte nro_puertas,
            ulong valor_bruto, bool doble, byte nro_exploradoras) :
            base(placa, marca, modelo, ano, cilindraje, nro_puestos, nro_puertas, valor_bruto)
        {
            Nro_exploradoras = nro_exploradoras;
            this.doble = doble;
        }

        public byte Nro_exploradoras
        {
            get => nro_exploradoras; set => nro_exploradoras = validarNroExploradoras(value);
        }

        private Func<byte, byte> validarNroExploradoras = (value) =>
        {
            if (value < 2 || value > 6) throw new Exception("Número de exploradoras No válido");
            return value;
        };

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

        public override string ToString(){
            return GenerarCadenaCamioneta();
        }
        private string GenerarCadenaCamioneta()
        {
            return $"Placa: {Placa}, Marca: {Marca}, Modelo: {Modelo}, Año: {Ano}, +Cilindraje: {Cilindraje}, Nro Puestos: {Nro_puestos}, Nro Puertas: {Nro_puertas}, Valor Bruto: {Valor_bruto}, Doble Tracción: {doble}, Nro Exploradoras: {Nro_exploradoras}";
        }
     }
}