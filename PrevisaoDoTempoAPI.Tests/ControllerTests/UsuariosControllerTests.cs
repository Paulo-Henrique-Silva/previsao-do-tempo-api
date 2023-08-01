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

        [Fact]
        public void CriarChave_Deve_Retornar_Chave_Corretamente()
        {
            var chaveRespostaDTO = new ChaveRespostaDTO(1, "teste", "ABC123", DateTime.Now, DateTime.Now.AddDays(3));
            var usuarioLoginDTO = new UsuarioLoginDTO("teste", "123");
            var respostaEsperada = new RespostaSucessoAPIDTO<ChaveRespostaDTO>(201, $"Chave de ID: 1 criada com sucesso!", chaveRespostaDTO);

            mockUsuarioService.Setup(m => m.CriarChave(usuarioLoginDTO))
                .Returns(chaveRespostaDTO);
            var usuariosController = new UsuariosController(mockUsuarioService.Object);

            var resultadoObtido = usuariosController.CriarChave(usuarioLoginDTO);

            Assert.NotNull(resultadoObtido);
            var resultadoCreated = Assert.IsType<CreatedResult>(resultadoObtido);
            var respostaObtida = resultadoCreated.Value as RespostaSucessoAPIDTO<ChaveRespostaDTO>;

            Assert.NotNull(respostaObtida);
            Assert.Equal(respostaEsperada.Code, respostaObtida.Code);
            Assert.Equivalent(respostaEsperada.Data, respostaObtida.Data);
        }

        [Fact]
        public void ObterChaves_Deve_Retornar_Chaves_Corretamente()
        {
            var chavesRespostaDTO = new List<ChaveRespostaDTO>() 
            {
                new(1, "teste1", "ABC123", DateTime.Now, DateTime.Now.AddDays(3)),
                new(2, "teste2", "ABC123", DateTime.Now, DateTime.Now.AddDays(3)),
                new(3, "teste3", "ABC123", DateTime.Now, DateTime.Now.AddDays(3))
            };

            var usuarioLoginDTO = new UsuarioLoginDTO("teste", "123");
            var respostaEsperada = new RespostaSucessoAPIDTO<List<ChaveRespostaDTO>>(200, "", chavesRespostaDTO);

            mockUsuarioService.Setup(m => m.ObterChavesDoUsuario(usuarioLoginDTO, false))
                .Returns(chavesRespostaDTO);
            var usuariosController = new UsuariosController(mockUsuarioService.Object);

            var resultadoObtido = usuariosController.ObterChaves(usuarioLoginDTO);

            Assert.NotNull(resultadoObtido);
            var resultadoCreated = Assert.IsType<OkObjectResult>(resultadoObtido);
            var respostaObtida = resultadoCreated.Value as RespostaSucessoAPIDTO<List<ChaveRespostaDTO>>;

            Assert.NotNull(respostaObtida);
            Assert.Equal(respostaEsperada.Code, respostaObtida.Code);
            Assert.Equivalent(respostaEsperada.Data.ElementAt(0), respostaObtida.Data.ElementAt(0));
            Assert.Equal(respostaEsperada.Data.ElementAt(1), respostaObtida.Data.ElementAt(1));
            Assert.Equal(respostaEsperada.Data.ElementAt(2), respostaObtida.Data.ElementAt(2));
        }
    }
}
