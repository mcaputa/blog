using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maciejcaputablog.DomainModels;

namespace maciejcaputablog.Repositories
{
    public interface IPostRepository
    {
        List<PostDomainModel> GetAllPosts();
        PostDomainModel GetPost(int postId);
        void CreatePost(PostDomainModel postDomainModel);
    }
}
