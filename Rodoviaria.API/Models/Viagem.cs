namespace Rodoviaria.API.Models
{
    public class Viagem
    {
        public int ViagemId { get; set; }
        public string Destino { get; set; } = string.Empty;
        public DateTime DataPartida { get; set; }
        public decimal Preco { get; set; }
        public int LugaresLivres { get; set; }
        public int Gratuidades { get; set; }
    }
}
