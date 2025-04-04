namespace PrestamosVehiculos.Domain.Services
{
    using PrestamosVehiculos.Domain.Entities;

    public class ValidacionPagoService
    {
        public bool EsPagoValido(decimal montoPago, decimal saldoPendiente)
        {
            return montoPago > 0 && montoPago <= saldoPendiente;
        }
    }
}
