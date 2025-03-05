// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using p_factory.Clases;
using p_factory.Interfaces;

AutomovilFactory fabrica;

//Crear un taxi
fabrica = new TaxiFactory();
IAutomovil taxi = fabrica.CrearAutomovil();
taxi.MostrarDetalles();

