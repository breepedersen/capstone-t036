using AutoMapper;
using JuniorRangers_API.Dto;
using JuniorRangers_API.Models;

namespace JuniorRangers_API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Classroom, ClassroomDto>();
            CreateMap<ClassroomDto, Classroom>();
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
            CreateMap<Message, MessageDto>();
            CreateMap<MessageDto, Message>();
            CreateMap<Achievement, AchievementDto>();
            CreateMap<AchievementDto, Achievement>();
            CreateMap<Album, AlbumDto>();
            CreateMap<AlbumDto, Album>();
            CreateMap<Picture, PictureDto>();
            CreateMap<PictureDto, Picture>();
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
        }
    }
}
