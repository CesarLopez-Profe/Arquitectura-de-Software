namespace PrestamosVehiculos.Domain.Services
{
    using PrestamosVehiculos.Domain.Entities;
    using PrestamosVehiculos.Domain.ValueObjects;

    public class CalculoCuotasService
    {
        public List<Cuota> GenerarCuotas(decimal monto, int plazo, TasaInteres tasaInteres)
        {
            List<Cuota> cuotas = new();
            decimal montoMensual = monto / plazo + (monto * tasaInteres.Valor / 100 / plazo);

            for (int i = 1; i <= plazo; i++)
            {
                cuotas.Add(new Cuota(montoMensual, DateTime.Now.AddMonths(i)));
            }

            return cuotas;
        }
    }
}
