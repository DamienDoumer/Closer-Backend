﻿using AutoMapper;
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
                .ForMember(bm => bm.CreatedAt, opt => opt.MapFrom(be => be.CreatedAt))
                .ReverseMap();

            CreateMap<User, UserModel>()
                .IncludeBase<BaseEntity, BaseModel>()
                .ForMember(bm => bm.Name, opt => opt.MapFrom(be => be.Name))
                .ReverseMap();


            CreateMap<Discussion, DiscussionModel>()
                .IncludeBase<BaseEntity, BaseModel>()
                .ForMember(bm => bm.CreatorId, opt => opt.ResolveUsing(be => be.Creator == null ? be.DiscussionUserCreatorId : be.Creator.Id))
                .ReverseMap();

            CreateMap<Message, MessageModel>()
                .IncludeBase<BaseEntity, BaseModel>()
                .ForMember(bm => bm.RespondToMessageId, opt => opt.ResolveUsing(be => be.RespondToMessage == null ? be.InRespondToMessageID : be.RespondToMessage.Id.ToString()))
                .ForMember(bm => bm.SenderId, opt => opt.MapFrom(be => be.MessageUserId))
                .ForMember(bm => bm.ConversationId, opt => opt.MapFrom(be => be.MessageDiscussionId))
                .ReverseMap();

            CreateMap<UserDiscussion, UserDiscussionModel>()
                .ReverseMap();
        }
    }
}
