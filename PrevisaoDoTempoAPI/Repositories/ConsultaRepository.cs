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

        public async Task<Consulta> AdicionarAsync(Consulta consulta)
        {
            dataContext.Consultas.Add(consulta);
            await dataContext.SaveChangesAsync();

            return consulta;
        }

        public async Task<List<Consulta>> ObterTudoAsync()
        {
            return await dataContext.Consultas.ToListAsync();
        }

        public async Task<List<Consulta>> ObterTudoComUsuariosAsync()
        {
            return await dataContext.Consultas.Include(c => c.Usuario).ToListAsync();
        }
    }
}
