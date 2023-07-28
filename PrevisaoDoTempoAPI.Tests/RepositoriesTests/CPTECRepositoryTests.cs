using PrevisaoDoTempoAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace PrevisaoDoTempoAPI.Tests.RepositoriesTests
{
    public class CPTECRepositoryTests
    {
        [Fact]
        public void ObterCodigoCidadePorNomeEUF_Deve_Retornar_Codigo_Correto()
        {
            string nome = "sao paulo";
            string uf = "SP";
            uint codigoEsperado = 244;
            CPTECRepository repository = new CPTECRepository();

            var codigoObtido = repository.ObterCodigoCidadePorNomeEUFAsync(nome, uf).Result;

            Assert.Equal(codigoEsperado, codigoObtido);
        }

        [Fact]
        public void ObterCodigoCidadePorNomeEUF_Deve_Retornar_0()
        {
            string nome = "São Paulo"; //query inválida por conter assentos no nome.
            string uf = "SP";
            uint codigoEsperado = 244;
            CPTECRepository repository = new CPTECRepository();

            var codigoObtido = repository.ObterCodigoCidadePorNomeEUFAsync(nome, uf).Result;

            Assert.NotEqual(codigoEsperado, codigoObtido);
            Assert.Equal(0u, codigoObtido);
        }
    }
}
