using Microsoft.AspNetCore.Mvc;
using PrevisaoDoTempoAPI.DTOs;
using PrevisaoDoTempoAPI.Exceptions;
using PrevisaoDoTempoAPI.Models;
using PrevisaoDoTempoAPI.Services;
using System.Net;

namespace PrevisaoDoTempoAPI.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService usuarioService;

        public UsuariosController(UsuarioService usuarioService)
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
    }
}
