using System.ComponentModel.DataAnnotations;

namespace social_network_API.Models.Enum; 

public enum RoleType {
    [Display(Name = ApplicationRoleNames.Administrator)]
    Administrator,
    [Display(Name = ApplicationRoleNames.Moderator)]
    Moderator,
    [Display(Name = ApplicationRoleNames.User)]
    User
}

public class ApplicationRoleNames {
    public const string Administrator = "Administrator";
    public const string Moderator = "Moderator";
    public const string User = "User";
}