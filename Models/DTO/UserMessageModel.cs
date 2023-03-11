namespace social_network_API.Models.DTO; 

/// <summary>
/// User short model for message
/// </summary>
public class UserMessageModel {
    /// <summary>
    /// Users id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Users fullname (name, surname, patronymic)
    /// </summary>
    public string? FullName { get; set; }
    /// <summary>
    /// Users avatar link
    /// </summary>
    public String? ProfileImage { get; set; }
}