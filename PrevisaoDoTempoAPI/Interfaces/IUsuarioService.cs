using PrevisaoDoTempoAPI.DTOs;
using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioRespostaDTO Cadastrar(UsuarioLoginDTO usuario);

        ChaveRespostaDTO CriarChave(UsuarioLoginDTO usuario);

        List<ChaveRespostaDTO> ObterChavesDoUsuario(UsuarioLoginDTO usuario, bool somenteNaoExpiradas);
    }
}
