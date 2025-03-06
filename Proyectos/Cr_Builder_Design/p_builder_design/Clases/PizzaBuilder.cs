using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_builder_design.Interfaces;

namespace p_builder_design.Clases
{
    public class PizzaBuilder : IPizzaBuilder //Builder: Paso a paso
    {
        private Pizza pizza = new Pizza();
        public void Comenzar()
        {
            pizza = new Pizza();
        }

        public void ExtenderMasa(string masa)
        {
            pizza.masa = masa;
        }

        public void PonerSalsa(string salsa)
        {
            pizza.salsa = salsa;
        }


        public void AdicionarIngrediente(string ingrediente)
        {
            pizza.l_ingredientes.Add(ingrediente);
        }

        
        public Pizza RecogerProducto()
        {
            return pizza;
        }

    }
}