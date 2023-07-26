using PrevisaoDoTempoAPI.Interfaces;
using PrevisaoDoTempoAPI.Models;
using System.Net.Http;
using System.Xml.Serialization;

namespace PrevisaoDoTempoAPI.Repositories
{
    public class ViaCEPRepository : IViaCEPRepository
    {
        public async Task<Localizacao?> ObterLocalizacaoPorCep(string cep)
        {
            string rota = IConstantes.URL_VIA_CEP_API + cep + "/xml";
            using var httpClient = new HttpClient();

            HttpResponseMessage httpResponse = await httpClient.GetAsync(rota);

            if (httpResponse.IsSuccessStatusCode)
            {
                string xml = await httpResponse.Content.ReadAsStringAsync();

                var xmlSerializer = new XmlSerializer(typeof(Localizacao));
                using var textReader = new StringReader(xml);
                var localizacao = xmlSerializer.Deserialize(textReader) as Localizacao;

                return localizacao;
            }

            return null;
        }
    }
}
