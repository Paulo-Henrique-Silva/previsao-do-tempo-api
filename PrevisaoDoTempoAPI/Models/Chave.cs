using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevisaoDoTempoAPI.Models
{
    [Table("tb_chaves")]
    public class Chave
    {
        [Key]
        [Column("id")]
        public uint Id { get; set; }

        [Column("usuario_id")]
        [ForeignKey("usuario_fk")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Uma chave precisa de um usuário dono.")]
        public uint UsuarioId { get; set; }

        [Column("texto")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O texto é obrigatório.")]
        [StringLength(6, ErrorMessage = "O texto deve ter no máximo 6 caracteres.")]
        public string Texto { get; set; }

        [Column("data_criacao")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A data de criação é obrigatória.")]
        public DateTime DataCriacao { get; set; }

        [Column("data_expiracao")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A data de expiração é obrigatória.")]
        public DateTime DataExpiracao { get; set; }

        public bool ChaveValida => DataExpiracao >= DateTime.UtcNow;

        //propriedade de navegação.
        public Usuario? Usuario { get; set; }

        public Chave(uint usuarioId, string texto, DateTime dataCriacao, DateTime dataExpiracao)
        {
            UsuarioId = usuarioId;
            Texto = texto;
            DataCriacao = dataCriacao;
            DataExpiracao = dataExpiracao;
        }
    }
}
