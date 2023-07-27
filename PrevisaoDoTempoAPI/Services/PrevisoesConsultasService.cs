using PrevisaoDoTempoAPI.DTOs;
using PrevisaoDoTempoAPI.Interfaces;
using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Services
{
    public class PrevisoesConsultasService : IPrevisoesConsultasService
    {
        public bool ChaveExpirada(string chaveTexto)
        {
            throw new NotImplementedException();
        }

        public bool ChaveValida(string chaveTexto)
        {
            throw new NotImplementedException();
        }

        public List<Consulta> ObterConsultas(string usuario, string cep, DateTime dataMinima, DateTime dataMaxima)
        {
            throw new NotImplementedException();
        }

        public PrevisaoTempoDTO ObterPrevisaoTempoPorCep(string cep, string chaveTexto)
        {
            throw new NotImplementedException();
        }
    }
}
