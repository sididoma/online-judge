using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KSTU.App.BLL.Interfaces;
using KSTU.Web.Models.UserModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSTU.Web.Areas.App.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        [ProducesResponseType(typeof(UserVM), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(string))]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticationModel model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is invalid" });
            }
            var userVM = _mapper.Map<UserVM>(user);
            return Ok(userVM);
        }
        [HttpGet("all")]
        [ProducesResponseType(typeof(IEnumerable<UserVM>), 200)]
        [ProducesErrorResponseType(typeof(string))]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.ListAll();
            var userVM = _mapper.Map<IEnumerable<UserVM>>(users);
            return Ok(users);
        }
    }
}