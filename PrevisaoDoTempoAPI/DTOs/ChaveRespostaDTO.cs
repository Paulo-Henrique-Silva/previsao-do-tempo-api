namespace PrevisaoDoTempoAPI.DTOs
{
    public class ChaveRespostaDTO
    {
        public uint Id { get; set; }

        public string Usuario { get; set; }

        public string Texto { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataExpiracao { get; set; }

        public bool Valida => DataExpiracao >= DateTime.Now;

        public ChaveRespostaDTO(uint id, string usuario, string texto, DateTime dataCriacao, DateTime dataExpiracao)
        {
            Id = id;
            Usuario = usuario;
            Texto = texto;
            DataCriacao = dataCriacao;
            DataExpiracao = dataExpiracao;
        }
    }
}
