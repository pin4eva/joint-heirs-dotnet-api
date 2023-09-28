
using dotnet_api.Models;
using dotnet_api.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
  private readonly IUserService userService;
  public UserController(IUserService userService)
  {
    this.userService = userService;
  }

  [HttpGet]
  public async Task<Results<BadRequest, Ok<List<User>>>> GetAllUsers()
  {
    return await userService.GetAllUsers();
  }

  [HttpGet("{id}")]
  public async Task<Results<NotFound, Ok<User>>> GetUserById(int id)
  {
    return await userService.GetUserById(id);
  }
  [HttpPost]
  public async Task<Results<BadRequest<string>, Ok<User>>> CreateUser(User newUser)
  {
    return await userService.CreateUser(newUser);
  }

  [HttpPut]

  public async Task<Results<NotFound, Ok<User>>> UpdateUser(User newUser)
  {
    return await userService.UpdateUser(newUser);
  }

  [HttpDelete("{id}")]
  public async Task<Results<NotFound<string>, Ok<User>>> DeleteUser(int id)
  {
    return await userService.DeleteUser(id);
  }
}
