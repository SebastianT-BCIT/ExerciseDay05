using Microsoft.AspNetCore.Identity;
using WebSecurityDemo.Data;
using WebSecurityDemo.ViewModels;

namespace WebSecurityDemo.Repositories;

public class RoleRepository
{
    private readonly ApplicationDbContext _context;

    public RoleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<RoleVM> GetAllRoles()
    {
        return _context.Roles
            .Select(r => new RoleVM
            {
                Id = r.Id,
                RoleName = r.Name ?? ""
            })
            .ToList();
    }

    public RoleVM? GetRole(string roleName)
    {
        var role = _context.Roles
            .FirstOrDefault(r => r.Name == roleName);

        if (role != null)
        {
            return new RoleVM
            {
                Id = role.Id,
                RoleName = role.Name ?? ""
            };
        }

        return null;
    }

    public bool CreateRole(string roleName)
    {
        try
        {
            _context.Roles.Add(new IdentityRole
            {
                Id = roleName,
                Name = roleName,
                NormalizedName = roleName.ToUpper()
            });

            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating role:" +
                              $" {ex.Message}");
            return false;
        }
    }

    public bool DeleteRole(string roleName)
    {
        try
        {
            var role = _context.Roles
                .FirstOrDefault(r => r.Name == roleName);

            if (role == null)
            {
                return false;   // Role doesn't exist
            }

            _context.Roles.Remove(role);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting role: {ex.Message}");
            return false;
        }
    }
}

