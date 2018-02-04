using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using maciejcaputablog.InputModels;
using maciejcaputablog.StorageModels;

namespace maciejcaputablog.Profiles
{
    public class FaqProfile : Profile
    {
        public FaqProfile()
        {
            CreateMap<FaqInputModel, FaqDomainModel>();
        }
    }
}
