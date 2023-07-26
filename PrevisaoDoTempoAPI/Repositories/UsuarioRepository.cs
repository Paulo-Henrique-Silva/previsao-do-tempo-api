using PrevisaoDoTempoAPI.Data;
using PrevisaoDoTempoAPI.Interfaces;
using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Repositories
{
    public class UsuarioRepository
    {
        private readonly DataContext dataContext;

        public UsuarioRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
    }
}
