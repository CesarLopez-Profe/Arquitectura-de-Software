using PrestamosVehiculos.Domain.Entities;
using PrestamosVehiculos.Domain.Interfaces;
using PrestamosVehiculos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace PrestamosVehiculos.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;
        private readonly ICacheService _cache;


        public ClienteRepository(AppDbContext context, ICacheService cache)
        {
            _context = context;
            _cache = cache;
        }

        public Cliente ObtenerPorId(int id)
        {
            string cacheKey = $"cliente_{id}";

            return _cache.GetOrSet(cacheKey, () =>
            {
                var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);
                return cliente ?? throw new KeyNotFoundException($"Cliente con ID {id} no encontrado.");
            }, TimeSpan.FromMinutes(10));
        }

        public void Guardar(Cliente cliente)
        {
            var existente = _context.Clientes.AsNoTracking().FirstOrDefault(c => c.Id == cliente.Id);

            if (existente is null)
                _context.Clientes.Add(cliente);
            else
                _context.Clientes.Update(cliente);

            _context.SaveChanges();
            
            //_cache.Remove($"cliente_{cliente.Id}"); // Invalida la caché, la limpia
        }

        public bool Existe(int id)
        {
            return _context.Clientes.Any(c => c.Id == id);
        }
    }
}
