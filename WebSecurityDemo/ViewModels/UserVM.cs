using System.ComponentModel.DataAnnotations;

namespace WebSecurityDemo.ViewModels;

public class UserVM
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;
}

