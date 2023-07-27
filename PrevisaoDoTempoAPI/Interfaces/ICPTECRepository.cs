using PrevisaoDoTempoAPI.DTOs;

namespace PrevisaoDoTempoAPI.Interfaces
{
    public interface ICPTECRepository
    {
        Task<CidadePrevisaoDTO?> ObterPrevisoesPorCodigoCidade(uint codigoCidade);

        Task<uint> ObterCodigoCidadePorNomeEUF(string nome, string uf);
    }
}
