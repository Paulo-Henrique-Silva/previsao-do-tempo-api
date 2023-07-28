using PrevisaoDoTempoAPI.DTOs;

namespace PrevisaoDoTempoAPI.Interfaces
{
    public interface ICPTECRepository
    {
        Task<CidadePrevisaoDTO?> ObterPrevisoesPorCodigoCidadeAsync(uint codigoCidade);

        Task<uint> ObterCodigoCidadePorNomeEUFAsync(string nome, string uf);
    }
}
