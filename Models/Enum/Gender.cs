using System.ComponentModel.DataAnnotations;
namespace social_network_API.Models.Enum; 

public enum Gender {
    [Display(Name = GenderNames.Female)]
    Female,
    [Display(Name = GenderNames.Male)]
    Male
}

public class GenderNames {
    public const string Female = "Female";
    public const string Male = "Male";
}