// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
// Acceder a la única instancia del Centro de Control
using p_singleton;

var centro1 = CentroDiagnAuto.Instancia;
centro1.RegistrarAutomovil("Sedán 2025");

// Intentar obtener otra instancia (es la misma)
var centro2 = CentroDiagnAuto.Instancia;
centro2.RegistrarAutomovil("SUV 2025");

// Verificar que ambas instancias son iguales
Console.WriteLine(centro1 == centro2 ? "Es la misma instancia." : "Son diferentes instancias.");