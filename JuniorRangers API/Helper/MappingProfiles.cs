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
            CreateMap<Classroom, ClassroomDto>();
            CreateMap<Book, BookDto>();
            CreateMap<Message, MessageDto>();
        }
    }
}
