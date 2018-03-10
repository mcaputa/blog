using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<FormContact> FormContacts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PostTag>()
                .HasKey(t => new { t.PostId, t.TagId });
            
            builder.Entity<PostCategory>()
                .HasKey(t => new { t.PostId, t.CategoryId });

            base.OnModelCreating(builder);
        }
    }
}
