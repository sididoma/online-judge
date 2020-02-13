using AutoMapper;
using KSTU.App.BLL.DTOs;
using KSTU.App.Data.Entities;

namespace KSTU.App.BLL.Helpers
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}