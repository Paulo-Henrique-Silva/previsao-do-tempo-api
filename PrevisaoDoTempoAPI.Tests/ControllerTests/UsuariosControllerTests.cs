using Microsoft.AspNetCore.Mvc;
using Moq;
using PrevisaoDoTempoAPI.Controllers;
using PrevisaoDoTempoAPI.DTOs;
using PrevisaoDoTempoAPI.Interfaces;
using PrevisaoDoTempoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevisaoDoTempoAPI.Tests.ControllerTests
{
    public class UsuariosControllerTests
    {
        private readonly Mock<IUsuarioService> mockUsuarioService;

        public UsuariosControllerTests()
        {
            mockUsuarioService = new Mock<IUsuarioService>();
        }

        [Fact]
        public void Cadastrar_Deve_Retornar_Usuario_Corretamente()
        {
            var usuarioRespostaDTO = new UsuarioRespostaDTO(1, "teste", DateTime.Now);
            var usuarioLoginDTO = new UsuarioLoginDTO("teste", "123");
            var respostaEsperada = new RespostaSucessoAPIDTO<UsuarioRespostaDTO>(201, $"Usuário de ID: 1 criado com sucesso!", usuarioRespostaDTO);

            mockUsuarioService.Setup(m => m.Cadastrar(usuarioLoginDTO))
                .Returns(usuarioRespostaDTO);
            var usuariosController = new UsuariosController(mockUsuarioService.Object);

            var resultadoObtido = usuariosController.Cadastrar(usuarioLoginDTO);

            Assert.NotNull(resultadoObtido);
            var resultadoCreated = Assert.IsType<CreatedResult>(resultadoObtido);
            var respostaObtida = resultadoCreated.Value as RespostaSucessoAPIDTO<UsuarioRespostaDTO>;

            Assert.NotNull(respostaObtida);
            Assert.Equal(respostaEsperada.Code, respostaObtida.Code);
            Assert.Equivalent(respostaEsperada.Data, respostaObtida.Data);
        }  
    }
}
