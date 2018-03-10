using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Interfaces.Repositories
{
    public interface IApplicationDbContext
    {
        DbSet<Post> Posts { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
