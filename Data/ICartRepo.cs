using dotnet_login.Models;

namespace dotnet_login.Data
{
    public interface ICartRepo
    {
         Cart Create(Cart cart);
    }
}