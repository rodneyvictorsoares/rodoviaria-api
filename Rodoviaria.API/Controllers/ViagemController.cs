using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rodoviaria.API.Models;
using System.Data.SqlClient;

namespace Rodoviaria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViagemController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private string connString = "RodoviariaBD";

        public ViagemController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<List<Viagem>>> GetAllViagens()
        {
            try
            {
                using var conexao = new SqlConnection(_configuration.GetConnectionString(connString));
                var viagens = await conexao.QueryAsync<Viagem>("SELECT * FROM VW_Viagens");
                return Ok(viagens);
            }
            catch (Exception)
            {

                return BadRequest("Não foi possível consultar as viagens.");
            }
        }

        [HttpGet("{ViagemId}")]
        public async Task<ActionResult<Viagem>> GetViagem(int ViagemId)
        {
            try
            {
                using var conexao = new SqlConnection(_configuration.GetConnectionString(connString));
                var viagem = await conexao.QueryFirstOrDefaultAsync<Viagem>("SELECT * FROM VW_Viagens " +
                    "WHERE ViagemId = @Id", new {Id = ViagemId});
                return Ok(viagem);
            }
            catch (Exception)
            {

                return BadRequest("Não foi possível consultar as viagens.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarViagem(CadastroViagem cadastro)
        {
            try
            {
                using var conexao = new SqlConnection(_configuration.GetConnectionString(connString));
                await conexao.ExecuteAsync("EXEC SP_Cadastrar_Viagem @Origem, @Destino, @DataPartida, @DataChegada, @Preco", cadastro);
                return Ok("Viagem Cadastrada com sucesso!");
            }
            catch (Exception)
            {

                return BadRequest("Não foi possível cadastrar a viagem.");
            }
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarViagem(Viagem viagem)
        {
            try
            {
                using var conexao = new SqlConnection(_configuration.GetConnectionString(connString));
                await conexao.ExecuteAsync("UPDATE VW_Viagens SET Destino = @Destino, " +
                    "DataPartida = @DataPartida, Preco = @Preco, LugaresLivres = @LugaresLivres, " +
                    "Gratuidades = @Gratuidades WHERE ViagemId = @ViagemId", viagem);
                return Ok("Viagem Atualizada com sucesso!");
            }
            catch (Exception)
            {

                return BadRequest("Não foi possível atualizar a viagem.");
            }
        }

        [HttpDelete("{ViagemId}")]
        public async Task<ActionResult> DeletarViagem(int ViagemId)
        {
            try
            {
                using var conexao = new SqlConnection(_configuration.GetConnectionString(connString));
                await conexao.ExecuteAsync("DELETE FROM VW_Viagens WHERE ViagemId = @Id", new {Id = ViagemId});
                return Ok("Viagem deletada com sucesso!");
            }
            catch (Exception)
            {

                return BadRequest("Não foi possível deletar a viagem.");
            }
        }

    }
}
