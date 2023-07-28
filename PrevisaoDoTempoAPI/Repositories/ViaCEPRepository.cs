using PrevisaoDoTempoAPI.DTOs;
using PrevisaoDoTempoAPI.Interfaces;
using System.Net.Http;
using System.Xml.Serialization;

namespace PrevisaoDoTempoAPI.Repositories
{
    public class ViaCEPRepository : IViaCEPRepository
    {
        /// <summary>
        /// Obtém os dados disponíveis na API VIACEP para o cep passado no parâmetro.
        /// </summary>
        /// <param name="cep"></param>
        /// <returns>Retorna o objeto de localização contendo os dados, caso o CEP seja válido. Senão retorna null.</returns>
        public async Task<LocalizacaoDTO?> ObterLocalizacaoPorCepAsync(string cep)
        {
            string rota = IConstantes.URL_VIA_CEP_API + cep + "/xml";
            using var httpClient = new HttpClient();

            HttpResponseMessage httpResponse = await httpClient.GetAsync(rota);

            if (httpResponse.IsSuccessStatusCode)
            {
                string xml = await httpResponse.Content.ReadAsStringAsync();

                var xmlSerializer = new XmlSerializer(typeof(LocalizacaoDTO));
                using var textReader = new StringReader(xml);
                var localizacao = xmlSerializer.Deserialize(textReader) as LocalizacaoDTO;

                return localizacao;
            }

            return null;
        }
    }
}
