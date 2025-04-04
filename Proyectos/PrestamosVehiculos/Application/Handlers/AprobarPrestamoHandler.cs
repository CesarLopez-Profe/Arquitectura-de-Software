using MediatR;
using PrestamosVehiculos.Application.Commands;
using PrestamosVehiculos.Domain.Interfaces;

namespace PrestamosVehiculos.Application.Handlers
{
    public class AprobarPrestamoHandler : IRequestHandler<AprobarPrestamoCommand, bool>
    {
        private readonly IPrestamoRepository _repository;
        private readonly IUnitOfWork _uow;

        public AprobarPrestamoHandler(IPrestamoRepository repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        public async Task<bool> Handle(AprobarPrestamoCommand request, CancellationToken cancellationToken)
        {
            var prestamo = _repository.ObtenerPorId(request.PrestamoId);
            if (prestamo == null) return false;

            prestamo.Aprobar();
            _repository.Guardar(prestamo);

            await _uow.CommitAsync();

            return true;
        }
    }
}
