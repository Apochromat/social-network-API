using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using social_network_API.Models.Enum;

namespace social_network_API.Models.DTO;

/// <summary>
/// Users profile edit DTO
/// </summary>
public class UserProfileEdit {
    /// <summary>
    /// Users fullname (surname, name, patronymic)
    /// </summary>
    [DisplayName("fullname")]
    [RegularExpression(@"^([A-ZА-ЯЁ][a-zа-яё]+[\s]?){2,3}$",
        ErrorMessage =
            "The full name should consist of 2-3 words, start with a capital letter and contain only Latin, Cyrillic characters, spaces")]
    [MinLength(1)]
    [MaxLength(64)]
    public String? FullName { get; set; }
    /// <summary>
    /// Users birthdate
    /// </summary>
    [DisplayName("birthdate")] public DateTime Birthdate { get; set; }
    /// <summary>
    /// User account status
    /// </summary>
    [DisplayName("status")] public String? Status { get; set; }
    /// <summary>
    /// Information about user
    /// </summary>
    [DisplayName("bio")] public String? Bio { get; set; }
    /// <summary>
    /// Users avatar link
    /// </summary>
    [DisplayName("profileImage")] public String? ProfileImage { get; set; }
    /// <summary>
    /// Users background image link 
    /// </summary>
    [DisplayName("backgroundImage")] public String? BackgroundImage { get; set; }
    /// <summary>
    /// Users Discord nickname
    /// </summary>
    [DisplayName("discord")] public String? Discord { get; set; }
    /// <summary>
    /// Users Telegram nickname
    /// </summary>
    [DisplayName("telegram")] public String? Telegram { get; set; }
}