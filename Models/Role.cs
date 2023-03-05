using Microsoft.AspNetCore.Identity;
using social_network_API.Models.Enum;

namespace social_network_API.Models; 

public class Role : IdentityRole<Guid> {
    public RoleType Type { get; set; }
    public ICollection<UserRole> Users { get; set; }
}