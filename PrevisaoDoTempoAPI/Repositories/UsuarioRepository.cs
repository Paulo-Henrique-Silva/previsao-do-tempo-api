using Microsoft.EntityFrameworkCore;
using PrevisaoDoTempoAPI.Data;
using PrevisaoDoTempoAPI.Interfaces;
using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext dataContext;

        public UsuarioRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Usuario> AdicionarAsync(Usuario usuario)
        {
            dataContext.Usuarios.Add(usuario);
            await dataContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> ExistePorLoginAsync(string login)
        {
            return await dataContext.Usuarios.AnyAsync(u => u.Login.Equals(login));
        }

        public async Task<Usuario?> ObterPorLoginAsync(string login)
        {
            return await dataContext.Usuarios.FindAsync(login);
        }

        /// <summary>
        /// Retorna valor booleano para verificação da senha. 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <returns>Retorna true se a senha estiver correta para aquele login, e false caso a senha esteja incorreta ou o login não exista.</returns>
        public async Task<bool> SenhaCorretaPorLoginAsync(string login, string senha)
        {
            Usuario? usuario = await dataContext.Usuarios.FindAsync(login);

            if (usuario != null)
            {
               return usuario.Senha.Equals(senha);
            }

            return false;
        }
    }
}
