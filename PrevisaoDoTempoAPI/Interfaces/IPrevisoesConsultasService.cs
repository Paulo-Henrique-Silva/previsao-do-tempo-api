using PrevisaoDoTempoAPI.DTOs;
using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Interfaces
{
    public interface IPrevisoesConsultasService
    {
        PrevisaoTempoDTO ObterPrevisaoTempoPorCep(string cep, string chaveTexto);

        List<ConsultaRespostaDTO> ObterConsultas(string? usuario, string? cep, DateTime? dataMinima,
            DateTime? dataMaxima);
    }
}
