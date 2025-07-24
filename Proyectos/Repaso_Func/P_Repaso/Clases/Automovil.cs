using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P_Repaso.Interfaces;

namespace P_Repaso.Clases
{
    internal abstract class Automovil:IMantenimiento
    {
    
        private string placa;
        private string marca;
        private string modelo;
        private ushort ano;
        private ushort cilindraje;
        private byte nro_puestos;
        private uint kilometraje;
        private byte nro_puertas;
        private ulong valor_bruto;
        public static readonly ulong valor_minimo_nuevo = 60000000;

        public Automovil(string placa, string marca, string modelo, ushort ano, ushort cilindraje,
            byte nro_puestos, byte nro_puertas, ulong valor_bruto)
        {
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

        //Accesores usando expresiones ternarias, 
        //La sintaxis throw en una expresión ternaria es posible desde C# 7.0
        
        public string Placa
        {
            get => placa; 
            set => placa = !(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length != Concesionario.long_placa_nombempr_tax ||
            value.Substring(0, 2).ToCharArray().Any(c => !char.IsLetter(c))) ? 
                value : throw new Exception("Placa No Válida");  //Esta no usa la función lambda como las demás sino que realiza la validación dentro de la ternaria
            
        }

        public string Marca
        {
            get => marca; set => marca = validarMarca(value) ? value : throw new Exception("Marca No Válida");
            
        }

        public string Modelo
        {
            get => modelo; set => modelo = validarModelo(value) ? value : throw new Exception("Modelo No Válido");
            
        }

        public ushort Ano
        {
            get => ano; set => ano = validarAno(value) ? value : throw new Exception("Año No Válido");
        }

        public ushort Cilindraje
        {
            get => cilindraje; set => cilindraje = validarCilindraje(value) ? value : throw new Exception("Cilindraje No Válido");
            
        }

        public byte Nro_puestos
        {
            get => nro_puestos; set => nro_puestos = validarNroPuestos(value) ? value : throw new Exception("Número de puestos No válido");
            
        }

        public byte Nro_puertas 
        {
            get => nro_puertas; set => nro_puertas = validarNroPuertas(value) ? value : throw new Exception("Número de puertas No válido");
            
        }

        public ulong Valor_bruto
        {
            get => valor_bruto; set => valor_bruto = validarValorBruto(value) ? value : throw new Exception("Valor del auto No válido");
            
        }
        
        // Aternativas: tener Delegados Func para las validaciones
       
        /* Delegado para la validación de placa

        private Func<string, bool> validarPlaca = (value) =>
            !(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length != Concesionario.long_placa_nombempr_tax ||
            value.Substring(0, 2).ToCharArray().Any(c => !char.IsLetter(c))) ? true : false;

        */

        // Delegado para validación de marca
        private Func<string, bool> validarMarca = (value) =>
            (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < Concesionario.long_marca_min) ? false : true;
        

        // Delegado para validación de modelo
        private Func<string, bool> validarModelo = (value) =>
            (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < Concesionario.long_mod_min) ? false:true;
        
        // Delegado para validación de año
        private Func<ushort, bool> validarAno = (value) =>
        (value < DateTime.Now.Year || value > DateTime.Now.Year + Concesionario.gap_ano)? false: true;

        // Delegado para validación de cilindraje
        private Func<ushort, bool> validarCilindraje = (value) => (value < 1000 || value > 6000) ? false: true;            

        // Delegado para validación de número de puestos
        private Func<byte, bool> validarNroPuestos = (value) =>(value < 2 || value > 7) ? false: true;

        // Delegado para validación de número de puertas
        private Func<byte, bool> validarNroPuertas = (value) => (value != 2 && value != 3 && value != 5)? false: true;

        // Delegado para validación de valor bruto
        private Func<ulong, bool> validarValorBruto = (value) => (value < valor_minimo_nuevo)? false: true;


        public abstract string Consultar_plan_mtto();

    }
}