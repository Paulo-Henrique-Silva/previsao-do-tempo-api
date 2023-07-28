namespace PrevisaoDoTempoAPI.DTOs
{
    public class UsuarioLoginDTO
    {
        public string Login { get; set; }

        public string Senha { get; set; }

        public UsuarioLoginDTO(string login, string senha)
        {
            Login = login;
            Senha = senha;
        }
    }
}
