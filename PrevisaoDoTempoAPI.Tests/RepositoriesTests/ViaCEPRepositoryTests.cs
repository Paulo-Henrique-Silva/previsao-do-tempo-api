using PrevisaoDoTempoAPI.Models;
using PrevisaoDoTempoAPI.Repositories;

namespace PrevisaoDoTempoAPI.Tests.RepositoriesTests
{
    public class ViaCEPRepositoryTests
    {
        [Fact]
        public void ObterLocalizacaoPorCep_Deve_Retornar_Dados_Corretos()
        {
            string cep = "01101-000"; //CEP da esta��o da Luz, em S�o Paulo.
            ViaCEPRepository repository = new ViaCEPRepository();
            Localizacao localizacao = new Localizacao()
            {
                Cep = cep,
                Localidade = "S�o Paulo",
                Uf = "SP"
            };

            var localizacaoResposta = repository.ObterLocalizacaoPorCep(cep).Result;

            Assert.NotNull(localizacaoResposta);
            Assert.Equal(localizacao.Cep, localizacaoResposta.Cep);
            Assert.Equal(localizacao.Localidade, localizacaoResposta.Localidade);
            Assert.Equal(localizacao.Uf, localizacaoResposta.Uf);
        }

        [Fact]
        public void ObterLocalizacaoPorCep_Deve_Retornar_Nulo()
        {
            string cep = "01101-1345"; //CEP inv�lido.
            ViaCEPRepository repository = new ViaCEPRepository();

            var localizacaoResposta = repository.ObterLocalizacaoPorCep(cep).Result;

            Assert.Null(localizacaoResposta);
        }
    }
}