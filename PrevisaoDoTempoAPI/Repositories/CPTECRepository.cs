using PrevisaoDoTempoAPI.Interfaces;
using PrevisaoDoTempoAPI.Models;
using System.Xml.Serialization;

namespace PrevisaoDoTempoAPI.Repositories
{
    public class CPTECRepository : ICPTECRepository
    {
        public Task<uint> ObterCidadeIdPorNomeEUF(string nome, string uf)
        {
            throw new NotImplementedException();
        }

        public async Task<CidadePrevisao?> ObterPrevisoesPorCodigoCidade(string codigoCidade)
        {
            string rota = IConstantes.URL_CPTEC_API + "cidade/" + codigoCidade + "/previsao.xml";
            using var httpClient = new HttpClient();

            HttpResponseMessage httpResponse = await httpClient.GetAsync(rota);

            string xml = await httpResponse.Content.ReadAsStringAsync();

            //Como a API da CPTEC não retorna status 404 ou 400 para códigos inválidos e sim um XML com valores nulos nos elementos,
            //um try é usado para obter exceções relativas a erros de leitura do arquivo
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(CidadePrevisao));
                using var textReader = new StringReader(xml);
                var cidadePrevisao = xmlSerializer.Deserialize(textReader) as CidadePrevisao;

                return cidadePrevisao;
            }
            catch { }

            return null;
        }
    }
}
