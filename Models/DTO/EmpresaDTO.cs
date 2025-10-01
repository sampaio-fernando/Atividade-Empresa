namespace Atividade_Empresa.Models.DTO
{
    public class EmpresaDTO
    {

        public required string Razao_social { get; set; }
        public required string Nome_fantasia { get; set; }
        public required string Telefone { get; set; }
        public required string Email { get; set; }
        public required string Cidade { get; set; }
        public required string UF { get; set; }
        public required string CEP { get; set; }
    }
}
