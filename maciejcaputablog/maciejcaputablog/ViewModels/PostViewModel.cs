using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maciejcaputablog.DomainModels;

namespace maciejcaputablog.ViewModels
{
    public class PostViewModel
    {
        public List<PostDomainModel> PostDomainModels { get; set; }
    }
}
