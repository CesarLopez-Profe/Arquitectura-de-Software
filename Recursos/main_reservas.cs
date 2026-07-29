using System;
using System.Collections.Generic;

namespace ReservasAereas
{
   

    public class Pasajero
    {
        public string Nombre;
        public string Documento;
        public string Email;

        public Pasajero(string nombre, string documento, string email)
        {
            Nombre = nombre;
            Documento = documento;
            Email = email;
        }
    }

    public class Vuelo
    {
        public string Codigo;
        public string Origen;
        public string Destino;
        public string Fecha;
        public double Precio;
        public string TipoVuelo; // "Nacional", "Internacional", "Charter"

        public Vuelo(string codigo, string origen, string destino, string fecha, double precio, string tipoVuelo)
        {
            Codigo = codigo;
            Origen = origen;
            Destino = destino;
            Fecha = fecha;
            Precio = precio;
            TipoVuelo = tipoVuelo;
        }
    }

    public class Reserva
    {
        public int Codigo;
        public Pasajero Pasajero;
        public Vuelo Vuelo;
        public string Estado; // "Activa", "Anulada", "Cambiada"
        public string MetodoPago; // "Tarjeta", "Efectivo", "PSE"
        public string FechaReserva;

        public Reserva(int codigo, Pasajero pasajero, Vuelo vuelo, string metodoPago, string fechaReserva)
        {
            Codigo = codigo;
            Pasajero = pasajero;
            Vuelo = vuelo;
            MetodoPago = metodoPago;
            FechaReserva = fechaReserva;
            Estado = "Activa";
        }

        public virtual void MarcarComoAnulada()
        {
            Estado = "Anulada";
        }
    }

    public class ReservaVIP : Reserva
    {
        public ReservaVIP(int codigo, Pasajero pasajero, Vuelo vuelo, string metodoPago, string fechaReserva)
            : base(codigo, pasajero, vuelo, metodoPago, fechaReserva)
        {
        }

        public override void MarcarComoAnulada()
        {
            throw new Exception("Las reservas VIP no se pueden anular");
        }
    }

    public interface IReserva
    {
        void CrearReserva(Pasajero pasajero, Vuelo vuelo, string metodoPago);
        void AnularReserva(int codigo);
        void CambiarReserva(int codigo, Vuelo nuevoVuelo);
        void ImprimirReserva(int codigo);
        void VerHistorialReservas();
        void EnviarEmailConfirmacion(Pasajero pasajero, string mensaje);
        double CalcularImpuestos(Vuelo vuelo);
        void GenerarFactura(int codigo);
    }

    public class EmailSender
    {
        public void Enviar(string destinatario, string asunto, string mensaje)
        {
            // Simulación: en un caso real aquí iría un SmtpClient hardcodeado.
            Console.WriteLine($"[EMAIL a {destinatario}] {asunto}: {mensaje}");
        }
    }

    public class BaseDatosReservas
    {
        public static List<Reserva> Reservas = new List<Reserva>();

        public void Guardar(Reserva reserva)
        {
            Reservas.Add(reserva);
        }
    }

    public class ImpresoraTickets
    {
        public void Imprimir(Reserva reserva)
        {
            Console.WriteLine("---------- TICKET ----------");
            Console.WriteLine("Codigo reserva: " + reserva.Codigo);
            Console.WriteLine("Pasajero: " + reserva.Pasajero.Nombre);
            Console.WriteLine("Vuelo: " + reserva.Vuelo.Codigo + " (" + reserva.Vuelo.Origen + " -> " + reserva.Vuelo.Destino + ")");
            Console.WriteLine("Estado: " + reserva.Estado);
            Console.WriteLine("-----------------------------");
        }
    }

    public class GestorReservas : IReserva
    {
        private EmailSender emailSender = new EmailSender();
        private BaseDatosReservas baseDatos = new BaseDatosReservas();
        private ImpresoraTickets impresora = new ImpresoraTickets();
        private int contadorCodigo = 1;

        public void CrearReserva(Pasajero pasajero, Vuelo vuelo, string metodoPago)
        {
            double impuestos = CalcularImpuestos(vuelo);
            double total = vuelo.Precio + impuestos;

            // Reglas de negocio, cálculo de precio, persistencia, notificación
            // e impresión, todo mezclado en el mismo método.
            Reserva nuevaReserva;
            if (vuelo.Precio > 2000000)
            {
                // "Detecta" que es VIP solo por el precio, con un if suelto.
                nuevaReserva = new ReservaVIP(contadorCodigo, pasajero, vuelo, metodoPago, DateTime.Now.ToString());
            }
            else
            {
                nuevaReserva = new Reserva(contadorCodigo, pasajero, vuelo, metodoPago, DateTime.Now.ToString());
            }

            contadorCodigo++;

            baseDatos.Guardar(nuevaReserva);

            emailSender.Enviar(pasajero.Email, "Reserva creada",
                "Su reserva " + nuevaReserva.Codigo + " fue creada. Total a pagar: " + total);

            impresora.Imprimir(nuevaReserva);
        }

        public void AnularReserva(int codigo)
        {
            Reserva reserva = BuscarReserva(codigo);
            if (reserva == null)
            {
                Console.WriteLine("No existe la reserva " + codigo);
                return;
            }

            // Aquí se nota la violación de LSP: si "reserva" resulta ser un
            // ReservaVIP, esta llamada revienta con excepción sin que el
            // que programó este método lo haya anticipado explícitamente.
            reserva.MarcarComoAnulada();

            emailSender.Enviar(reserva.Pasajero.Email, "Reserva anulada",
                "Su reserva " + reserva.Codigo + " fue anulada.");
        }

        public void CambiarReserva(int codigo, Vuelo nuevoVuelo)
        {
            Reserva reserva = BuscarReserva(codigo);
            if (reserva == null)
            {
                Console.WriteLine("No existe la reserva " + codigo);
                return;
            }

            // Lógica de negocio (cobro de penalidad) resuelta con ifs
            // encadenados sobre un string, en vez de polimorfismo.
            // Si mañana aparece un nuevo TipoVuelo, hay que volver a
            // modificar este mismo método -> otra vez OCP.
            double penalidad = 0;
            if (reserva.Vuelo.TipoVuelo == "Nacional")
            {
                penalidad = 20000;
            }
            else if (reserva.Vuelo.TipoVuelo == "Internacional")
            {
                penalidad = 80000;
            }
            else if (reserva.Vuelo.TipoVuelo == "Charter")
            {
                penalidad = 150000;
            }

            reserva.Vuelo = nuevoVuelo;
            reserva.Estado = "Cambiada";

            emailSender.Enviar(reserva.Pasajero.Email, "Reserva cambiada",
                "Su reserva " + reserva.Codigo + " fue cambiada. Penalidad cobrada: " + penalidad);

            impresora.Imprimir(reserva);
        }

        public void ImprimirReserva(int codigo)
        {
            Reserva reserva = BuscarReserva(codigo);
            if (reserva == null)
            {
                Console.WriteLine("No existe la reserva " + codigo);
                return;
            }
            impresora.Imprimir(reserva);
        }

        public void VerHistorialReservas()
        {
            Console.WriteLine("===== HISTORIAL DE RESERVAS =====");
            foreach (Reserva r in BaseDatosReservas.Reservas)
            {
                Console.WriteLine(r.Codigo + " | " + r.Pasajero.Nombre + " | " + r.Vuelo.Codigo + " | " + r.Estado);
            }
        }

        public void EnviarEmailConfirmacion(Pasajero pasajero, string mensaje)
        {
            emailSender.Enviar(pasajero.Email, "Notificacion", mensaje);
        }

        public double CalcularImpuestos(Vuelo vuelo)
        {
            if (vuelo.TipoVuelo == "Nacional")
            {
                return vuelo.Precio * 0.08;
            }
            else if (vuelo.TipoVuelo == "Internacional")
            {
                return vuelo.Precio * 0.19;
            }
            else if (vuelo.TipoVuelo == "Charter")
            {
                return vuelo.Precio * 0.05;
            }
            return 0;
        }

        public void GenerarFactura(int codigo)
        {
            Reserva reserva = BuscarReserva(codigo);
            if (reserva == null)
            {
                Console.WriteLine("No existe la reserva " + codigo);
                return;
            }

            double impuestos = CalcularImpuestos(reserva.Vuelo);
            Console.WriteLine("FACTURA - Reserva " + reserva.Codigo);
            Console.WriteLine("Vuelo: " + reserva.Vuelo.Precio + " + Impuestos: " + impuestos);
        }

        private Reserva BuscarReserva(int codigo)
        {
            foreach (Reserva r in BaseDatosReservas.Reservas)
            {
                if (r.Codigo == codigo) return r;
            }
            return null;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            GestorReservas gestor = new GestorReservas();

            Pasajero p1 = new Pasajero("Carlos Lopez", "123456", "carlos@correo.com");
            Vuelo v1 = new Vuelo("AV101", "Bogota", "Medellin", "2026-08-01", 350000, "Nacional");
            Vuelo v2 = new Vuelo("AV202", "Bogota", "Miami", "2026-09-10", 2500000, "Internacional");

            gestor.CrearReserva(p1, v1, "Tarjeta");
            gestor.CrearReserva(p1, v2, "PSE");

            gestor.VerHistorialReservas();

            gestor.CambiarReserva(1, new Vuelo("AV103", "Bogota", "Cali", "2026-08-05", 400000, "Nacional"));
            gestor.ImprimirReserva(1);

            gestor.AnularReserva(1);

            // Esto lanza excepcion porque la reserva 2 quedo como ReservaVIP
            // (el precio de v2 fue mayor a 2'000.000) y ReservaVIP no permite anular.
            gestor.AnularReserva(2);
        }
    }
}
