namespace WebCrud.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CNPJ_CPF { get; set; }

        public string Email { get; set; }

        public string Cep { get; set; }

        public string? Rg { get; set; }

        public DateTime? DtNascimento { get; set; }

        public ICollection<EmpresaFornecedor>? EmpresaFornecedores { get; set; }
    }
}
