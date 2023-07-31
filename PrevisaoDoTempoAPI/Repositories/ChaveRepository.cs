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

        public async Task<Chave> AdicionarAsync(Chave chave)
        {
            dataContext.Chaves.Add(chave);
            await dataContext.SaveChangesAsync();

            return chave;
        }

        public async Task<bool> ExistePorTextoAsync(string chaveTexto)
        {
            return await dataContext.Chaves.AnyAsync(c => c.Texto.Equals(chaveTexto));
        }

        public async Task<List<Chave>> ObterChavesPorUsuarioIdAsync(uint usuarioId)
        {
            return await dataContext.Chaves.Where(c => c.UsuarioId == usuarioId).ToListAsync();
        }

        public async Task<Chave?> ObterPorTextoAsync(string chaveTexto)
        {
            return await dataContext.Chaves.FirstAsync(c => c.Texto.Equals(chaveTexto));
        }

        public async Task<List<Chave>> ObterTudoAsync()
        {
            return await dataContext.Chaves.ToListAsync();
        }
    }
}
