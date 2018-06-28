using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UI.Web.Models;

namespace UI.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<Jogador>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.ApplyConfiguration(new Configurations.JogadorPartidaConfiguration());
        }

        public DbSet<UI.Web.Models.Pino> Pino { get; set; }

        public DbSet<UI.Web.Models.Jogador> Jogador { get; set; }
    }
}
