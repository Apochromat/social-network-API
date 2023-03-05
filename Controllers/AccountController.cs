using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using social_network_API.Models.DTO;
using social_network_API.Services;

namespace social_network_API.Controllers;

/// <summary>
/// Controller for auth and profile
/// </summary>
[ApiController]
[Route("api/account")]
public class AccountController : ControllerBase {
    private readonly ILogger<AccountController> _logger;
    private readonly IAccountService _account;

    /// <summary>
    /// Controller for auth and profile
    /// </summary>
    public AccountController(ILogger<AccountController> logger, IAccountService accountService) {
        _logger = logger;
        _account = accountService;
    }

    /// <summary>
    /// Register new user.
    /// </summary>
    [HttpPost]
    [Route("register")]
    public async Task<ActionResult<TokenResponse>> Register([FromBody] UserRegisterModel userRegisterModel) {
        try {
            return await _account.Register(userRegisterModel);
        }
        catch (ArgumentNullException e) {
            _logger.LogError(e,
                $"Message: {e.Message} TraceId: {Activity.Current?.Id ?? HttpContext.TraceIdentifier}");
            return Problem(statusCode: 400, title: e.Message);
        }
        catch (ArgumentException e) {
            _logger.LogError(e,
                $"Message: {e.Message} TraceId: {Activity.Current?.Id ?? HttpContext.TraceIdentifier}");
            return Problem(statusCode: 400, title: e.Message);
        }
        catch (InvalidOperationException e) {
            _logger.LogError(e,
                $"Message: {e.Message} TraceId: {Activity.Current?.Id ?? HttpContext.TraceIdentifier}");
            return Problem(statusCode: 409, title: e.Message);
        }
        catch (Exception e) {
            _logger.LogError(e,
                $"Message: {e.Message} TraceId: {Activity.Current?.Id ?? HttpContext.TraceIdentifier}");
            return Problem(statusCode: 500, title: "Something went wrong");
        }
    }

    /// <summary>
    /// Log in to the system.
    /// </summary>
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<TokenResponse>> Login([FromBody] LoginCredentials loginCredentials) {
        try {
            return await _account.Login(loginCredentials);
        }
        catch (ArgumentException e) {
            _logger.LogError(e,
                $"Message: {e.Message} TraceId: {Activity.Current?.Id ?? HttpContext.TraceIdentifier}");
            return Problem(statusCode: 401, title: e.Message);
        }
        catch (Exception e) {
            _logger.LogError(e,
                $"Message: {e.Message} TraceId: {Activity.Current?.Id ?? HttpContext.TraceIdentifier}");
            return Problem(statusCode: 500, title: "Something went wrong");
        }
    }

    /// <summary>
    /// Get user profile.
    /// </summary>
    [HttpGet]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("profile")]
    public async Task<ActionResult<UserProfile>> GetAccountProfile() {
        try {
            return await _account.GetProfile(User.Identity.Name);
        }
        catch (KeyNotFoundException e) {
            _logger.LogError(e,
                $"Message: {e.Message} TraceId: {Activity.Current?.Id ?? HttpContext.TraceIdentifier}");
            return Problem(statusCode: 404, title: e.Message);
        }
        catch (Exception e) {
            _logger.LogError(e,
                $"Message: {e.Message} TraceId: {Activity.Current?.Id ?? HttpContext.TraceIdentifier}");
            return Problem(statusCode: 500, title: "Something went wrong");
        }
    }


    /// <summary>
    /// Edit user profile.
    /// </summary>
    [HttpPut]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("profile")]
    public async Task<ActionResult<Response>> EditAccountProfile([FromBody] UserProfileEdit userProfileEdit) {
        try {
            return await _account.EditProfile(User.Identity.Name, userProfileEdit);
        }
        catch (KeyNotFoundException e) {
            _logger.LogError(e,
                $"Message: {e.Message} TraceId: {Activity.Current?.Id ?? HttpContext?.TraceIdentifier}");
            return Problem(statusCode: 404, title: e.Message);
        }
        catch (Exception e) {
            _logger.LogError(e,
                $"Message: {e.Message} TraceId: {Activity.Current?.Id ?? HttpContext?.TraceIdentifier}");
            return Problem(statusCode: 500, title: "Something went wrong");
        }
    }
}