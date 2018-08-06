using AutoMapper;
using Closer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Models
{
    public class CloserMappingProfiler : Profile
    {
        public CloserMappingProfiler()
        {
            CreateMap<BaseEntity, BaseModel>()
                .ForMember(bm => bm.ID, opt => opt.MapFrom(be => be.Moniker))
                .ForMember(bm => bm.Url, opt => opt.MapFrom(be => $""));

            CreateMap<Message, MessageModel>()
                .IncludeBase<BaseEntity, BaseModel>();

            CreateMap<Message, MessageModel>()
                .IncludeBase<BaseEntity, BaseModel>();

            CreateMap<User, UserModel>()
                .IncludeBase<BaseEntity, BaseModel>();

            CreateMap<Discussion, DiscussionModel>()
                .IncludeBase<BaseEntity, BaseModel>();

        }
    }
}
