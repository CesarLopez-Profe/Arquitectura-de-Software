// See https://aka.ms/new-console-template for more information
using p_builder_design.Clases;

PizzaBuilder paso_paso = new PizzaBuilder();
Pizzeria piccolo = new Pizzeria();

//Hacer una pizza Margarita
piccolo.HacerPizzaMargarita(paso_paso);
Pizza margarita = paso_paso.RecogerProducto();
margarita.MostrarPizzaLista();