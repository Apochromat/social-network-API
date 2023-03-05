using System.ComponentModel;

namespace social_network_API.Models.DTO; 

public class TokenResponse {
    [DisplayName("token")] public string? Token { get; set; }
    [DisplayName("name")] public string? Email { get; set; }
    [DisplayName("roles")] public IList<string>? Roles { get; set; }
}