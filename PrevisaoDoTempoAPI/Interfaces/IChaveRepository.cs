using Microsoft.AspNetCore.Components.Web;
using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Interfaces
{
    public interface IChaveRepository
    {
        Task<List<Chave>> ObterTudoAsync();

        Task<Chave?> ObterPorTextoAsync(string chaveTexto);

        Task<List<Chave>> ObterChavesPorUsuarioIdAsync(uint usuarioId);

        Task<Chave> AdicionarAsync(Chave chave);

        Task<bool> ExistePorTextoAsync(string chaveTexto);
    }
}
