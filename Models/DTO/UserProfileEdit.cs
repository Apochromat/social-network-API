using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using social_network_API.Models.Enum;

namespace social_network_API.Models.DTO;

public class UserProfileEdit {
    [DisplayName("fullname")]
    [RegularExpression(@"^([A-ZА-ЯЁ][a-zа-яё]+[\s]?){2,3}$",
        ErrorMessage =
            "ФИО должно состоять из 2-3 слов, начинаться с заглавной буквы и содержать только латинские, кириллические символы, пробелы")]
    [MinLength(1)]
    [MaxLength(64)]
    public String FullName { get; set; }

    [DisplayName("gender")] public Gender Gender { get; set; }
    [DisplayName("birthdate")] public DateTime Birthdate { get; set; }
    [DisplayName("status")] public String Status { get; set; }
    [DisplayName("bio")] public String?Bio { get; set; }
    [DisplayName("profileImage")] public String ProfileImage { get; set; }
    [DisplayName("backgroundImage")] public String BackgroundImage { get; set; }
    [DisplayName("discord")] public String Discord { get; set; }
    [DisplayName("telegram")] public String Telegram { get; set; }
}