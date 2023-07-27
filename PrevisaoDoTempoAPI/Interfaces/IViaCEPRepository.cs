using PrevisaoDoTempoAPI.DTOs;

namespace PrevisaoDoTempoAPI.Interfaces
{
    public interface IViaCEPRepository
    {
        Task<LocalizacaoDTO?> ObterLocalizacaoPorCep(string cep);
    }
}
