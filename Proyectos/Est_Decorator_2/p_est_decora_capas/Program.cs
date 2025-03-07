// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using p_est_decora_capas.Clases;
using p_est_decora_capas.Interfaces;

IProcesadorPagosBase pago = new ProcesadorPagosBase();

Console.WriteLine("\nCaso 1: Solo validación y pago básico");
pago = new DecoradorValidacion(pago);
pago.ProcesarPago(100);

Console.WriteLine("\nCaso 2: Validación + Impuestos + Pago básico");
pago = new DecoradorImpuestos(pago);
pago.ProcesarPago(200);

Console.WriteLine("\nCaso 3: Validación + Impuestos + Auditoría + Pago básico");
pago = new DecoradorAuditoria(pago);
pago.ProcesarPago(300);

Console.WriteLine("\nCaso 4: Validación + Impuestos + Auditoría + Notificación + Pago básico");
pago = new DecoradorNotificacion(pago);
pago.ProcesarPago(400);
