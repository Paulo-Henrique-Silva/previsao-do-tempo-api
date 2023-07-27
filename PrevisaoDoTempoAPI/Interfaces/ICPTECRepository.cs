using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Interfaces
{
    public interface ICPTECRepository
    {
        Task<CidadePrevisao?> ObterPrevisoesPorCodigoCidade(uint codigoCidade);

        Task<uint> ObterCodigoCidadePorNomeEUF(string nome, string uf);
    }
}
