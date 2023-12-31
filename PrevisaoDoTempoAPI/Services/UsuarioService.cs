﻿using PrevisaoDoTempoAPI.DTOs;
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

        public UsuarioRespostaDTO Cadastrar(UsuarioLoginDTO usuarioDTO)
        {
            Usuario usuario = ConverterDTO(usuarioDTO);

            ValidarUsuario(usuario);

            if (ExistePorLogin(usuario.Login))
            {
                throw new ConteudoInvalidoException($"O login {usuario.Login} já existe.");
            }

            usuario = usuarioRepository.AdicionarAsync(usuario).Result;
            return new UsuarioRespostaDTO(usuario.Id, usuario.Login, usuario.DataCadastro);
        }

        public ChaveRespostaDTO CriarChave(UsuarioLoginDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                throw new ConteudoInvalidoException("Não foi possível converter os dados enviados.");
            }

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
            chave = chaveRepository.AdicionarAsync(chave).Result;

            return new ChaveRespostaDTO(chave.Id, usuarioDTO.Login, chave.Texto, 
                chave.DataCriacao, chave.DataExpiracao);
        }

        private bool ExistePorLogin(string login)
        {
            return usuarioRepository.ExistePorLoginAsync(login).Result;
        }

        public List<ChaveRespostaDTO> ObterChavesDoUsuario(UsuarioLoginDTO usuarioDTO, bool somenteNaoExpiradas)
        {
            if (usuarioDTO == null)
            {
                throw new ConteudoInvalidoException("Não foi possível converter os dados enviados.");
            }

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

            return chaves.Select(c => new ChaveRespostaDTO(c.Id, usuarioDTO.Login, c.Texto,
                c.DataCriacao, c.DataExpiracao)).ToList();
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
            while (chaveRepository.ExistePorTextoAsync(texto).Result);

            return texto;
        }

        private static Usuario ConverterDTO(UsuarioLoginDTO usuarioDTO)
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

        private bool SenhaCorretaPorLogin(string login, string senha)
        {
            return usuarioRepository.SenhaCorretaPorLoginAsync(login, senha).Result;
        }

        private Usuario ObterPorLogin(string login)
        {
            Usuario? usuario = usuarioRepository.ObterPorLoginAsync(login).Result;

            return usuario ?? throw new ConteudoInvalidoException($"O login {login} não existe.");
        }
    }
}
