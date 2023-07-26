﻿using System.Xml.Serialization;

namespace PrevisaoDoTempoAPI.Models
{
    /// <summary>
    /// Classe usada para facilitar a leitura do arquivo XML. Encapsula todos os dados da API CPTEC/INPE.
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

    /// <summary>
    /// Encapsula os dados relativos à previsão do tempo da API CPTEC/INPE.
    /// </summary>
    public class PrevisaoDia
    {
        [XmlElement("dia")]
        public DateTime Dia { get; set; }

        [XmlElement("tempo")]
        public string? Tempo { get; set; }

        [XmlElement("maxima")]
        public string? Maxima { get; set; }

        [XmlElement("minima")]
        public string? Minima { get; set; }

        [XmlElement("iuv")]
        public string? Iuv { get; set; }

        public PrevisaoDia()
        {
        }

        public PrevisaoDia(DateTime dia, string tempo, string maxima, string minima, string iuv)
        {
            Dia = dia;
            Tempo = tempo;
            Maxima = maxima;
            Minima = minima;
            Iuv = iuv;
        }
    }
}
