using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.DTOs
{
    /// <summary>
    /// Objeto que combina as respostas da API ViaCEP e da API CPTEC/INPE.
    /// </summary>
    public class PrevisaoTempoDTO
    {
        public DateOnly Atualizacao { get; set; }

        public Localizacao Localizacao { get; set; }

        public List<PrevisaoDia> PrevisoesDias { get; set; }

        public PrevisaoTempoDTO(DateOnly atualizacao, Localizacao localizacao, 
            List<PrevisaoDia> previsoesDias)
        {
            Atualizacao = atualizacao;
            Localizacao = localizacao;
            PrevisoesDias = previsoesDias;
        }
    }
}
