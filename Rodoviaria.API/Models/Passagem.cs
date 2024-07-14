namespace Rodoviaria.API.Models
{
    public class Passagem
    {
        public int PassagemId { get; set; }
        public string Passageiro { get; set; } = string.Empty;
        public string cpf { get; set; } = string.Empty ;
        public string rg { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public int Cadeira { get; set; }
        public Boolean EhMeia { get; set; }
        public string Destino { get; set; } = string.Empty;
        public DateTime DataPartida { get; set; }
        public decimal Preco { get; set; }
    }
}
