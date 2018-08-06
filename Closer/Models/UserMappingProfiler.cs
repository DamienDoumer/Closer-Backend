using AutoMapper;
using Closer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Models
{
    public class UserMappingProfiler : Profile
    {
        public UserMappingProfiler()
        {
            CreateMap<User, UserModel>();
        }
    }
}
