// See https://aka.ms/new-console-template for more information
using P_Repaso.Clases;

//Console.WriteLine("Hello, World!");

Vendedor vendedor = new Vendedor("98555222", "Juan Perez", 0.016f);

var vendedor1 = new {
    Id = "64899001",
    Nombre = "Susana Marin",
    Comision = 0.016f
};

Console.WriteLine(vendedor1 is Vendedor);

Vendedor vendedor2 = new Vendedor(vendedor1.Id, vendedor1.Nombre, vendedor1.Comision);

Console.WriteLine(vendedor2 is Vendedor);

Cliente cliente = new Cliente("77744555", "Pedro Gomez", 0.02f);

Console.WriteLine(vendedor.Id);