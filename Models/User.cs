using Microsoft.AspNetCore.Identity;

namespace social_network_API.Models;

/// <summary>
/// User DB model
/// </summary>
public class User : IdentityUser<Guid> {
    /// <summary>
    /// Users fullname (name, surname, patronymic)
    /// </summary>
    public string? FullName { get; set; }
    /// <summary>
    /// Users birthday
    /// </summary>
    public DateTime Birthdate { get; set; }
    /// <summary>
    /// Users register date
    /// </summary>
    public DateTime JoinDate { get; set; } = DateTime.Now;
    /// <summary>
    /// Users location (country, state, town)
    /// </summary>
    public Location? Location { get; set; }
    /// <summary>
    /// Users job (address, post, start date)
    /// </summary>
    public Job? Job { get; set; }
    /// <summary>
    /// User account status
    /// </summary>
    public String? Status { get; set; }
    /// <summary>
    /// Information about user
    /// </summary>
    public String? Bio { get; set; }
    /// <summary>
    /// Users avatar link
    /// </summary>
    public String? ProfileImage { get; set; }
    /// <summary>
    /// Users background image link 
    /// </summary>
    public String? BackgroundImage { get; set; }
    /// <summary>
    /// Users Discord nickname
    /// </summary>
    public String? Discord { get; set; }
    /// <summary>
    /// Users Telegram nickname
    /// </summary>
    public String? Telegram { get; set; }
    /// <summary>
    /// List of users roles
    /// </summary>
    public ICollection<UserRole>? Roles { get; set; }
    /// <summary>
    /// List of users chats
    /// </summary>
    public ICollection<Chat>? Chats { get; set; }
}