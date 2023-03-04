using Microsoft.AspNetCore.Mvc;

namespace social_network_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase {
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger) {
        _logger = logger;
    }

    [HttpGet]
    [Route("test")]
    public ActionResult Get() {
        return Ok();
    }
    
}