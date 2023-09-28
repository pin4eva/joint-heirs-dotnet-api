using dotnet_api.Data;
using dotnet_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_api.Repositories;

public class UserRepo : IUserRepo
{
  private readonly DataContext db;
  public UserRepo(DataContext dataContext)
  {
    db = dataContext;
  }



  public async Task UpdateUser(User newUser)
  {
    await db.SaveChangesAsync();
  }
  public async Task<List<User>> GetAllUsers()
  {
    var users = await db.Users.ToListAsync();
    return users;
  }

  public async Task<User?> GetUserById(int id)
  {
    return await db.Users.FindAsync(id);
  }

  public async Task<User?> CreateUser(User user)
  {



    db.Users.Add(user);
    await db.SaveChangesAsync();
    return user;
  }

  public async Task SaveChangesAsync()
  {
    await db.SaveChangesAsync();
  }

  public async Task DeleteUser(User user)
  {
    db.Remove(user);
    await db.SaveChangesAsync();
  }
}
