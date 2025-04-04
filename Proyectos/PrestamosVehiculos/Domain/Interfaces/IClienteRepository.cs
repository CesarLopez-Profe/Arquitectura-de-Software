using PrestamosVehiculos.Domain.Entities;

namespace PrestamosVehiculos.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Cliente ObtenerPorId(int id);
        void Guardar(Cliente cliente);
        bool Existe(int id);
    }
}
