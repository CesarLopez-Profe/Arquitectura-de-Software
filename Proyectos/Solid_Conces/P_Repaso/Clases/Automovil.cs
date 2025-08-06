using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P_Repaso.Interfaces;

namespace P_Repaso.Clases
{
    internal abstract class Automovil:IMantenimiento
    {
    
        private readonly IValidaAutomovil validador_auto;  //Inyección de dependencia
        private string placa;
        private string marca;
        private string modelo;
        private ushort ano;
        private ushort cilindraje;
        private byte nro_puestos;
        private uint kilometraje;
        private byte nro_puertas;
        private ulong valor_bruto;
        

        public Automovil(string placa, string marca, string modelo, ushort ano, ushort cilindraje,
            byte nro_puestos, byte nro_puertas, ulong valor_bruto, IValidaAutomovil validador_auto) //Inyección de dependencia
        {

            this.validador_auto = validador_auto ?? throw new ArgumentNullException(nameof(validador_auto));
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Cilindraje = cilindraje;
            Nro_puestos = nro_puestos;
            kilometraje = 0;
            Nro_puertas = nro_puertas;
            Valor_bruto = valor_bruto;

        }

        //Encapsulamiento usando la clase Validacion
        //La sintaxis throw en una expresión ternaria es posible desde C# 7.0
        public string Placa
        {
            get => placa; set => placa = validador_auto.ValidarPlaca(value) ? value : throw new Exception("Placa No Válida");
            
        }

        public string Marca
        {
            get => marca; set => marca = validador_auto.ValidarMarca(value) ? value : throw new Exception("Marca No Válida");
            
        }

        public string Modelo
        {
            get => modelo; set => modelo = validador_auto.ValidarModelo(value) ? value : throw new Exception("Modelo No Válido");
            
        }

        public ushort Ano
        {
            get => ano; set => ano = validador_auto.ValidarAno(value) ? value : throw new Exception("Año No Válido");
        }

        public ushort Cilindraje
        {
            get => cilindraje; set => cilindraje = validador_auto.ValidarCilindraje(value) ? value : throw new Exception("Cilindraje No Válido");
            
        }

        public byte Nro_puestos
        {
            get => nro_puestos; set => nro_puestos = validador_auto.ValidarNroPuestos(value) ? value : throw new Exception("Número de puestos No válido");
            
        }

        public byte Nro_puertas 
        {
            get => nro_puertas; set => nro_puertas = validador_auto.ValidarNroPuertas(value) ? value : throw new Exception("Número de puertas No válido");
            
        }

        public ulong Valor_bruto
        {
            get => valor_bruto; set => valor_bruto = validador_auto.ValidarValor(value) ? value : throw new Exception("Valor del auto No válido");
            
        }
        


        public abstract string Consultar_plan_mtto();

    }
}