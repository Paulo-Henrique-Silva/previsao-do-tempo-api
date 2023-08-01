using Microsoft.AspNetCore.Mvc;
using PrevisaoDoTempoAPI.DTOs;
using PrevisaoDoTempoAPI.Exceptions;
using PrevisaoDoTempoAPI.Interfaces;
using PrevisaoDoTempoAPI.Models;
using System.Net;

namespace PrevisaoDoTempoAPI.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpPost]
        public ActionResult Cadastrar([FromBody] UsuarioLoginDTO usuarioDTO)
        {
            try
            {
                UsuarioRespostaDTO usuario = usuarioService.Cadastrar(usuarioDTO);
                var resposta = new RespostaSucessoAPIDTO<UsuarioRespostaDTO>(201, $"Usuário de ID: {usuario.Id} criado com sucesso!", 
                    usuario);

                return Created("", resposta);
            }
            catch (ConteudoInvalidoException ex)
            {
                return BadRequest(new RespostaErroAPIDTO(400, ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, RespostaErroAPIDTO.RespostaErro500);
            }
        }

        [HttpPost("criarchave")]
        public ActionResult CriarChave([FromBody] UsuarioLoginDTO usuarioDTO)
        {
            try
            {
                ChaveRespostaDTO chave = usuarioService.CriarChave(usuarioDTO);
                var resposta = new RespostaSucessoAPIDTO<ChaveRespostaDTO>(201, $"Chave de ID: {chave.Id} criada com sucesso!",
                    chave);

                return Created("", resposta);
            }
            catch (LoginInvalidoException ex)
            {
                return Unauthorized(new RespostaErroAPIDTO(401, ex.Message));
            }
            catch (ConteudoInvalidoException ex)
            {
                return BadRequest(new RespostaErroAPIDTO(400, ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, RespostaErroAPIDTO.RespostaErro500);
            }
        }

        [HttpPost("chaves")]
        public ActionResult ObterChaves([FromBody] UsuarioLoginDTO usuarioDTO, 
            [FromQuery] bool somenteNaoExpiradas = false)
        {
            try
            {
                List<ChaveRespostaDTO> chaves = usuarioService.ObterChavesDoUsuario(usuarioDTO, somenteNaoExpiradas);
                var resposta = new RespostaSucessoAPIDTO<List<ChaveRespostaDTO>>(200, $"Chaves obtidas com sucesso!",
                    chaves);

                return Ok(resposta);
            }
            catch (LoginInvalidoException ex)
            {
                return Unauthorized(new RespostaErroAPIDTO(401, ex.Message));
            }
            catch (ConteudoInvalidoException ex)
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
