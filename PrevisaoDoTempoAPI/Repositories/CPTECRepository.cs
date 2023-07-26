using PrevisaoDoTempoAPI.Interfaces;
using PrevisaoDoTempoAPI.Models;
using System.Xml;
using System.Xml.Serialization;

namespace PrevisaoDoTempoAPI.Repositories
{
    public class CPTECRepository : ICPTECRepository
    {
        public async Task<uint> ObterCodigoCidadePorNomeEUF(string nome, string uf)
        {
            //TODO: Na classe de serviço, garantir que o nome da cidade não tenha acentos.
            //TODO: Terminar implementação do método e corrigir erro de leitura.
            string rota = IConstantes.URL_CPTEC_API + "listaCidades?city=" + nome;
            using var httpClient = new HttpClient();

            HttpResponseMessage httpResponse = await httpClient.GetAsync(rota);

            string xml = await httpResponse.Content.ReadAsStringAsync();

            var xmlSerializer = new XmlSerializer(typeof(GrupoCidades));
            using var textReader = new StringReader(xml);
            var grupoCidades = xmlSerializer.Deserialize(textReader) as GrupoCidades;

            if (grupoCidades != null)
            {

            }

            return 0;
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

        [XmlRoot("cidades")]
        private class GrupoCidades
        {
            [XmlElement("cidade")]
            public List<Cidade>? Cidades { get; set; }
        }

        private class Cidade
        {
            [XmlElement("id")]
            public uint Id { get; set; }
        }
    }
}
