
using dotnet_api.Models;

namespace dotnet_api.Repositories;

public interface IUserRepo
{
  Task<List<User>> GetAllUsers();
  Task<User?> GetUserById(int id);
  Task<User?> CreateUser(User user);
  void UpdateUser(User user);
  void SaveChangesAsync();

}
