using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<bool> ExistePorLoginAsync(string login);

        Task<bool> SenhaCorretaPorLoginAsync(string login, string senha);

        Task<Usuario> AdicionarAsync(Usuario usuario);

        Task<Usuario?> ObterPorLoginAsync(string login);
    }
}
