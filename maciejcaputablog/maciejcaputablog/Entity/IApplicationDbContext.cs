using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using maciejcaputablog.Models;
using Microsoft.EntityFrameworkCore;

namespace maciejcaputablog.Entity
{
    public interface IApplicationDbContext
    {
        DbSet<Faq> Faqs { get; set; }

        DbSet<Post> Posts { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
