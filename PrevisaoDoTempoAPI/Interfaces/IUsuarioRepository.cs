using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<bool> ExistePorLogin(string login);

        Task<bool> SenhaCorretaPorLogin(string login, string senha);

        Task<Usuario> Adicionar(Usuario usuario);

        Task<Usuario?> ObterPorLogin(string login);
    }
}
