using Microsoft.AspNetCore.Mvc;
using Moq;
using PrevisaoDoTempoAPI.Controllers;
using PrevisaoDoTempoAPI.DTOs;
using PrevisaoDoTempoAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevisaoDoTempoAPI.Tests.ControllerTests
{
    public class PrevisoesConsultasControllerTests
    {
        private readonly Mock<IPrevisoesConsultasService> mockPrevisoesConsultasService;

        public PrevisoesConsultasControllerTests()
        {
            mockPrevisoesConsultasService = new Mock<IPrevisoesConsultasService>();
        }

        [Fact]
        public void ObterConsultas_Deve_Retornar_Consultas_Corretamente()
        {
            var consultasRespostaDTO = new List<ConsultaRespostaDTO>()
            {
                new(1, "teste1", "1", DateTime.Now),
                new(2, "teste2", "2", DateTime.Now),
                new(3, "teste3", "3", DateTime.Now)
            };
            var respostaEsperada = new RespostaSucessoAPIDTO<List<ConsultaRespostaDTO>>(200, "", consultasRespostaDTO);

            mockPrevisoesConsultasService.Setup(m => m.ObterConsultas(null, null, null, null))
                .Returns(consultasRespostaDTO);
            var usuariosController = new PrevisoesConsultasController(mockPrevisoesConsultasService.Object);

            var resultadoObtido = usuariosController.ObterConsultas();

            Assert.NotNull(resultadoObtido);
            var resultadoCreated = Assert.IsType<OkObjectResult>(resultadoObtido);
            var respostaObtida = resultadoCreated.Value as RespostaSucessoAPIDTO<List<ConsultaRespostaDTO>>;

            Assert.NotNull(respostaObtida);
            Assert.Equal(respostaEsperada.Code, respostaObtida.Code);
            Assert.Equivalent(respostaEsperada.Data, respostaObtida.Data);
        }
    }
}
