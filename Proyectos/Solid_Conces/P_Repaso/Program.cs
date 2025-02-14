// See https://aka.ms/new-console-template for more information
using P_Repaso.Clases;
using P_Repaso.Interfaces;

//Console.WriteLine("Hello, World!");

IValidaAutomovil validaauto = new Validacion();
IValidaConcesionario validaconc = new Validacion();
IValidaNombre validanom = new Validacion();
IValidaPersona validaper = new Validacion();



Vendedor vendedor = new Vendedor("98555222", "Juan Perez",validaper,validanom,  0.016f);

var vendedor1 = new {
    Id = "64899001",
    Nombre = "Susana Marin",
    Comision = 0.016f
};

Console.WriteLine(vendedor1 is Vendedor);

Vendedor vendedor2 = new Vendedor(vendedor1.Id, vendedor1.Nombre, validaper,validanom, vendedor1.Comision);

Console.WriteLine(vendedor2 is Vendedor);

Cliente cliente = new Cliente("77744555", "Pedro Gomez", validaper, validanom, 0.02f);

Console.WriteLine(vendedor.Id);

Concesionario Auto_mas = new Concesionario("Auto_mas","Calle 10sur 42-30",validaauto,validaconc,validanom);

Camioneta camioneta = new Camioneta("HHX123","Mitsubishi","Outlander",2021,2400,7,5,180000000,validaauto,true,2);

