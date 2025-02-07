using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P_Repaso.Clases;

namespace P_Repaso.Clases
{
    internal class Concesionario
    {
        internal readonly static float descto_menor = 0.01f;
        internal readonly static float descto_mayor = 0.025f;
        internal readonly static float comision_menor = 0.015f;
        internal readonly static float comision_mayor = 0.02f;

        private string nombre;
        private string direccion;
        private List<Venta> l_ventas;


        public Concesionario(string nombre, string direccion)
        {
            Nombre = nombre;
            Direccion = direccion;
            l_ventas = new List<Venta>();
        }



        public string Nombre
        {
            get => nombre; set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < 5)
                    throw new Exception("Nombre No Válido");
                else nombre = value;
            }
        }
        public string Direccion
        {
            get => direccion; set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < 10)
                    throw new Exception("Dirección no válida");
                else direccion = value;
            }
        }
        internal List<Venta> L_ventas { get => l_ventas;  }



        public string Registrar_Venta(Cliente cliente, Vendedor vendedor, Automovil auto)
        {
            try
            {
                string txt_venta = "";
                ulong valor_neto = 0;
                string tipo = "";



                if (auto is Camioneta) tipo = "Camioneta";
                else if (auto is Deportivo) tipo = "Deportivo";
                else if (auto is Taxi) tipo = "Taxi";



                List<Persona> l_personas = new List<Persona>();
                l_personas.Add(cliente);
                l_personas.Add(vendedor);



                valor_neto = (ulong)(auto.Valor_bruto * (1 - cliente.Descuento));



                //Venta v1 = new Venta(l_personas, auto, valor_neto);
                L_ventas.Add(new Venta(l_personas, auto, valor_neto));



                txt_venta = "Número: " + Venta.Nro.ToString() + 
                    "Cliente: " + cliente.Id + " " + cliente.Nombre +
                    "\nMarca y Modelo: " + auto.Marca + " " + auto.Modelo +
                    "\nTipo: " + tipo + " Cilindraje: " + auto.Cilindraje +
                    "\nAño: " + auto.Ano +
                    "\nValor Bruto: $" + auto.Valor_bruto + " Valor Neto: $" + valor_neto;
                

                l_personas.Clear();

                return txt_venta;
            }



            catch (Exception error)
            {
                throw new Exception("Ocurrió un eror registrando la venta. " + error);
            }



        }

    }
}