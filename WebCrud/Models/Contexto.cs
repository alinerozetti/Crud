using Microsoft.EntityFrameworkCore;

namespace WebCrud.Models
{
    
    public class Contexto : DbContext
    { 
        public Contexto( DbContextOptions<Contexto> options): base(options)
        {
                
        }

        public DbSet<Empresa>Empresa { get; set; }

        public DbSet<Fornecedor>Fornecedor { get; set; }

        public DbSet<EmpresaFornecedor> EmpresaFornecedor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmpresaFornecedor>()
                .HasKey(ef => new { ef.Id_Empresa, ef.Id_Fornecedor });
            modelBuilder.Entity<EmpresaFornecedor>()
                .HasOne(ef => ef.Empresa)
                .WithMany(e => e.EmpresaFornecedores)
                .HasForeignKey(ef => ef.Id_Empresa);
            modelBuilder.Entity<EmpresaFornecedor>()
                .HasOne(ef => ef.Fornecedor)
                .WithMany(f => f.EmpresaFornecedores)
                .HasForeignKey(ef => ef.Id_Fornecedor);
        }
        
    }

    

}
