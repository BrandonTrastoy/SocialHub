using System;
using AutoMapper;
using Backend.Data.DTO.Post;
using Backend.Models;

namespace Backend
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Post, GetPostDto>();
            CreateMap<Post, GetUserPostDto>();
            CreateMap<GetPostDto, Post>();
        }
    }
}