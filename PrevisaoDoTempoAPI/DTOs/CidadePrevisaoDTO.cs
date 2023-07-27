using System.Xml.Serialization;

namespace PrevisaoDoTempoAPI.DTOs
{
    /// <summary>
    /// Classe usada para facilitar a leitura do arquivo XML da previsão da Cidade. Encapsula todos os dados da API CPTEC/INPE.
    /// </summary>
    [XmlRoot("cidade")]
    public class CidadePrevisaoDTO
    {
        [XmlElement("atualizacao")]
        public DateTime Atualizacao { get; set; }

        [XmlElement("previsao")]
        public List<PrevisaoDiaDTO>? PrevisoesDias { get; set; }

        public CidadePrevisaoDTO()
        {

        }
    }
}
