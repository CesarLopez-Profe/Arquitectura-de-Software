using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P_Repaso.Clases;
using P_Repaso.Interfaces;

namespace P_Repaso.Clases
{
    internal class Concesionario
    {
        
        private readonly IValidaNombre validador_nombre;  //Inyección de dependencia
        private readonly IValidaConcesionario validador_concesionario;  //Inyección de dependencia

        //Atributos de usuario
        private string nombre;
        private string direccion;
        //Atributo de estado, se modifica vía los métodos
        internal List<Venta> l_ventas;

        internal static ulong consec_fracion = 1000000; //En este número comienzan las facturas de venta
        


        public Concesionario(string nombre, string direccion, IValidaAutomovil validador_auto, IValidaConcesionario validador_concesionario,
            IValidaNombre validador_nombre)
        {
            
            this.validador_concesionario = validador_concesionario ?? throw new ArgumentNullException(nameof(validador_concesionario));
            this.validador_nombre = validador_nombre ?? throw new ArgumentNullException(nameof(validador_nombre));
            Nombre = nombre;
            Direccion = direccion;
            l_ventas = new List<Venta>();
        }



        public string Nombre
        {
            get => nombre; set => nombre = validador_nombre.ValidarNombre(value) ? value : throw new Exception("Nombre No Válido");
        }

        public string Direccion
        {
            get => direccion; set => direccion = validador_concesionario.ValidarDireccion(value) ? value : throw new Exception("Dirección No Válida");
            
        }

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
                throw new Exception("Ocurrió un error registrando la venta. " + error);
            }
        }

       
        
    }
}