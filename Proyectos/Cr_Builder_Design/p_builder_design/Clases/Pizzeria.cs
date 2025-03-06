using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_builder_design.Interfaces;

namespace p_builder_design.Clases
{
    public class Pizzeria  //este es el Director
    {
        public void HacerPizzaMargarita(IPizzaBuilder pizzero)
        {
            pizzero.Comenzar();
            pizzero.ExtenderMasa("Delgada");
            pizzero.PonerSalsa("Tomate");
            pizzero.AdicionarIngrediente("Queso Mozzarella");
            pizzero.AdicionarIngrediente("Albahaca");
        }
        

        public void HacerPizzaCarnes(IPizzaBuilder pizzero)
        {
            pizzero.Comenzar();
            pizzero.ExtenderMasa("Gruesa");
            pizzero.PonerSalsa("BBQ");
            pizzero.AdicionarIngrediente("Queso Mozzarella");
            pizzero.AdicionarIngrediente("Pepperoni");
            pizzero.AdicionarIngrediente("Salchicha Italiana");
            pizzero.AdicionarIngrediente("Tocineta");
            pizzero.AdicionarIngrediente("Jamón Serrano");
        }
    
        public void HacerPizzaVegetales(IPizzaBuilder pizzero)
        {
            pizzero.Comenzar();
            pizzero.ExtenderMasa("Integral");
            pizzero.PonerSalsa("Tomate");
            pizzero.AdicionarIngrediente("Queso Mozzarella");
            pizzero.AdicionarIngrediente("Pimientos");
            pizzero.AdicionarIngrediente("Champiñones");
            pizzero.AdicionarIngrediente("Aceitunas");
            pizzero.AdicionarIngrediente("Cebolla");
        }

        public void HacerPizzaAnchoas(IPizzaBuilder pizzero)
        {
            pizzero.Comenzar();
            pizzero.ExtenderMasa("Delgada");
            pizzero.PonerSalsa("Tomate");
            pizzero.AdicionarIngrediente("Queso Mozzarella");
            pizzero.AdicionarIngrediente("Anchoas");
            pizzero.AdicionarIngrediente("Aceitunas");
            pizzero.AdicionarIngrediente("Cebolla");
        }
    }
}