using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace social_network_API.Models.DTO; 

/// <summary>
/// Login Credentials DTO
/// </summary>
public class LoginCredentials {
    /// <summary>
    /// Users Email
    /// </summary>
    [Required]
    [EmailAddress]
    [DisplayName("email")]
    public String? Email { get; set; }
    
    /// <summary>
    /// Users Password. Must Contain at least one non alphanumeric character, at least one digit ('0'-'9'),
    /// at least one uppercase ('A'-'Z')
    /// </summary>
    [Required]
    [RegularExpression(@"^[a-zA-Z0-9\-_!@#№$%^&?*+=(){}[\]<>~]+$")]
    [MinLength(8)]
    [MaxLength(64)]
    [DisplayName("password")]
    public String? Password { get; set; }
}