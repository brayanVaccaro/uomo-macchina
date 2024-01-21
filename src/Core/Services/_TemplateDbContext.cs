using Core.Infrastructure;
using Core.Models;
using Core.Services.Shared;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class TemplateDbContext : DbContext
    {
        public TemplateDbContext()
        {
        }

        public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
        {
            DataGenerator.InitializeUsers(this);
            DataGenerator.InitializeVueCalEvent(this);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<VueCalEvent> VueCalEvent { get; set; }
    }
}
