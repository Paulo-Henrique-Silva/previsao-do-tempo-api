using PrevisaoDoTempoAPI.DTOs;
using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Interfaces
{
    public interface IUsuarioService
    {
        bool ExistePorLogin(string login);

        Usuario Cadastrar(UsuarioDTO usuario);

        Chave CriarChave(UsuarioDTO usuario);

        List<Chave> ObterChavesDoUsuario(UsuarioDTO usuario, bool somenteValidas);
    }
}
