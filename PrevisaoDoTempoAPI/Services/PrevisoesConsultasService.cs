using PrevisaoDoTempoAPI.DTOs;
using PrevisaoDoTempoAPI.Interfaces;
using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Services
{
    public class PrevisoesConsultasService : IPrevisoesConsultasService
    {
        private readonly IViaCEPRepository viaCEPRepository;

        private readonly ICPTECRepository cptecRepository;

        private readonly IChaveRepository chaveRepository;

        private readonly IConsultaRepository consultaRepository;

        public PrevisoesConsultasService(IViaCEPRepository viaCEPRepository, ICPTECRepository cptecRepository, 
            IChaveRepository chaveRepository, IConsultaRepository consultaRepository)
        {
            this.viaCEPRepository = viaCEPRepository;
            this.cptecRepository = cptecRepository;
            this.chaveRepository = chaveRepository;
            this.consultaRepository = consultaRepository;
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
