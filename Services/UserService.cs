
using dotnet_api.Data;
using dotnet_api.Models;
using dotnet_api.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;


namespace dotnet_api.Services;

public class UserService : IUserService
{
  private readonly IUserRepo userRepo;
  private readonly DataContext db;

  public UserService(IUserRepo _repo, DataContext dataContext)
  {
    userRepo = _repo;
    db = dataContext;
  }

  public async Task<Results<BadRequest, Ok<List<User>>>> GetAllUsers()
  {
    var users = await userRepo.GetAllUsers();
    return TypedResults.Ok(users);
  }

  public async Task<Results<NotFound, Ok<User>>> GetUserById(int id)
  {
    var user = await userRepo.GetUserById(id);
    if (user == null) return TypedResults.NotFound();

    return TypedResults.Ok(user);
  }

  public async Task<Results<BadRequest<string>, Ok<User>>> CreateUser(User newUser)
  {
    var existingUser = await db.Users.FirstOrDefaultAsync(user => user.Name == newUser.Name || user.Email == newUser.Email);
    if (existingUser is not null) return TypedResults.BadRequest("User with name already exist");
    var user = await userRepo.CreateUser(newUser);

    if (user == null) return TypedResults.BadRequest("Unable to create user");

    return TypedResults.Ok(user);
  }

  public async Task<Results<NotFound, Ok<User>>> UpdateUser(User newUser)
  {
    var user = await userRepo.GetUserById(newUser.Id);
    if (user == null) return TypedResults.NotFound();


    user.Name = newUser.Name;
    user.Email = newUser.Email;

    await userRepo.SaveChangesAsync();

    return TypedResults.Ok(user);

  }

  public async Task<Results<NotFound<string>, Ok<User>>> DeleteUser(int id)
  {
    var user = await userRepo.GetUserById(id);
    if (user == null) return TypedResults.NotFound("Invalid user ID");

    await userRepo.DeleteUser(user);
    return TypedResults.Ok(user);

  }
}
