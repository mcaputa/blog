using System;
using ApplicationCore.Models.StorageModels;
using AutoMapper;

namespace Web.Profiles
{
    using Web.InputModels;

    public class PostProfile : Profile
    {
        public PostProfile()
        {
            this.CreateMap<PostInputModel, PostStorageModel>()
                .ForMember(dest => dest.CreatedOn, map => map.MapFrom(src => DateTime.Now));
        }
    }
}
