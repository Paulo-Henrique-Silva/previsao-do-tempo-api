using Microsoft.AspNetCore.Mvc;
using PrevisaoDoTempoAPI.DTOs;
using PrevisaoDoTempoAPI.Exceptions;
using PrevisaoDoTempoAPI.Interfaces;
using PrevisaoDoTempoAPI.Models;
using PrevisaoDoTempoAPI.Services;
using System.Net;

namespace PrevisaoDoTempoAPI.Controllers
{
    [Controller]
    [Route("/api")]
    public class PrevisoesConsultasController : ControllerBase
    {
        private readonly IPrevisoesConsultasService previsoesConsultasService;

        public PrevisoesConsultasController(IPrevisoesConsultasService previsoesConsultasService)
        {
            this.previsoesConsultasService = previsoesConsultasService;
        }

        [HttpGet("previsoes/{chaveApi}/{cep}")]
        public IActionResult ObterPrevisao([FromRoute] string chaveApi, [FromRoute] string cep)
        {
            try
            {
                PrevisaoTempoDTO previsao = previsoesConsultasService.ObterPrevisaoTempoPorCep(cep, chaveApi);
                var resposta = new RespostaSucessoAPIDTO<PrevisaoTempoDTO>(200, $"Previsão para os próximos 4 dias obtida com sucesso!",
                    previsao);

                return Ok(resposta);
            }
            catch (ChaveInvalidaException ex)
            {
                return Unauthorized(new RespostaErroAPIDTO(401, ex.Message));
            }
            catch (ParametroInvalidoException ex)
            {
                return BadRequest(new RespostaErroAPIDTO(400, ex.Message));
            }
            catch (ServicoIndisponivelException)
            {
                return StatusCode(503, new RespostaErroAPIDTO(503, "Serviço indisponível no momento para este CEP."));
            }
            catch (Exception)
            {
                return StatusCode(500, RespostaErroAPIDTO.RespostaErro500);
            }
        }

        [HttpGet("consultas")]
        public IActionResult ObterConsultas
        (
            [FromQuery] string? usuario = null, [FromQuery] string? cep = null, 
            [FromQuery] DateTime? dataMinima = null, [FromQuery] DateTime? dataMaxima = null
        )
        {
            try
            {
                List<ConsultaRespostaDTO> consultas = previsoesConsultasService.ObterConsultas(usuario, cep, dataMinima, dataMaxima);
                var resposta = new RespostaSucessoAPIDTO<List<ConsultaRespostaDTO>>(200, $"Consultas obtidas com sucesso!",
                    consultas);

                return Ok(resposta);
            }
            catch (ParametroInvalidoException ex)
            {
                return BadRequest(new RespostaErroAPIDTO(400, ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, RespostaErroAPIDTO.RespostaErro500);
            }
        }
    }
}
