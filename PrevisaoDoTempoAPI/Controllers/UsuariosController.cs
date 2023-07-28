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
        public IActionResult Cadastrar([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                Usuario usuario = usuarioService.Cadastrar(usuarioDTO);
                var resposta = new RespostaSucessoAPIDTO<Usuario>(201, $"Usuário de ID: {usuario.Id} criado com sucesso!", 
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
        public IActionResult CriarChave([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                //TODO: Criar DTOs de resposta ao Models.
                Chave chave = usuarioService.CriarChave(usuarioDTO);
                var resposta = new RespostaSucessoAPIDTO<Chave>(201, $"Chave de ID: {chave.Id} criado com sucesso!",
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
    }
}
