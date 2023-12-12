using Core.Infrastructure;
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
        }

        public DbSet<User> Users { get; set; }
    }
}
