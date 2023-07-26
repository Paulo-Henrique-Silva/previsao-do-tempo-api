using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Interfaces
{
    public interface ICPTECRepository
    {
        Task<CidadePrevisao?> ObterPrevisoesPorCodigoCidade(string codigoCidade);

        Task<uint> ObterCodigoCidadePorNomeEUF(string nome, string uf);
    }
}
