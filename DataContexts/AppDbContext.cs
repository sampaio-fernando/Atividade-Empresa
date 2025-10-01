using Atividade_Empresa.Models;
using Microsoft.EntityFrameworkCore;

namespace Atividade_Empresa.DataContexts
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options): base(options) 
        {
            
        }
        public DbSet<Empresa> Empresas { get; set; }
    }
}
