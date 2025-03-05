// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using p_abstract_factory.Clases;
using p_abstract_factory.Interfaces;

IFabricaAutos fabrica_electricos = new FabricaAutosElectricos();
ClienteFabricaAutos cliente_electricos = new ClienteFabricaAutos(fabrica_electricos);
cliente_electricos.ArmarAuto();

IFabricaAutos fabrica_gasolina = new FabricaAutosGasolina();
ClienteFabricaAutos cliente_gasolina = new ClienteFabricaAutos(fabrica_gasolina);
cliente_gasolina.ArmarAuto();

