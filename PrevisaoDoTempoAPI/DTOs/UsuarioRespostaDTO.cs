namespace PrevisaoDoTempoAPI.DTOs
{
    public class UsuarioRespostaDTO
    {
        public uint Id { get; set; }

        public string Login { get; set; }

        public DateTime DataCadastro { get; set; }

        public UsuarioRespostaDTO(uint id, string login, DateTime dataCadastro)
        {
            Id = id;
            Login = login;
            DataCadastro = dataCadastro;
        }
    }
}
