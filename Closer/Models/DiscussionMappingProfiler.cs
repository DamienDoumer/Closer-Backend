using AutoMapper;
using Closer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Models
{
    public class DiscussionMappingProfiler : Profile
    {
        public DiscussionMappingProfiler()
        {
            CreateMap<Discussion, DiscussionModel>()
                .ForMember(c => c.ID, opt => opt.MapFrom(u => u.Moniker));
        }
    }
}
