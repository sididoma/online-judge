using System.ComponentModel.DataAnnotations;

namespace KSTU.Web.Models.UserModels
{
    public class AuthenticationModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}