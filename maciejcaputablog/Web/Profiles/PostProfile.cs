using System;

using AutoMapper;

using Core.Models.StorageModels;

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
