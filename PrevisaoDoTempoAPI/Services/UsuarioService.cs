using PrevisaoDoTempoAPI.DTOs;
using PrevisaoDoTempoAPI.Exceptions;
using PrevisaoDoTempoAPI.Interfaces;
using PrevisaoDoTempoAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace PrevisaoDoTempoAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;

        private readonly IChaveRepository chaveRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, IChaveRepository chaveRepository)
        {
            this.usuarioRepository = usuarioRepository;
            this.chaveRepository = chaveRepository;
        }

        public Usuario Cadastrar(UsuarioDTO usuarioDTO)
        {
            Usuario usuario = ConverterDTO(usuarioDTO);

            ValidarUsuario(usuario);

            if (ExistePorLogin(usuario.Login))
            {
                throw new ConteudoInvalidoException($"O login {usuario.Login} já existe.");
            }

            return usuario;
        }

        public Chave CriarChave(UsuarioDTO usuarioDTO)
        {
            if (!ExistePorLogin(usuarioDTO.Login))
            {
                throw new LoginInvalidoException($"O login {usuarioDTO.Login} não existe.");
            }

            if (!SenhaCorretaPorLogin(usuarioDTO.Login, usuarioDTO.Senha))
            {
                throw new LoginInvalidoException($"Senha incorreta.");
            }

            Usuario? usuario = ObterPorLogin(usuarioDTO.Login);
            DateTime dataAtual = DateTime.Now;
            var chave = new Chave(usuario.Id, GerarTextoChave(), dataAtual, dataAtual.AddDays(3));

            chaveRepository.AdicionarAsync(chave);
            return chave;   
        }

        public bool ExistePorLogin(string login)
        {
            return usuarioRepository.ExistePorLoginAsync(login).Result;
        }

        public List<Chave> ObterChavesDoUsuario(UsuarioDTO usuarioDTO, bool somenteNaoExpiradas)
        {
            if (!ExistePorLogin(usuarioDTO.Login))
            {
                throw new LoginInvalidoException($"O login {usuarioDTO.Login} não existe.");
            }

            if (!SenhaCorretaPorLogin(usuarioDTO.Login, usuarioDTO.Senha))
            {
                throw new LoginInvalidoException($"Senha incorreta.");
            }

            uint usuarioId = ObterPorLogin(usuarioDTO.Login).Id;
            List<Chave> chaves = chaveRepository.ObterChavesPorUsuarioIdAsync(usuarioId).Result;

            if (somenteNaoExpiradas)
            {
                chaves = chaves.Where(c => c.ChaveNaoExpirada).ToList();
            }

            return chaves;
        }

        private string GerarTextoChave()
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string texto = string.Empty;
            Random random = new();

            do
            {
                for (int i = 0; i < 6; i++)
                {
                    texto += caracteres[random.Next(caracteres.Length)];
                }
            } 
            while (!chaveRepository.ExistePorTextoAsync(texto).Result);

            return texto;
        }

        private static Usuario ConverterDTO(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                throw new ConteudoInvalidoException("Não foi possível converter os dados enviados.");
            }

            return new Usuario(usuarioDTO.Login, usuarioDTO.Senha, DateTime.Now);
        }

        private static void ValidarUsuario(Usuario usuario)
        {
            //Validação a partir de data annotations.
            var validacaoContexto = new ValidationContext(usuario, null, null);
            var validacaoResultados = new List<ValidationResult>();
            bool EValido = Validator.TryValidateObject(usuario, validacaoContexto, validacaoResultados,
                true);

            if (!EValido)
            {
                //obtém a primeira mensagem de erro ao validar.
                var mensagem = validacaoResultados.Select(vr => vr.ErrorMessage).FirstOrDefault();

                throw new ConteudoInvalidoException(mensagem);
            }
        }

        public bool SenhaCorretaPorLogin(string login, string senha)
        {
            return usuarioRepository.SenhaCorretaPorLoginAsync(login, senha).Result;
        }

        public Usuario ObterPorLogin(string login)
        {
            Usuario? usuario = usuarioRepository.ObterPorLoginAsync(login).Result;

            return usuario ?? throw new ConteudoInvalidoException($"O login {login} não existe.");
        }
    }
}
