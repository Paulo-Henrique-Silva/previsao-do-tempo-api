using PrevisaoDoTempoAPI.DTOs;
using PrevisaoDoTempoAPI.Exceptions;
using PrevisaoDoTempoAPI.Interfaces;
using PrevisaoDoTempoAPI.Models;
using System.Text;
using System.Text.RegularExpressions;

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

        private bool ChaveExpiradaPorTexto(string chaveTexto)
        {
            Chave? chave = chaveRepository.ObterPorTextoAsync(chaveTexto).Result;

            return chave == null ? throw new ConteudoInvalidoException("Não existe uma chave com este texto.") : !chave.ChaveNaoExpirada;
        }

        private bool ChaveValidaPorTexto(string chaveTexto)
        {
            return chaveRepository.ExistePorTextoAsync(chaveTexto).Result;
        }

        public List<ConsultaRespostaDTO> ObterConsultas(string? usuario, string? cep, DateTime? dataMinima, DateTime? dataMaxima)
        {
            List<Consulta> consultas = consultaRepository.ObterTudoComUsuariosAsync().Result;

            if (usuario != null)
            {
                consultas = consultas.Where(c => c.Usuario != null && c.Usuario.Login.Equals(usuario)).ToList();
            }

            if (cep != null)
            {
                consultas = consultas.Where(c => c.Cep != null && c.Cep.Equals(cep)).ToList();
            }

            if (dataMinima != null)
            {
                consultas = consultas.Where(c => c.DataConsulta >= dataMinima).ToList();
            }

            if (dataMaxima != null)
            {
                consultas = consultas.Where(c => c.DataConsulta <= dataMaxima).ToList();
            }

            return consultas.Select(c => 
            {
                return c.Usuario != null ? new ConsultaRespostaDTO(c.Id, c.Usuario.Login, c.Cep, c.DataConsulta) : 
                    new ConsultaRespostaDTO(c.Id, string.Empty, c.Cep, c.DataConsulta);
            }).ToList();
        }

        public PrevisaoTempoDTO ObterPrevisaoTempoPorCep(string cep, string chaveTexto)
        {
            //verifica chave.
            if (!ChaveValidaPorTexto(chaveTexto))
            {
                throw new ChaveInvalidaException($"A chave {chaveTexto} não existe.");
            }

            if (ChaveExpiradaPorTexto(chaveTexto))
            {
                throw new ChaveInvalidaException($"A chave {chaveTexto} está expirada.");
            }

            //busca localização.
            LocalizacaoDTO? localizacaoDTO = viaCEPRepository.ObterLocalizacaoPorCepAsync(cep).Result;

            if (localizacaoDTO == null || localizacaoDTO.Localidade == null || localizacaoDTO.Uf == null)
            {
                throw new ParametroInvalidoException($"O cep {cep} é inválido.");
            }

            //busca previsão do tempo.

            //remove os acentos - A API do CPTEC exige que o nome não tenha acentos.
            string localidadeSemAcentos = Regex.Replace(localizacaoDTO.Localidade.Normalize(NormalizationForm.FormD), @"[^a-zA-Z0-9\s]", "");

            uint codigoCidade = cptecRepository.ObterCodigoCidadePorNomeEUFAsync(localidadeSemAcentos,
                localizacaoDTO.Uf).Result;

            if (codigoCidade == 0)
            {
                throw new ServicoIndisponivelException("Não foi possível localizar o código da cidade.");
            }

            CidadePrevisaoDTO? cidadePrevisaoDTO = cptecRepository.ObterPrevisoesPorCodigoCidadeAsync(codigoCidade).Result;

            if (cidadePrevisaoDTO == null || cidadePrevisaoDTO.PrevisoesDias == null)
            {
                throw new ServicoIndisponivelException("Não foi possível obter a previsão de tempo da cidade.");
            }

            //adiciona consulta.
            var chave = chaveRepository.ObterPorTextoAsync(chaveTexto).Result
                ?? throw new Exception($"Não foi possível localizar a chave pertencente ao texto {chaveTexto}");

            uint usuarioId = chave.UsuarioId;
            consultaRepository.AdicionarAsync(new Consulta(usuarioId, cep, DateTime.Now));

            //crie e retorna dados das buscas.
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
