using System.ComponentModel.DataAnnotations.Schema;

namespace Atividade_Empresa.Models
{
    [Table("empresa")]
    public class Empresa
    {
        [Column("id_emp")]
        public int Id { get; set; }

        [Column("razao_social_emp")]
        public required string Razao_social { get; set; }

        [Column("nome_fantasia_emp")]
        public required string Nome_fantasia {  get; set; }

        [Column("cnpj_emp")]
        public required string CNPJ {  get; set; }

        [Column("insc_estadual_emp")]
        public string? Insc_estadual {  get; set; }

        [Column("telefone_emp")]
        public required string Telefone {  get; set; }

        [Column("email_emp")]
        public required string Email { get; set; }

        [Column("cidade_emp")]
        public required string Cidade { get; set; }

        [Column("estado_emp")]
        public required string UF { get; set; }

        [Column("cep_emp")]
        public required string CEP { get; set; }

        [Column("dt_cadastro_emp")]
        public DateTime Dt_cadastro {  get; set; }
    }
}
