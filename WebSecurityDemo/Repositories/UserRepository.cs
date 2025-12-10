using WebSecurityDemo.Data;
using WebSecurityDemo.ViewModels;

namespace WebSecurityDemo.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<UserVM> GetAllUsers()
        {
            List<UserVM> users = _context.Users
                                         .Select(u => new UserVM { Email = u.Email ?? string.Empty })
                                         .ToList();

            return users;
        }
    }
}
