using Microsoft.AspNetCore.Mvc;
using BarberShop.Models;
using BarberShop.Models.Contratos;
using BarberShop.Data.Contratos;

namespace BarberShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionaisController : ControllerBase
    {
        
        private readonly IProfissionalModel _profissionalModel;

        public ProfissionaisController(IProfissionalModel profissionalModel)
        {
            _profissionalModel = profissionalModel;
            
        }

        
        [HttpGet]
        public async Task<ActionResult> PegarTodosProfissionais()
        {
            try
            {
                var profissionais = await _profissionalModel.PegarTodosProfissionais(true);
                if(profissionais == null) return NotFound("Nenhum evento encontrado!");

                return Ok(profissionais);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar Profissionais. Erro: {erro.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> PegarProfissionalPeloId(int id)
        {
             try
            {
                var profissional = await _profissionalModel.PegarProfissionalPeloId(id, true);
                if(profissional == null) return NotFound("Nenhum Profissional foi encontrado pelo Id");

                return Ok(profissional);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar Profissional. Erro: {erro.Message}");
            }
        }

        [HttpGet("{nome}/nome")]
        public async Task<IActionResult> PegarTodosProfissionaisPeloNome(string nome)
        {
             try
            {
                var profissional = await _profissionalModel.PegarTodosProfissionaisPeloNome(nome, true);
                if(profissional == null) return NotFound("Nenhum Profissionais foi encontrados pelo Nome");

                return Ok(profissional);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar Profissionais. Erro: {erro.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult>AdicionarProfissional(Profissional model)
        {
           try
            {
                var profissional = await _profissionalModel.AdicionarProfissional(model);
                if(profissional == null) return BadRequest("Erro ao tentar adicionar um Profissional");

                return Ok(profissional);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar Adicionar Profissional. Erro: {erro.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>AtualizarProfissional(int id, Profissional model)
        {
           try
            {
                var profissional = await _profissionalModel.AtualizarProfissional(id, model);
                if(profissional == null) return BadRequest("Erro ao tentar atualizar um Profissional");

                return Ok(profissional);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar Atualizar Profissional. Erro: {erro.Message}");
            }
        }


        
        [HttpDelete("{id}")]
        public async Task<IActionResult> ApagarProfissional(int id)
        {
            try
            {
                return await _profissionalModel.ApagarProfissional(id) 
                    ? Ok(new { mensagem ="Deletado!" }) 
                    : BadRequest("Profissional não Deletado");
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar Apagar Profissional. Erro: {erro.Message}");
            }
        }
    }
}
