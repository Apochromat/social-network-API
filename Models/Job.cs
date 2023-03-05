namespace social_network_API.Models; 

public class Job {
    public Guid Id  { get; set; } = Guid.NewGuid();
    public String? Name { get; set; }
    public Location? Location  { get; set; }
    public String? Post { get; set; }
    public DateTime StartDate  { get; set; }
}