using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P_Repaso.Clases
{
    internal class Venta
    {
        private static ulong nro = 1000000; //En este número comienzan las facturas de venta

        private ulong nro_factura;
        private List<Persona> l_personas;
        private Automovil auto_vendido;
        private DateTime fecha;
        private ulong valor;

        public Venta(List<Persona> l_personas, Automovil auto_vendido, ulong valor)
        {
            L_personas = l_personas;
            this.auto_vendido = auto_vendido;
            fecha = DateTime.Now;
            Valor = valor;
            nro+=1;
            nro_factura = nro;
        }

        public static ulong Nro { get => nro;  }

        public ulong Valor
        {
            get => valor; set
            {
                if (value < Automovil.valor_minimo_nuevo)
                    throw new Exception("El valor no es válido");
                else valor = value;
            }



        }

        public ulong Nro_factura { get => nro_factura;  }

        internal List<Persona> L_personas
        {
            get => l_personas; set
            {



                byte cont_ven = 0, cont_cli = 0;



                foreach (Persona elemento in value)
                {
                    if (elemento is Cliente) cont_cli++;
                    else if (elemento is Vendedor) cont_ven++;
                    
                }


                if (cont_ven == 1 && cont_cli == 1) l_personas = value;
                else throw new Exception("La venta debe tener un vendedor y un cliente");
            }



        }

        internal Automovil Auto_vendido { get => auto_vendido;  }

    }

    
}