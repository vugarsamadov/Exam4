using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam4.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Exam4.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        private IConfiguration _configuration { get; }

        public ApplicationDbContext(DbContextOptions options,IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MSSQL"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var history in this.ChangeTracker.Entries()
            .Where(e => e.Entity is BaseEntity & (e.State == EntityState.Added ||
                e.State == EntityState.Modified))
            .Select(e => e.Entity as BaseEntity)
            )
            {
                history.ModifiedAt = DateTime.Now;
                if (history.CreatedAt <= DateTime.MinValue)
                {
                    history.CreatedAt = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }


    }
}
