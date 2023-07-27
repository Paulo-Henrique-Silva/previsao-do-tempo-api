namespace PrevisaoDoTempoAPI.DTOs
{
    /// <summary>
    /// Objeto que combina as respostas da API ViaCEP e da API CPTEC/INPE.
    /// </summary>
    public class PrevisaoTempoDTO
    {
        public DateOnly Atualizacao { get; set; }

        public LocalizacaoDTO Localizacao { get; set; }

        public List<PrevisaoDiaDTO> PrevisoesDias { get; set; }

        public PrevisaoTempoDTO(DateOnly atualizacao, LocalizacaoDTO localizacao, 
            List<PrevisaoDiaDTO> previsoesDias)
        {
            Atualizacao = atualizacao;
            Localizacao = localizacao;
            PrevisoesDias = previsoesDias;
        }
    }
}
