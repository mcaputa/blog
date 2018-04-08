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
            this.CreateMap<PostInputModel, PostStorageModel>().ForMember(
                    dest => dest.PostSeoStorageModel,
                    map => map.MapFrom(src => Mapper.Map<PostInputModel, PostSeoStorageModel>(src)))
                .ForMember(dest => dest.Description, map => map.MapFrom(src => src.Text))
                .ForMember(dest => dest.CreatedOn, map => map.MapFrom(src => DateTime.Now));

            this.CreateMap<PostInputModel, PostSeoStorageModel>();
        }
    }
}
