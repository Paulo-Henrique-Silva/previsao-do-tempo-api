using Microsoft.AspNetCore.Components.Web;
using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Interfaces
{
    public interface IChaveRepository
    {
        Task<List<Chave>> ObterTudo();

        Task<List<Chave>> ObterChavesPorUsuarioId(uint usuarioId);

        Task<Chave> Adicionar(Chave chave);

        Task<bool> ExistePorTexto(string chaveTexto);
    }
}
