using social_network_API.Models.DTO;

namespace social_network_API.Models; 

public class Message {
    public Guid Id { get; set; } = Guid.NewGuid();
    public User Author { get; set; }
    public DateTime CreatedAt { get; set; }
    public Boolean IsRead { get; set; }
    public Boolean IsImportant { get; set; }
    public String Text { get; set; }
}