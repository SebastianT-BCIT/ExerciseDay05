using System.ComponentModel.DataAnnotations;

namespace WebSecurityDemo.ViewModels;

public class UserRoleVM
{
    public int? Id { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "User Email")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Role Name")]
    public string Role { get; set; } = string.Empty;
}
