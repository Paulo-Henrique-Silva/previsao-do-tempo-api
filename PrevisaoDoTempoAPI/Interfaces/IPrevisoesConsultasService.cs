using PrevisaoDoTempoAPI.DTOs;
using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Interfaces
{
    public interface IPrevisoesConsultasService
    {
        bool ChaveExpiradaPorTexto(string chaveTexto);

        bool ChaveValidaPorTexto(string chaveTexto);

        PrevisaoTempoDTO ObterPrevisaoTempoPorCep(string cep, string chaveTexto);

        List<Consulta> ObterConsultas(string? usuario, string? cep, DateTime dataMinima,
            DateTime dataMaxima);
    }
}
