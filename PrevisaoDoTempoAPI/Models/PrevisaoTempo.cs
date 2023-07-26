namespace PrevisaoDoTempoAPI.Models
{
    /// <summary>
    /// Objeto que combina as respostas da API ViaCEP e da API CPTEC/INPE.
    /// </summary>
    public class PrevisaoTempo
    {
        public DateOnly Atualizacao { get; set; }

        public Localizacao Localizacao { get; set; }

        public List<Previsao> Previsoes { get; set; }

        public PrevisaoTempo(DateOnly atualizacao, Localizacao localizacao, List<Previsao> previsoes)
        {
            Atualizacao = atualizacao;
            Localizacao = localizacao;
            Previsoes = previsoes;
        }
    }
}
