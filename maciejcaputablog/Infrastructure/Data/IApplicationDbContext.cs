using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Faq> Faqs { get; set; }

        DbSet<Post> Posts { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
