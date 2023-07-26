using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Interfaces
{
    public interface IViaCEPRepository
    {
        Task<Localizacao> ObterLocalizacaoPorCep(string cep);
    }
}
