using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using maciejcaputablog.DomainModels;
using maciejcaputablog.InputModels;

namespace maciejcaputablog.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<PostInputModel, PostDomainModel>();
        }
    }
}
