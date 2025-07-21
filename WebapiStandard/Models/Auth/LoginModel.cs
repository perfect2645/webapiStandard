using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebapiStandard.Models.Auth
{
    public class LoginModel : ILoginModel
    {
        [Required(ErrorMessage ="username is required.")]
        [DefaultValue("")]
        public required string Username { get; set; }

        [Required(ErrorMessage ="password is required.")]
        [DefaultValue("")]
        public required string Password { get; set; }
    }
}
