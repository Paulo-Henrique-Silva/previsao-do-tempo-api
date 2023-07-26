using Microsoft.EntityFrameworkCore;
using PrevisaoDoTempoAPI.Data;
using PrevisaoDoTempoAPI.Interfaces;
using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Repositories
{
    public class ChaveRepository : IChaveRepository
    {
        private readonly DataContext dataContext;

        public ChaveRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Chave> Adicionar(Chave chave)
        {
            dataContext.Chaves.Add(chave);
            await dataContext.SaveChangesAsync();

            return chave;
        }

        public async Task<List<Chave>> ObterChavesPorUsuarioId(uint usuarioId)
        {
            return await dataContext.Chaves.Where(c => c.UsuarioId == usuarioId).ToListAsync();
        }

        public async Task<List<Chave>> ObterTudo()
        {
            return await dataContext.Chaves.ToListAsync();
        }
    }
}
