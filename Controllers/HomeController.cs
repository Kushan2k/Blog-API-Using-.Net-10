using Microsoft.AspNetCore.Mvc;

namespace learn.Controllers;


[ApiController]
[Route("/")]

public class HomeController : Controller
{

    [HttpGet("/test")]
    public IActionResult Index()
    {
        return Ok("Welcome to the Home Page!");
    }

}
