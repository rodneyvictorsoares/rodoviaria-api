namespace Rodoviaria.API.Models
{
    public class VendaPassagem
    {
        public string Passageiro { get; set; } = string.Empty;
        public string cpf { get; set; } = string.Empty;
        public string rg { get; set; } = string.Empty;
        public int TipoId { get; set; }
        public int ViagemId { get; set; }
        public int Cadeira { get; set; }
    }
}
