using PrevisaoDoTempoAPI.DTOs;
using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Interfaces
{
    public interface IUsuarioService
    {
        Usuario Cadastrar(UsuarioDTO usuario);

        Chave CriarChave(UsuarioDTO usuario);

        List<Chave> ObterChavesDoUsuario(UsuarioDTO usuario, bool somenteValidas);
    }
}
