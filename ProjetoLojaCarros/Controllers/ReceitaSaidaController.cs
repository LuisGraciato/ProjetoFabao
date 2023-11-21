using AutoMapper;
using DevIOApi.ViewModels;
using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;
using DevIoBusiness.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiFabao.Controllers
{
    [ApiController]
    [Route("api/receitas-saida")]
    public class ReceitaSaidaController : ControllerBase
    {
        private readonly IReceitaSaidaService _receitaSaidaService;
        private readonly IMapper _mapper;

        public ReceitaSaidaController(IReceitaSaidaService receitaSaidaService, IMapper mapper)
        {
            _receitaSaidaService = receitaSaidaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReceitasSaida()
        {
            var receitasSaida = await _receitaSaidaService.GetAllReceitasSaida();
            var receitasSaidaViewModel = _mapper.Map<IEnumerable<ReceitaSaidaViewModel>>(receitasSaida);
            return Ok(receitasSaidaViewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReceitaSaidaById(int id)
        {
            var receitaSaida = await _receitaSaidaService.GetReceitaSaidaById(id);
            if (receitaSaida == null)
                return NotFound();

            var receitaSaidaViewModel = _mapper.Map<ReceitaSaidaViewModel>(receitaSaida);
            return Ok(receitaSaidaViewModel);
        }

        [HttpGet("porperiodo")]
        public async Task<IActionResult> GetReceitasSaodaPorPeriodo([FromQuery] DateTime dataInicio, [FromQuery] DateTime dataFim)
        {
            var receitasSaidaPorPeriodo = await _receitaSaidaService.GetReceitasSaidaPorPeriodo(dataInicio, dataFim);
            var receitasSaidaPorPeriodoViewModel = _mapper.Map<IEnumerable<ReceitaSaidaViewModel>>(receitasSaidaPorPeriodo);
            return Ok(receitasSaidaPorPeriodoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddReceitaSaida([FromBody] ReceitaSaidaViewModel receitaSaidaViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var receitaSaida = _mapper.Map<ReceitaSaida>(receitaSaidaViewModel);
            receitaSaida.DataSaida = DateTime.Now;

            var createdReceitaSaida = await _receitaSaidaService.AddReceitaSaida(receitaSaida);
            var createdReceitaSaidaViewModel = _mapper.Map<ReceitaSaidaViewModel>(createdReceitaSaida);

            return CreatedAtAction(nameof(GetReceitaSaidaById), new { id = createdReceitaSaida.Id }, createdReceitaSaidaViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReceitaSaida(int id, [FromBody] ReceitaSaidaViewModel receitaSaidaViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var receitaSaida = await _receitaSaidaService.GetReceitaSaidaById(id);
            if (receitaSaida == null)
                return NotFound();

            receitaSaida.DataSaida = receitaSaidaViewModel.DataSaida;
            receitaSaida.Valor = receitaSaidaViewModel.Valor;

            var updatedReceitaSaida = await _receitaSaidaService.UpdateReceitaSaida(receitaSaida);
            var updatedReceitaSaidaViewModel = _mapper.Map<ReceitaSaidaViewModel>(updatedReceitaSaida);

            return Ok(updatedReceitaSaidaViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceitaSaida(int id)
        {
            var deletedReceitaSaida = await _receitaSaidaService.GetReceitaSaidaById(id);
            if (deletedReceitaSaida == null)
                return NotFound();

            await _receitaSaidaService.DeleteReceitaSaida(id);

            var deletedReceitaSaidaViewModel = _mapper.Map<ReceitaSaidaViewModel>(deletedReceitaSaida);
            return Ok(deletedReceitaSaidaViewModel);
        }
    }
}
