namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;


[Controller]
public abstract class BaseController : ControllerBase
{
    // returns the current authenticated user (null if not logged in)
    public User User => (User)HttpContext.Items["User"];
}
