using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Timely.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public sealed class AuthController : ControllerBase
{
    [HttpGet("login")]
    public async Task<IActionResult> Login()
    {
        return Ok("Login successful");
        //return result.IsFailed ? result.ToProblem() : Ok();
    }
}
