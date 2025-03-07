// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using p_estr_composite.Clases;

// Crear partes individuales
Parte motor = new Parte("Motor V8");
Parte aa = new Parte("Aire Acondicionado");
Parte llanta = new Parte("Llanta Michelin");
Parte volante = new Parte("Volante Deportivo Momo");
Parte gps = new Parte("GPS Garmin");
Parte pantalla = new Parte("Pantalla LCD 9\"");

// Crear componentes compuestos
ComponenteCompuesto cofre = new ComponenteCompuesto("Cofre");
cofre.Agregar(motor);
cofre.Agregar(aa);

ComponenteCompuesto cabina = new ComponenteCompuesto("Cabina");
cabina.Agregar(volante);
cabina.Agregar(gps);
cabina.Agregar(pantalla);

ComponenteCompuesto automovil = new ComponenteCompuesto("Automóvil Deportivo");
automovil.Agregar(cabina);
automovil.Agregar(cofre);
automovil.Agregar(llanta);

// Mostrar la estructura completa del automóvil
automovil.MostrarDetalles();
