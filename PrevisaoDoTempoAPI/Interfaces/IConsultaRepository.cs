using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Interfaces
{
    public interface IConsultaRepository
    {
        Task<List<Consulta>> ObterTudo();

        Task<Consulta> Adicionar(Consulta consulta);
    }
}
