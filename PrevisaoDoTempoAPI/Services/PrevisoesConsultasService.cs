using PrevisaoDoTempoAPI.DTOs;
using PrevisaoDoTempoAPI.Exceptions;
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

        public bool ChaveExpiradaPorTexto(string chaveTexto)
        {
            Chave? chave = chaveRepository.ObterPorTexto(chaveTexto).Result;

            return chave == null ? throw new ConteudoInvalidoException("Não existe uma chave com este texto.") : !chave.ChaveNaoExpirada;
        }

        public bool ChaveValidaPorTexto(string chaveTexto)
        {
            return chaveRepository.ExistePorTexto(chaveTexto).Result;
        }

        public List<Consulta> ObterConsultas(string? usuario, string? cep, DateTime dataMinima, DateTime dataMaxima)
        {
            List<Consulta> consultas = consultaRepository.ObterTudo().Result;

            if (usuario != null)
            {
                consultas = consultas.Where(c => c.Usuario != null && c.Usuario.Equals(usuario)).ToList();
            }

            if (cep != null)
            {
                consultas = consultas.Where(c => c.Cep != null && c.Cep.Equals(cep)).ToList();
            }

            consultas = consultas.Where(c => c.DataConsulta >= dataMinima && c.DataConsulta <= dataMaxima).ToList();

            return consultas;
        }

        public PrevisaoTempoDTO ObterPrevisaoTempoPorCep(string cep, string chaveTexto)
        {
            if (ChaveValidaPorTexto(chaveTexto))
            {
                throw new ChaveInvalidaException($"A chave {chaveTexto} não existe.");
            }

            if (ChaveExpiradaPorTexto(chaveTexto))
            {
                throw new ChaveInvalidaException($"A chave {chaveTexto} não existe.");
            }

            LocalizacaoDTO? localizacaoDTO = viaCEPRepository.ObterLocalizacaoPorCep(cep).Result;

            if (localizacaoDTO == null || localizacaoDTO.Localidade == null || localizacaoDTO.Uf == null)
            {
                throw new ParametroInvalidoException($"O cep {cep} é inválido.");
            }

            uint codigoCidade = cptecRepository.ObterCodigoCidadePorNomeEUF(localizacaoDTO.Localidade,
                localizacaoDTO.Uf).Result;

            if (codigoCidade == 0)
            {
                throw new ServicoIndisponivelException("Não foi possível localizar o código da cidade.");
            }

            CidadePrevisaoDTO? cidadePrevisaoDTO = cptecRepository.ObterPrevisoesPorCodigoCidade(codigoCidade).Result;

            if (cidadePrevisaoDTO == null || cidadePrevisaoDTO.PrevisoesDias == null)
            {
                throw new ServicoIndisponivelException("Não foi possível obter a previsão de tempo da cidade.");
            }

            var atualizacaoApenasDia = new DateOnly(cidadePrevisaoDTO.Atualizacao.Year,
                cidadePrevisaoDTO.Atualizacao.Month, cidadePrevisaoDTO.Atualizacao.Day);

            var previsaoTempoDTO = new PrevisaoTempoDTO
            (
                atualizacaoApenasDia,
                localizacaoDTO,
                cidadePrevisaoDTO.PrevisoesDias
            );

            return previsaoTempoDTO;
        }
    }
}
