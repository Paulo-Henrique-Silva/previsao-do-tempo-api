using PrevisaoDoTempoAPI.Interfaces;
using PrevisaoDoTempoAPI.Models;
using System.Xml;
using System.Xml.Serialization;

namespace PrevisaoDoTempoAPI.Repositories
{
    public class CPTECRepository : ICPTECRepository
    {
        /// <summary>
        /// Obtém o código da cidade da API CPTEC por meio do nome e sigla da UF.
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="uf"></param>
        /// <returns>Retorna um valor inteiro positivo diferente de zero que representa o código da cidade caso consiga encontrar, senão retorna 0.</returns>
        public async Task<uint> ObterCodigoCidadePorNomeEUF(string nome, string uf)
        {
            //TODO: Na classe de serviço, garantir que o nome da cidade não tenha acentos.
            string rota = IConstantes.URL_CPTEC_API + "listaCidades?city=" + nome;
            using var httpClient = new HttpClient();

            HttpResponseMessage httpResponse = await httpClient.GetAsync(rota);

            string xml = await httpResponse.Content.ReadAsStringAsync();

            var xmlSerializer = new XmlSerializer(typeof(GrupoCidades));
            using var textReader = new StringReader(xml);
            GrupoCidades? grupoCidades = xmlSerializer.Deserialize(textReader) as GrupoCidades;

            if (grupoCidades != null && grupoCidades.Cidades != null 
                && grupoCidades.Cidades.Count != 0)
            {
                var cidades = grupoCidades.Cidades
                    .Where(c => !string.IsNullOrEmpty(c.Uf) && c.Uf.Equals(uf))
                    .ToList();

                return cidades.Count != 1 ? 0 : cidades.First().Codigo;
            }

            return 0;
        }

        /// <summary>
        /// Obtém as informações de previsão da cidade para os próximos 4 dias.
        /// </summary>
        /// <param name="codigoCidade"></param>
        /// <returns>Retorna um de CidadePrevisao contendo a lista de previsões.</returns>
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

        #region Classes auxiliares

        /// <summary>
        /// Classe usada, somente, para ler possíveis cidades na busca pelo código.
        /// </summary>
        [XmlRoot("cidades")]
        public class GrupoCidades
        {
            [XmlElement("cidade")]
            public List<Cidade>? Cidades { get; set; }
        }

        /// <summary>
        /// Encapsula dados das cidades da API CPTEC.
        /// </summary>
        public class Cidade
        {
            [XmlElement("id")]
            public uint Codigo { get; set; }

            [XmlElement("uf")]
            public string? Uf { get; set; }
        }

        #endregion
    }
}
