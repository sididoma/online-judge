using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KSTU.App.BLL.DTOs;
using KSTU.App.BLL.Interfaces;
using KSTU.App.Data.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace KSTU.App.BLL.Services
{
    public class UserService : IUserService
    {
        private static List<User> _users = new List<User>{
            new User{Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test"},
            new User{Id = 2, FirstName = "Test2",LastName = "User2",Username = "test2",Password = "test2"}
        };
        private readonly IMapper _mapper;
        private readonly AppSetting _appSettings;
        public UserService(IOptions<AppSetting> appSetting, IMapper mapper)
        {
            _mapper = mapper;
            _appSettings = appSetting.Value;
        }

        public async Task<UserDTO> Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            if (user == null)
                return null;

            var userDTO = _mapper.Map<User, UserDTO>(user);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            userDTO.Token = tokenHandler.WriteToken(token);

            return userDTO;
        }

        public async Task<IEnumerable<UserDTO>> ListAll()
        {
            return _mapper.ProjectTo<UserDTO>(_users.AsQueryable()).ToList();
        }
    }
}