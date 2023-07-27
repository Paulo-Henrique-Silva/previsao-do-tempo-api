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
            if (ExistePorLogin(usuarioDTO.Login))
            {
                throw new LoginInvalidoException($"O login {usuarioDTO.Login} já existe.");
            }

            return null;
        }

        public Chave CriarChave(UsuarioDTO usuario)
        {
            throw new NotImplementedException();
        }

        public bool ExistePorLogin(string login)
        {
            return usuarioRepository.ExistePorLogin(login).Result;
        }

        public List<Chave> ObterChavesDoUsuario(UsuarioDTO usuario, bool somenteValidas)
        {
            throw new NotImplementedException();
        }

        private static void ConverterDTO(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {

            }
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

                throw new LoginInvalidoException(mensagem);
            }
        }
    }
}
