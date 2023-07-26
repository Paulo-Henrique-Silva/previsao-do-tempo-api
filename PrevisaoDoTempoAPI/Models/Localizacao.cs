using System.Xml.Serialization;

namespace PrevisaoDoTempoAPI.Models
{
    /// <summary>
    /// Encapsula os dados da API ViaCEP.
    /// </summary>
    [XmlRoot("xmlcep")]
    public class Localizacao
    {
        [XmlElement("cep")]
        public string? Cep { get; set; }

        [XmlElement("logradouro")]
        public string? Logradouro { get; set; }

        [XmlElement("complemento")]
        public string? Complemento { get; set; }

        [XmlElement("bairro")]
        public string? Bairro { get; set; }

        [XmlElement("localidade")]
        public string? Localidade { get; set; }

        [XmlElement("uf")]
        public string? Uf { get; set; }

        [XmlElement("ibge")]
        public string? Ibge { get; set; }

        [XmlElement("gia")]
        public string? Gia { get; set; }

        [XmlElement("ddd")]
        public string? Ddd { get; set; }

        [XmlElement("siafi")]
        public string? Siafi { get; set; }

        public Localizacao()
        {
        }

        public Localizacao(string cep, string logradouro, string complemento, string bairro, 
            string localidade, string uf, string ibge, string gia, string ddd, string siafi)
        {
            Cep = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            Bairro = bairro;
            Localidade = localidade;
            Uf = uf;
            Ibge = ibge;
            Gia = gia;
            Ddd = ddd;
            Siafi = siafi;
        }
    }
}
