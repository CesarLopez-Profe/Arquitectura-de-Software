// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using p_est_flyweight.Clases;

AutoFlyweightFactory fabrica = new AutoFlyweightFactory();

// Se crean y reutilizan objetos flyweight
var auto1 = fabrica.BuscarAuto("Toyota", "Corolla", "1.8L");
auto1.MostrarDetalles("Red", "ABC-123");

var auto2 = fabrica.BuscarAuto("Toyota", "Corolla", "1.8L");
auto2.MostrarDetalles("Blue", "XYZ-789");

var auto3 = fabrica.BuscarAuto("Ford", "Focus", "2.0L");
auto3.MostrarDetalles("Black", "JKL-456");

// car1 y car2 usan el mismo objeto en memoria para Toyota Corolla 1.8L
Console.WriteLine($"car1 and car2 refer to the same instance: {ReferenceEquals(auto1, auto2)}");
