namespace social_network_API.Models; 

public class Location {
    public Guid Id  { get; set; } = Guid.NewGuid();
    public String? Country { get; set; }
    public String? State { get; set; }
    public String? Town { get; set; }
}