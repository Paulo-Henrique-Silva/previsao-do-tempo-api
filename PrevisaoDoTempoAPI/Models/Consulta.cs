using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevisaoDoTempoAPI.Models
{
    [Table("tb_consultas")]
    public class Consulta
    {
        [Key]
        [Column("id")]
        public uint Id { get; set; }

        [Column("usuario_id")]
        [ForeignKey("usuario_fk")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Uma consulta precisa de um usuário dono.")]
        public uint UsuarioId { get; set; }

        [Column("cep")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O cep é obrigatório.")]
        [StringLength(8, ErrorMessage = "O cep deve ter no máximo 8 caracteres.")]
        public string Cep { get; set; }

        [Column("data_consulta")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A data da consulta é obrigatória.")]
        public DateTime DataConsulta { get; set; }

        //propriedade de navegação.
        public Usuario? Usuario { get; set; }

        public Consulta(uint usuarioId, string cep, DateTime dataConsulta)
        {
            UsuarioId = usuarioId;
            Cep = cep;
            DataConsulta = dataConsulta;
        }
    }
}
