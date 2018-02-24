using System;
using ApplicationCore.Models.StorageModels;
using AutoMapper;
using maciejcaputablog.InputModels;

namespace Web.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<PostInputModel, PostStorageModel>()
                .ForMember(dest => dest.CreatedOn, map => map.MapFrom(src => DateTime.Now));
        }
    }
}
