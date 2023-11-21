using AutoMapper;
using DevIOApi.ViewModels;
using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiFabao.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            var clientes = await _clienteService.GetAllClientes();
            var clienteViewModel = _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);
            return Ok(clienteViewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            var cliente = await _clienteService.GetClienteById(id);
            if (cliente == null)
                return NotFound();

            var clienteViewModel = _mapper.Map<ClienteViewModel>(cliente);
            return Ok(clienteViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddCliente([FromBody] ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            var createdCliente = await _clienteService.AddCliente(cliente);
            var createdClienteViewModel = _mapper.Map<ClienteViewModel>(createdCliente);

            return CreatedAtAction(nameof(GetClienteById), new { id = createdCliente.Id }, createdClienteViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, [FromBody] ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cliente = await _clienteService.GetClienteById(id);
            if (cliente == null)
                return NotFound();

            cliente.Nome = clienteViewModel.Nome;
            cliente.Email = clienteViewModel.Email;
            cliente.CPF = clienteViewModel.CPF;
            cliente.DataNascimento = (DateTime)clienteViewModel.DataNascimento;
            

            var updatedCliente = await _clienteService.UpdateCliente(cliente);
            var updatedClienteViewModel = _mapper.Map<ClienteViewModel>(updatedCliente);

            return Ok(updatedClienteViewModel);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var deletedCliente = await _clienteService.GetClienteById(id);
            if (deletedCliente == null)
                return NotFound();

            await _clienteService.DeleteCliente(id);

            var deletedClienteViewModel = _mapper.Map<ClienteViewModel>(deletedCliente);
            return Ok(deletedClienteViewModel);
        }

    }
}
