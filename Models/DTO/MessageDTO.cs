namespace social_network_API.Models.DTO; 

public class MessageDTO {
    public Guid Id { get; set; }
    public UserMessageModel Author { get; set; }
    public DateTime CreatedAt { get; set; }
    public Boolean IsRead { get; set; }
    public Boolean IsImportant { get; set; }
    public String Text { get; set; }
}