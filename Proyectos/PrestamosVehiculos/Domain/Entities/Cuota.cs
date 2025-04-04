namespace PrestamosVehiculos.Domain.Entities
{
    public class Cuota
    {
        public int Id { get; private set; }
        public decimal Monto { get; private set; }
        public DateTime FechaVencimiento { get; private set; }
        public bool Pagada { get; private set; }

        protected Cuota() { }
        public Cuota(decimal monto, DateTime fechaVencimiento)
        {
            if (monto <= 0) throw new ArgumentException("El monto debe ser mayor a 0.");
            Monto = monto;
            FechaVencimiento = fechaVencimiento;
            Pagada = false;
        }

        public void MarcarComoPagada()
        {
            if (Pagada) throw new InvalidOperationException("La cuota ya está pagada.");
            Pagada = true;
        }

    }
}
