using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Interfaces
{
    public interface ICPTECRepository
    {
        Task<CidadePrevisao?> ObterPrevisoesPorCodigoCidade(string codigoCidade);

        Task<uint> ObterCidadeIdPorNomeEUF(string nome, string uf);
    }
}
