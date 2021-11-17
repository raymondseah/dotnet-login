using dotnet_login.Models;

namespace dotnet_login.Data
{
    public interface IUserRepo
    {
        User Create(User user);
        User GetByEmail(string email);
        User GetById(int id);
    }
}