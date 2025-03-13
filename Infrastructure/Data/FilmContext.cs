using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public  class FilmContext: IdentityDbContext<UserDb,IdentityRole<Guid>,Guid>
    {
        DbSet<FilmDb> films { get; set; }
        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserDb>()
                .HasMany(u => u.Films)
                .WithOne(f => f.User)
                .HasForeignKey(f => f.UserId);
        }
    }
}
