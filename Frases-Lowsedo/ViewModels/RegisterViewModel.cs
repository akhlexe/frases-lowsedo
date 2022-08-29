using System.ComponentModel.DataAnnotations;

namespace Frases_Lowsedo.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Apreta bien las teclas siome.")]
        public string ConfirmPassword { get; set; }
    }
}
