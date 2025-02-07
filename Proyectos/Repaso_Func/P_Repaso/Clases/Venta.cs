using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P_Repaso.Clases
{
    internal class Venta
    {
       

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
            Concesionario.consec_fracion+=1;
            nro_factura = Concesionario.consec_fracion;
        }

        public ulong Nro_factura { get => nro_factura;  }
      

        public ulong Valor
        {
            get => valor; set => valor = validarValorVta(value) ? value : throw new Exception("El valor de venta no es válido");

        }

         private Func<ulong, bool> validarValorVta = (value) =>  (value < Automovil.valor_minimo_nuevo) ? true : false;



        internal List<Persona> L_personas
        {
            get => l_personas; 
            set => l_personas = ((byte)value.Count(p => p is Vendedor) == 1 && (byte)value.Count(p => p is Cliente) == 1) 
            ? value : throw new Exception("La venta debe tener un vendedor y un cliente");
        }

        internal Automovil Auto_vendido { get => auto_vendido;  }

    }

    
}