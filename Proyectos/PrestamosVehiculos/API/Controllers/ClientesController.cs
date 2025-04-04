using Microsoft.AspNetCore.Mvc;
using PrestamosVehiculos.Domain.Entities;
using PrestamosVehiculos.Domain.Interfaces;
using PrestamosVehiculos.Domain.Services;
using PrestamosVehiculos.Application.DTOs;

namespace PrestamosVehiculos.API.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _repo;
        private readonly IUnitOfWork _uow;
        //private readonly EvaluadorCreditoService _evaluador;

        public ClientesController(IClienteRepository repo, IUnitOfWork uow, EvaluadorCreditoService evaluador)
        {
            _repo = repo;
            _uow = uow;
            //_evaluador = evaluador;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearClienteDto dto)
        {
            var cliente = new Cliente(0, dto.Nombre, dto.HistorialCrediticio);//, _evaluador);
            _repo.Guardar(cliente);
            await _uow.CommitAsync();
            return Ok(cliente);
        }
    }
}
