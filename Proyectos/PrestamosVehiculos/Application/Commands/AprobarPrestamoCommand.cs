using MediatR;

namespace PrestamosVehiculos.Application.Commands
{
    public class AprobarPrestamoCommand : IRequest<bool>
    {
        public int PrestamoId { get; set; }
    }
}
