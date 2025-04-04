using PrestamosVehiculos.Domain.Entities;

namespace PrestamosVehiculos.Domain.Services
{
    public class EvaluadorCreditoService
    {
        private const int PuntajeMinimoAprobacion = 600;

        /*public bool EsClienteElegible(int historialCrediticio)
        {
            return historialCrediticio >= PuntajeMinimoAprobacion;
        }*/
        public bool EsClienteElegible(Cliente cliente)
        {
            return cliente.HistorialCrediticio >= 600;
        }


    }
}
