using Core.Infrastructure;
using Core.Models;
using Core.Services.Shared;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class TemplateDbContext : DbContext
    {
        //public TemplateDbContext()
        //{
        //}

        public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
        {
            DataGenerator.InitializeUsers(this);
            DataGenerator.InitializeVueCalEvent(this);
            DataGenerator.InitializePermesso(this);
            DataGenerator.InitializeRendicontazione(this);
            DataGenerator.InitializeFeria(this);
            DataGenerator.InitializeNotteFuori(this);
            DataGenerator.InitializeTrasferta(this);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<VueCalEvent> VueCalEvent { get; set; }
        public DbSet<Rendicontazione> Rendicontazione { get; set; }
        public DbSet<Permesso> Permesso { get; set; }
        public DbSet<Feria> Feria { get; set; }
        public DbSet<NotteFuori> NotteFuori { get; set; }
        public DbSet<Trasferta> Trasferta { get; set; }

    }
}
