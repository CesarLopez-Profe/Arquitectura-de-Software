// See https://aka.ms/new-console-template for more information
// Crear un sedán con motor de gasolina
using p_estr_bridge.Clases;
        Auto sedanGasolina = new Sedan(new Gasolina());
        sedanGasolina.Conducir();

        Console.WriteLine();

        // Crear un SUV con motor eléctrico
        Auto suvElectrico = new SUV(new Electrico());
        suvElectrico.Conducir();
