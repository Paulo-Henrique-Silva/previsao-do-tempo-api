using System.Xml.Serialization;

namespace PrevisaoDoTempoAPI.Models
{
    /// <summary>
    /// Classe usada para facilitar a leitura do arquivo XML da previsão da Cidade. Encapsula todos os dados da API CPTEC/INPE.
    /// </summary>
    [XmlRoot("cidade")]
    public class CidadePrevisao
    {
        [XmlElement("atualizacao")]
        public DateTime Atualizacao { get; set; }

        [XmlElement("previsao")]
        public List<PrevisaoDia>? PrevisoesDias { get; set; }

        public CidadePrevisao()
        {

        }
    }
}
