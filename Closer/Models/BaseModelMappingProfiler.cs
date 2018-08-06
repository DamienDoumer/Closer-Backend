using AutoMapper;
using Closer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Models
{
    public class BaseModelMappingProfiler : Profile
    {
        public BaseModelMappingProfiler()
        {
            CreateMap<BaseEntity, BaseModel>()
                .ForMember(c => c.ID, opt => opt.MapFrom(u => u.Moniker));
        }
    }
}
