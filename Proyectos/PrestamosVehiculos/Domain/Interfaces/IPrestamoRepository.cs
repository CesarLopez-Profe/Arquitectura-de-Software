using PrestamosVehiculos.Domain.Aggregates;

namespace PrestamosVehiculos.Domain.Interfaces
{
    public interface IPrestamoRepository
    {
        Prestamo ObtenerPorId(int id);
        void Guardar(Prestamo prestamo);
    }
}
