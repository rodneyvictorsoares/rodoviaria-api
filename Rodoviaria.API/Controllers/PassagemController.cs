using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rodoviaria.API.Models;
using System.Data.SqlClient;

namespace Rodoviaria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassagemController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private string connString = "RodoviariaBD";

        public PassagemController(IConfiguration configuration)
        {
            _configuration = configuration;         
        }

        [HttpGet]
        public async Task<ActionResult<List<Passagem>>> GetAllPassagens()
        {
            try
            {
                using var connection = new SqlConnection(_configuration.GetConnectionString(connString));
                var passagens = await connection.QueryAsync<Passagem>("SELECT * FROM VW_Passagem");
                if (passagens == null)
                {
                    return NotFound("Não foram encontradas as passagens.");
                }
                return Ok(passagens);
            }
            catch (Exception)
            {

                return BadRequest("Não foi possível acessar as passagens.");
            }
            
        }

        [HttpGet("{PassagemId}")]
        public async Task<ActionResult<Passagem>> GetPassagem(int PassagemId)
        {
            try
            {
                using var connection = new SqlConnection(_configuration.GetConnectionString(connString));
                var passagem = await connection.QueryFirstAsync<Passagem>("SELECT * FROM VW_Passagem " +
                    "WHERE PassagemId = @Id", new {Id = PassagemId});
                if (passagem == null)
                {
                    return NotFound("Não foi encontrada a passagem.");
                }
                return Ok(passagem);
            }
            catch (Exception)
            {

                return BadRequest("Não foi possível acessar as passagens.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> VenderPassagem(VendaPassagem venda)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString(connString));
            var response = await connection.QueryFirstAsync<int>("EXEC SP_Vender_Passagem " +
                "@Passageiro, @cpf, @rg, @TipoId, @ViagemId, @Cadeira", venda);
            switch (response)
            {
                case 0:
                    return Ok("Passageiro: " + venda.Passageiro + " adiquiriu a passagem com sucesso");
                    break;
                case 1:
                    return BadRequest("CADEIRA FORA DO INTERVALO DISPONIVEL");
                    break;
                case 2:
                    return BadRequest("TIPO DE PASSAGEM INCORRETO");
                    break;
                case 3:
                    return BadRequest("CADEIRA JÁ VENDIDA");
                    break;
                case 4:
                    return BadRequest("VIAGEM INEXISTENTE");
                    break;
                case 5:
                    return BadRequest("GRATUIDADES ESGOTADAS");
                    break;
                default:
                    return BadRequest("ERRO NA COMUNICAÇÃO DA BASE");
                    break;
            }
        }
    }
}
