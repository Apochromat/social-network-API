using Microsoft.AspNetCore.Identity;
using social_network_API.Models.Enum;

namespace social_network_API.Models;

public class User : IdentityUser<Guid> {
    public String FullName { get; set; }
    public Gender Gender { get; set; }
    public DateTime Birthdate { get; set; }
    public DateTime JoinDate { get; set; } = DateTime.Now;
    public Location? Location { get; set; }
    public Job? Job { get; set; }
    public String? Status { get; set; }
    public String? Bio { get; set; }
    public String? ProfileImage { get; set; }
    public String? BackgroundImage { get; set; }
    public String? Discord { get; set; }
    public String? Telegram { get; set; }
    public ICollection<UserRole> Roles { get; set; }
}