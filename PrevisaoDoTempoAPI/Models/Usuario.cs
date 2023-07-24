using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevisaoDoTempoAPI.Models
{
    /// <summary>
    /// Representa o usuário com conta no sistema.
    /// </summary>
    [Table("tb_usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public uint Id { get; set; }

        [Column("login")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O login é obrigatório.")]
        [StringLength(20, ErrorMessage = "O login deve ter no máximo 20 caracteres.")]
        public string Login { get; set; }

        [Column("senha")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A senha é obrigatória.")]
        [StringLength(20, ErrorMessage = "A senha deve ter no máximo 20 caracteres.")]
        public string Senha { get; set; }

        [Column("data_cadastro")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A data de cadastro é obrigatória.")]
        public DateTime DataCadastro { get; set; }

        //propriedades de navegação
        public List<Chave>? Chaves { get; set; }

        public List<Consulta>? Consultas { get; set; }

        public Usuario(string login, string senha, DateTime dataCadastro)
        {
            Login = login;
            Senha = senha;
            DataCadastro = dataCadastro;
        }
    }
}
