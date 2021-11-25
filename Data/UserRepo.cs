using System.Linq;
using dotnet_login.Models;

namespace dotnet_login.Data
{
    public class UserRepo : IUserRepo
    {
        // inject context
        private readonly UserContext _context;

        public UserRepo(UserContext context)
        
        {
            _context = context;
        }

        public User Create(User user)
        {
            _context.Users.Add(user);
            user.Id = _context.SaveChanges();
            return user;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}