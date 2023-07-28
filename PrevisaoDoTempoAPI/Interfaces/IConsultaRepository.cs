using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Interfaces
{
    public interface IConsultaRepository
    {
        Task<List<Consulta>> ObterTudoAsync();

        Task<Consulta> AdicionarAsync(Consulta consulta);
    }
}
