using Exo_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Exo_WebApi.Context
{
    public class ExoContext : DbContext
    {
           public ExoContext()
           {}
           public ExoContext(DbContextOptions<ExoContext> options): base(options)
           {
            
           }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ExoApi;Integrated Security=SSPI;TrustServerCertificate=True");
            }
        }
        public DbSet<Projeto> Projetos {get;set;}
    }
}