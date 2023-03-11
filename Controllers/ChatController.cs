using Microsoft.AspNetCore.Mvc;

namespace social_network_API.Controllers; 

/// <summary>
/// Controller for messaging
/// </summary>
public class ChatController : ControllerBase {
    private readonly ILogger<AccountController> _logger;
    
    public ChatController(ILogger<AccountController> logger) {
        _logger = logger;
    }
     
    
    
}