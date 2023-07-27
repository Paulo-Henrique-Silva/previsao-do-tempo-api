using PrevisaoDoTempoAPI.DTOs;
using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Interfaces
{
    public interface IUsuarioService
    {
        Usuario ObterPorLogin(string login);

        bool ExistePorLogin(string login);

        bool SenhaCorretaPorLogin(string login, string senha);

        Usuario Cadastrar(UsuarioDTO usuario);

        Chave CriarChave(UsuarioDTO usuario);

        List<Chave> ObterChavesDoUsuario(UsuarioDTO usuario, bool somenteValidas);
    }
}
