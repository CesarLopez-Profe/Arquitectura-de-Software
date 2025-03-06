using System;
using System.Collections.Generic;
using p_prototype.Clases;
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


// Cliente Base
Cliente clienteBase = new Cliente("Juan Pérez", "Av. Principal 123");

// Artículos Base
List<Articulo> articulosBase = new List<Articulo>
{
    new Articulo("Laptop", 1200.99m, 1),
    new Articulo("Mouse", 25.50m, 2)
};

// Crear una Factura Base
Factura facturaBase = new Factura(clienteBase, articulosBase);
Console.WriteLine("Factura Original:");
Console.WriteLine(facturaBase);

// Clonar la Factura para otro cliente con modificaciones
Factura facturaClonada = facturaBase.Clone();
facturaClonada.Cliente.Nombre = "Ana Gómez";  // Modificar Cliente
facturaClonada.Cliente.Direccion = "Calle Secundaria 456";
facturaClonada.Articulos[1].Cantidad = 3; // Modificar cantidad de un artículo

Console.WriteLine("\nFactura Clonada con Modificaciones:");
Console.WriteLine(facturaClonada);

