namespace social_network_API.Models; 

public class Chat {
    public Guid Id { get; set; } = Guid.NewGuid();
    public ICollection<User> Members { get; set; }
    public ICollection<Message> Messages { get; set; }
}