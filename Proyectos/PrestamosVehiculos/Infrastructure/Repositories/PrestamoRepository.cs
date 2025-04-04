using Microsoft.EntityFrameworkCore;
using PrestamosVehiculos.Domain.Aggregates;
using PrestamosVehiculos.Domain.Interfaces;
using PrestamosVehiculos.Infrastructure.Persistence;

namespace PrestamosVehiculos.Infrastructure.Repositories
{
    public class PrestamoRepository : IPrestamoRepository
    {
        private readonly AppDbContext _context;

        public PrestamoRepository(AppDbContext context)
        {
            _context = context;
        }

        public Prestamo ObtenerPorId(int id)
        {
            return _context.Prestamos.Include(p => p.Cuotas)
                                     .FirstOrDefault(p => p.Id == id);
        }

        public void Guardar(Prestamo prestamo)
        {
            if (_context.Prestamos.Any(p => p.Id == prestamo.Id))
            {
                _context.Prestamos.Update(prestamo);
            }
            else
            {
                _context.Prestamos.Add(prestamo);
            }
            _context.SaveChanges();
        }
    }
}
