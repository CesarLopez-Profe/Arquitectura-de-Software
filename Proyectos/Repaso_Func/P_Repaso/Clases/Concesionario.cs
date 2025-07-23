using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P_Repaso.Clases;

namespace P_Repaso.Clases
{
    internal class Concesionario
    {

        //Atributos de usuario
        private string nombre;
        private string direccion;
        //Atributo de estado, se modifica vía los métodos
        internal List<Venta> l_ventas;

        //Atributos reglas de negocio, tinen sentido en el contexto de este concesionario
        internal readonly static float descto_menor = 0.01f;
        internal readonly static float descto_mayor = 0.025f;
        internal readonly static float comision_menor = 0.015f;
        internal readonly static float comision_mayor = 0.02f;
        internal readonly static byte long_placa_nombempr_tax = 6;
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
        internal static ulong consec_fracion = 1000000; //En este número comienzan las facturas de venta


        public Concesionario(string nombre, string direccion)
        {
            Nombre = nombre;
            Direccion = direccion;
            l_ventas = new List<Venta>();
        }



        public string Nombre
        {
            get => nombre; set => nombre = validarNombre(value) ? value : throw new Exception("Nombre No Válido");
        }

        private Func<string, bool> validarNombre = (value) =>
            !(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length != long_min_nom )? true : false;


        public string Direccion
        {
            get => direccion; set => direccion = validarDireccion(value) ? value : throw new Exception("Dirección No Válida");
            
        }

        private Func<string, bool> validarDireccion = (value) =>
            !(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length != long_min_dir )? true : false;

        internal List<Venta> L_ventas { get => l_ventas;  }


        //Método tradicional para registrar la venta. No se puede convertir a un método lambda porque la lista 
        //de ventas es un atributo de la clase y no es estático
        public string Registrar_Venta(Cliente cliente, Vendedor vendedor, Automovil auto)
        {
            try
            {
                string txt_venta = "";
                ulong valor_neto = 0;
                string tipo = "";
                Venta venta;

                //Nueva expresion ternaria 
                tipo = (auto is Camioneta) ? "Camioneta" : 
                        (auto is Deportivo) ? "Deportivo" : 
                        (auto is Taxi) ? "Taxi" : throw new Exception("Tipo de auto no válido. Método Registrar_Venta");


                List<Persona> l_personas = new List<Persona>();
                l_personas.Add(cliente);
                l_personas.Add(vendedor);
                valor_neto = (ulong)(auto.Valor_bruto * (1 - cliente.Descuento));

                venta = new Venta(l_personas, auto, valor_neto);
                l_ventas.Add(venta);



                txt_venta = "Número: " + venta.Nro_factura.ToString() + 
                    "Cliente: " + cliente.Id + " " + cliente.Nombre +
                    "\nMarca y Modelo: " + auto.Marca + " " + auto.Modelo +
                    "\nTipo: " + tipo + " Cilindraje: " + auto.Cilindraje +
                    "\nAño: " + auto.Ano +
                    "\nValor Bruto: $" + auto.Valor_bruto + " Valor Neto: $" + valor_neto;
                

                l_personas.Clear();
                venta = null; //destruye la instancia para que el recolector de basura la elimine

                return txt_venta;
            }

            catch (Exception error)
            {
                throw new Exception("Ocurrió un eror registrando la venta. " + error);
            }
        }

       
        
    }
}