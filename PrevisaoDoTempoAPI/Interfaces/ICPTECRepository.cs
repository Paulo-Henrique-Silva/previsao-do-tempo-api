using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Interfaces
{
    public interface ICPTECRepository
    {
        Task<Previsao> ObterPrevisaoPorCodigoCidade(string codigoCidade);

        Task<uint> ObterCidadeIdPorNomeEUF(string nome, string uf);
    }
}
