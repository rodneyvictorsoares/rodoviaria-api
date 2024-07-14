namespace Rodoviaria.API.Models
{
    public class CadastroViagem
    {
        public string Origem { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public DateTime DataPartida { get; set; }
        public DateTime DataChegada { get; set; }
        public decimal Preco { get; set; }
    }
}
