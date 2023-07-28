namespace PrevisaoDoTempoAPI.DTOs
{
    public class ConsultaRespostaDTO
    {
        public uint Id { get; set; }

        public string Usuario { get; set; }

        public string Cep { get; set; }

        public DateTime DataConsulta { get; set; }

        public ConsultaRespostaDTO(uint id, string usuario, string cep, DateTime dataConsulta)
        {
            Id = id;
            Usuario = usuario;
            Cep = cep;
            DataConsulta = dataConsulta;
        }
    }
}
