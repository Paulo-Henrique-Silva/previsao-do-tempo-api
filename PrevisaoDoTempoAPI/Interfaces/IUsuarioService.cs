using PrevisaoDoTempoAPI.DTOs;
using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Interfaces
{
    public interface IUsuarioService
    {
        Usuario ObterPorLogin(string login);

        bool ExistePorLogin(string login);

        bool SenhaCorretaPorLogin(string login, string senha);

        Usuario Cadastrar(UsuarioLoginDTO usuario);

        Chave CriarChave(UsuarioLoginDTO usuario);

        List<Chave> ObterChavesDoUsuario(UsuarioLoginDTO usuario, bool somenteNaoExpiradas);
    }
}
