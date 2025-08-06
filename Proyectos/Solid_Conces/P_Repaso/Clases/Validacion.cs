using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P_Repaso.Interfaces;

namespace P_Repaso.Clases
{
    public class Validacion : IValidaAutomovil, IValidaConcesionario, IValidaNombre, IValidaPersona
    {
        
        //Sirve para validar todos los atributos nombres de todo el proyecto
        public bool ValidarNombre(string nombre) => !string.IsNullOrWhiteSpace(nombre) && nombre.Length >= RN_Automovil.long_min_nom;
        
        public bool ValidarDireccion(string direccion) => !string.IsNullOrWhiteSpace(direccion) && direccion.Length >= RN_Automovil.long_min_dir;

        public bool ValidarId(string id) =>
            !(string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id) || id.Length < RN_Automovil.long_min_id_top )? true : false;

        public bool ValidarPlaca(string placa) => 
        ! (string.IsNullOrEmpty(placa) || string.IsNullOrWhiteSpace(placa) || placa.Length != RN_Automovil.long_placa 
        || placa.Substring(0, 2).ToCharArray().Any(c => !char.IsLetter(c)));
        
        public bool ValidarMarca(string marca) =>
        !(string.IsNullOrEmpty(marca) || string.IsNullOrWhiteSpace(marca) || marca.Length < RN_Automovil.long_marca_min);

        public bool ValidarModelo(string modelo) => !(string.IsNullOrWhiteSpace(modelo) && modelo.Length >= RN_Automovil.long_mod_min);

        public bool ValidarValor(ulong valor) => valor >= RN_Automovil.valor_minimo_nuevo;
        
        public bool ValidarAno(ushort ano) => ano < DateTime.Now.Year || ano > DateTime.Now.Year + RN_Automovil.gap_ano;
        public bool ValidarCilindraje(ushort cilindraje) =>  !(cilindraje < RN_Automovil.cil_min || cilindraje > RN_Automovil.cil_max);

        public bool ValidarNroPuestos(byte nro_puestos) => !(nro_puestos < RN_Automovil.nro_pues_min || nro_puestos > RN_Automovil.nro_pues_max);

        public bool ValidarNroPuertas(byte nro_puertas) =>  !(nro_puertas != RN_Automovil.nro_ptas_2 && nro_puertas != RN_Automovil.nro_ptas_3 && nro_puertas != RN_Automovil.nro_ptas_5);

    }
}