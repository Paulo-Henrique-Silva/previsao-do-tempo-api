namespace PrevisaoDoTempoAPI.Models
{
    /// <summary>
    /// Encapsula os dados da API CPTEC/INPE.
    /// </summary>
    public class Previsao
    {
        public DateOnly Dia { get; set; }

        public string Tempo { get; set; }

        public string Maxima { get; set; }

        public string Minima { get; set; }

        public string Iuv { get; set; }

        public Previsao(DateOnly dia, string tempo, string maxima, string minima, string iuv)
        {
            Dia = dia;
            Tempo = tempo;
            Maxima = maxima;
            Minima = minima;
            Iuv = iuv;
        }
    }
}
