using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace WebCrud.Models
{
    [Table("Empresa")]
    public class Empresa
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("NomeFantasia")]
        [Display(Name = "Nome Fantasia")]

        public string NomeFantasia { get; set; }

        [Column("CNPJ")]
        [Display(Name = "CNPJ")]

        public string CNPJ { get; set; }

        [Column("Cep")]
        [Display(Name = "CEP")]

        public string Cep { get; set; }

        public ICollection<EmpresaFornecedor>? EmpresaFornecedores { get; set; }

    }
}
