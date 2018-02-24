using System.ComponentModel.DataAnnotations;

namespace maciejcaputablog.ViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
