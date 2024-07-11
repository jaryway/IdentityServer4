using System.ComponentModel.DataAnnotations;

namespace Jaryway.IdentityServer.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
