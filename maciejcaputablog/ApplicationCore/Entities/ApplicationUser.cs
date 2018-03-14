using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    using System.Collections.Generic;

    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
