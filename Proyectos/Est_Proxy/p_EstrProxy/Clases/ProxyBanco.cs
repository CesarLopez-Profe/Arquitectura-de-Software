using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_EstrProxy.Interfaces;

namespace p_EstrProxy.Clases
{
    public class ProxyBanco:IBanco
    {
        private Banco bancoReal;
        private List<string> _usuariosAutorizados = new List<string> { "Juan", "María" };

        public ProxyBanco()
        {
            bancoReal = new Banco();
        }

        public void RetirarDinero(string usuario, int cantidad)
        {
            if (_usuariosAutorizados.Contains(usuario))
            {
                bancoReal.RetirarDinero(usuario, cantidad);
            }
            else
            {
                Console.WriteLine("Acceso denegado. Usuario no autorizado.");
            }
        }
    }
}