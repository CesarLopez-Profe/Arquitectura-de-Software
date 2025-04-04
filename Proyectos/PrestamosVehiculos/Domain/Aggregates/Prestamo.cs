using PrestamosVehiculos.Domain.Entities;

namespace PrestamosVehiculos.Domain.Aggregates
{
    using PrestamosVehiculos.Domain.Services;
    using PrestamosVehiculos.Domain.ValueObjects;

    public class Prestamo
    {
        public int Id { get; private set; }
        public Cliente Cliente { get; private set; }
        public decimal Monto { get; private set; }
        public int Plazo { get; private set; }
        public string Estado { get; private set; }
        public List<Cuota> Cuotas { get; private set; } = new();
        private readonly CalculoCuotasService _calculoCuotas;

        protected Prestamo() { } //Para que EF pueda encontrar un constructor con parámetros que pueda mapear y así evitar error 500

        public Prestamo(Cliente cliente, decimal monto, int plazo, CalculoCuotasService calculoCuotas)
        {
            if (monto <= 0) throw new ArgumentException("El monto debe ser mayor a 0.");
            if (plazo <= 0) throw new ArgumentException("El plazo debe ser positivo.");
            //if (!cliente.EsAptoParaPrestamo()) throw new InvalidOperationException("El cliente no es elegible.");

            Cliente = cliente;
            Monto = monto;
            Plazo = plazo;
            Estado = "PENDIENTE";
            _calculoCuotas = calculoCuotas;

            Cuotas = _calculoCuotas.GenerarCuotas(monto, plazo, new TasaInteres(5.5m)); // Ejemplo tasa 5.5%
        }

        public void Aprobar()
        {
            if (Estado != "PENDIENTE") throw new InvalidOperationException("El préstamo ya ha sido procesado.");
            Estado = "APROBADO";
        }
    }
}
