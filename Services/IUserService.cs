using dotnet_api.Models;
using Microsoft.AspNetCore.Http.HttpResults;


namespace dotnet_api.Services;

public interface IUserService
{
  Task<Results<BadRequest, Ok<List<User>>>> GetAllUsers();
  Task<Results<NotFound, Ok<User>>> GetUserById(int id);
  Task<Results<BadRequest<string>, Ok<User>>> CreateUser(User newUser);
  Task<Results<NotFound, Ok<User>>> UpdateUser(User newUser);
}
