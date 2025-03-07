// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using p_estr_composite_caja.Clases;


Producto producto1 = new Producto("Laptop", 1200);
Producto producto2 = new Producto("Teléfono", 800);

// Crear cajas
Caja cajaPequena = new Caja("Pequeña", 5);
cajaPequena.AgregarItem(producto2); // Teléfono dentro de la caja pequeña

Caja cajaGrande = new Caja("Grande", 10);
cajaGrande.AgregarItem(producto1); // Laptop en la caja grande
cajaGrande.AgregarItem(cajaPequena); // Caja pequeña dentro de la caja grande

// Crear pedido
Pedido pedido = new Pedido();
pedido.AgregarItem(cajaGrande); // Caja grande en el pedido
pedido.AgregarItem(new Producto("Tablet", 600)); // Producto fuera de la caja

// Calcular total
Console.WriteLine($"El precio total del pedido es: USD {pedido.ObtenerTotal()}");
