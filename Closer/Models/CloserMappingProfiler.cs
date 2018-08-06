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
            CreateMap<Message, MessageModel>()
                .ForMember(c => c.ID, opt => opt.MapFrom(u => u.Moniker));

            CreateMap<User, UserModel>()
                .ForMember(c => c.ID, opt => opt.MapFrom(u => u.Moniker));

            CreateMap<Discussion, DiscussionModel>()
                .ForMember(c => c.ID, opt => opt.MapFrom(u => u.Moniker));
        }
    }
}
