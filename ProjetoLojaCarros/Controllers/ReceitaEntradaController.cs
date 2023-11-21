using AutoMapper;
using DevIOApi.ViewModels;
using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiFabao.Controllers
{
    [ApiController]
    [Route("api/receitasentrada")]
    public class ReceitaEntradaController : ControllerBase
    {
        private readonly IReceitaEntradaService _receitaEntradaService;
        private readonly IMapper _mapper;

        public ReceitaEntradaController(IReceitaEntradaService receitaEntradaService, IMapper mapper)
        {
            _receitaEntradaService = receitaEntradaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReceitasEntrada()
        {
            var receitasEntrada = await _receitaEntradaService.GetAllReceitasEntrada();
            var receitasEntradaViewModel = _mapper.Map<IEnumerable<ReceitaEntradaViewModel>>(receitasEntrada);
            return Ok(receitasEntradaViewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReceitaEntradaById(int id)
        {
            var receitaEntrada = await _receitaEntradaService.GetReceitaEntradaById(id);
            if (receitaEntrada == null)
                return NotFound();

            var receitaEntradaViewModel = _mapper.Map<ReceitaEntradaViewModel>(receitaEntrada);
            return Ok(receitaEntradaViewModel);
        }

        [HttpGet("porperiodo")]
        public async Task<IActionResult> GetReceitasEntradaPorPeriodo([FromQuery] DateTime dataInicio, [FromQuery] DateTime dataFim)
        {
            var receitasEntradaPorPeriodo = await _receitaEntradaService.GetReceitasEntradaPorPeriodo(dataInicio, dataFim);
            var receitasEntradaPorPeriodoViewModel = _mapper.Map<IEnumerable<ReceitaEntradaViewModel>>(receitasEntradaPorPeriodo);
            return Ok(receitasEntradaPorPeriodoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddReceitaEntrada([FromBody] ReceitaEntradaViewModel receitaEntradaViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var receitaEntrada = _mapper.Map<ReceitaEntrada>(receitaEntradaViewModel);
            receitaEntrada.DataEntrada = DateTime.Now;

            var createdReceitaEntrada = await _receitaEntradaService.AddReceitaEntrada(receitaEntrada);
            var createdReceitaEntradaViewModel = _mapper.Map<ReceitaEntradaViewModel>(createdReceitaEntrada);

            return CreatedAtAction(nameof(GetReceitaEntradaById), new { id = createdReceitaEntrada.Id }, createdReceitaEntradaViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReceitaEntrada(int id, [FromBody] ReceitaEntradaViewModel receitaEntradaViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var receitaEntrada = await _receitaEntradaService.GetReceitaEntradaById(id);
            if (receitaEntrada == null)
                return NotFound();

            receitaEntrada.DataEntrada = receitaEntradaViewModel.DataEntrada;
            receitaEntrada.Valor = receitaEntradaViewModel.Valor;

            var updatedReceitaEntrada = await _receitaEntradaService.UpdateReceitaEntrada(receitaEntrada);
            var updatedReceitaEntradaViewModel = _mapper.Map<ReceitaEntradaViewModel>(updatedReceitaEntrada);

            return Ok(updatedReceitaEntradaViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceitaEntrada(int id)
        {
            var deletedReceitaEntrada = await _receitaEntradaService.GetReceitaEntradaById(id);
            if (deletedReceitaEntrada == null)
                return NotFound();

            await _receitaEntradaService.DeleteReceitaEntrada(id);

            var deletedReceitaEntradaViewModel = _mapper.Map<ReceitaEntradaViewModel>(deletedReceitaEntrada);
            return Ok(deletedReceitaEntradaViewModel);
        }
    }
}
