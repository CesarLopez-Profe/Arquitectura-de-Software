using Microsoft.AspNetCore.Mvc;
using MediatR;
using PrestamosVehiculos.Application.Commands;
using PrestamosVehiculos.Domain.Interfaces;
using PrestamosVehiculos.Application.DTOs;
using PrestamosVehiculos.Domain.Aggregates;
using PrestamosVehiculos.Domain.Services;

namespace PrestamosVehiculos.API.Controllers
{

    [Route("api/prestamos")]
    [ApiController]
    public class PrestamosController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepo;
        private readonly IPrestamoRepository _prestamoRepo;
        private readonly IUnitOfWork _uow;
        private readonly CalculoCuotasService _calculoCuotas;
        private readonly EvaluadorCreditoService _evaluador;

        public PrestamosController(
            IClienteRepository clienteRepo,
            IPrestamoRepository prestamoRepo,
            IUnitOfWork uow,
            CalculoCuotasService calculoCuotas)
        {
            _clienteRepo = clienteRepo;
            _prestamoRepo = prestamoRepo;
            _uow = uow;
            _calculoCuotas = calculoCuotas;
            _evaluador = new EvaluadorCreditoService();
        }

        [HttpPost]
        public async Task<IActionResult> CrearPrestamo([FromBody] CrearPrestamoDto dto)
        {
            var cliente = _clienteRepo.ObtenerPorId(dto.ClienteId);
            if (cliente == null)
                return NotFound($"Cliente con ID {dto.ClienteId} no existe.");
            if(!_evaluador.EsClienteElegible(cliente))
                return BadRequest($"Cliente con ID {dto.ClienteId} no existe.");

            var prestamo = new Prestamo(cliente, dto.Monto, dto.PlazoMeses, _calculoCuotas);
            _prestamoRepo.Guardar(prestamo);
            await _uow.CommitAsync();

            return Ok(prestamo);

        }
    }
}
