using System.ComponentModel;

namespace social_network_API.Models.DTO; 

public class Response {
    [DisplayName("status")]public string Status { get; set; }
    [DisplayName("message")]public string Message { get; set; }
}