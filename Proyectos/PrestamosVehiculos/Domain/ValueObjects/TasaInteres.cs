namespace PrestamosVehiculos.Domain.ValueObjects
{
    public class TasaInteres
    {
        public decimal Valor { get; private set; }

        public TasaInteres(decimal valor)
        {
            if (valor < 0 || valor > 100) throw new ArgumentException("La tasa de interés debe estar entre 0 y 100.");
            Valor = valor;
        }
    }
}
