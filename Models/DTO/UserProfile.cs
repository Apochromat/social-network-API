using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using social_network_API.Models.Enum;

namespace social_network_API.Models.DTO;

/// <summary>
/// Users profile DTO
/// </summary>
public class UserProfile {
    /// <summary>
    /// Users fullname (surname, name, patronymic)
    /// </summary>
    [DisplayName("fullname")]
    [RegularExpression(@"^([A-ZА-ЯЁ][a-zа-яё]+[\s]?){2,3}$",
        ErrorMessage =
            "ФИО должно состоять из 2-3 слов, начинаться с заглавной буквы и содержать только латинские, кириллические символы, пробелы")]
    [MinLength(1)]
    [MaxLength(64)]
    public String? FullName { get; set; }
    
    /// <summary>
    /// Users valid email
    /// </summary>
    [DisplayName("email")] [EmailAddress] public String? Email { get; set; }
    /// <summary>
    /// Users phone number
    /// </summary>
    [DisplayName("phone")] [Phone] public String? PhoneNumber { get; set; }
    /// <summary>
    /// Users birthdate
    /// </summary>
    [DisplayName("birthdate")] public DateTime? Birthdate { get; set; }
    /// <summary>
    /// Users location (country, state, town)
    /// </summary>
    [DisplayName("location")] public Location? Location { get; set; }
    /// <summary>
    /// Users job (location, post, start date)
    /// </summary>
    [DisplayName("job")] public Job? Job { get; set; }
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