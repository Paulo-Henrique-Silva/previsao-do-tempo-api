using Microsoft.EntityFrameworkCore;
using PrevisaoDoTempoAPI.Data;
using PrevisaoDoTempoAPI.Interfaces;
using PrevisaoDoTempoAPI.Models;
using System;

namespace PrevisaoDoTempoAPI.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly DataContext dataContext;

        public ConsultaRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Consulta> Adicionar(Consulta consulta)
        {
            dataContext.Consultas.Add(consulta);
            await dataContext.SaveChangesAsync();

            return consulta;
        }

        public async Task<List<Consulta>> ObterTudo()
        {
            return await dataContext.Consultas.ToListAsync();
        }
    }
}
