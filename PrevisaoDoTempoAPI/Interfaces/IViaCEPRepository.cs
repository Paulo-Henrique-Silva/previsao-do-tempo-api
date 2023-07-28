using PrevisaoDoTempoAPI.DTOs;

namespace PrevisaoDoTempoAPI.Interfaces
{
    public interface IViaCEPRepository
    {
        Task<LocalizacaoDTO?> ObterLocalizacaoPorCepAsync(string cep);
    }
}
