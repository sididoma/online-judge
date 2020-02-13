using AutoMapper;
using KSTU.App.BLL.DTOs;
using KSTU.Web.Models.UserModels;

namespace KSTU.Web.Helpers
{
    public class ApplicationMapperProfileWeb : Profile
    {
        public ApplicationMapperProfileWeb()
        {
            CreateMap<UserDTO, UserVM>();
            CreateMap<UserVM, UserDTO>();
        }
    }
}