namespace PrevisaoDoTempoAPI.DTOs
{
    public class UsuarioDTO
    {
        public string Login { get; set; }

        public string Senha { get; set; }

        public UsuarioDTO(string login, string senha)
        {
            Login = login;
            Senha = senha;
        }
    }
}
