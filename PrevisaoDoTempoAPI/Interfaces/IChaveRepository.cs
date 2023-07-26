using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Interfaces
{
    public interface IChaveRepository
    {
        Task<List<Chave>> ObterTudo();

        Task<List<Chave>> ObterChavesPorUsuarioId(uint usuarioId);

        Task<Chave> Adicionar(Chave chave);
    }
}
