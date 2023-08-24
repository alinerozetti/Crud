using Microsoft.EntityFrameworkCore;

namespace WebCrud.Models
{
    [Keyless]
    public class EmpresaFornecedor
    {
        public int Id_Empresa { get; set; }
        public Empresa? Empresa { get; set; }
        public int Id_Fornecedor { get; set; }
        public Fornecedor? Fornecedor { get; set; }

        
    }
}
