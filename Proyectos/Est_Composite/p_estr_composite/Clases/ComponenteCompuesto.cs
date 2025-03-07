using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_estr_composite.Interfaces;

namespace p_estr_composite.Clases
{
    public class ComponenteCompuesto: IComponenteAuto
    {
        private string _nombre;
        private List<IComponenteAuto> l_icomponentes_auto = new List<IComponenteAuto>();

        public ComponenteCompuesto(string nombre)
        {
            _nombre = nombre;
        }

        public void Agregar(IComponenteAuto componente)
        {
            l_icomponentes_auto.Add(componente);
        }

        public void MostrarDetalles()
        {
            Console.WriteLine($"Componente: {_nombre}");
            l_icomponentes_auto.ForEach(componente => componente.MostrarDetalles());
            /*foreach (var componente in l_icomponentes_auto)
            {
                componente.MostrarDetalles();
            }*/
        }
    }
}