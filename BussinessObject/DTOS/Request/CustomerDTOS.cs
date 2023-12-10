namespace BussinessObject.DTOS;

public class CustomerDTOS
{        
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? City { get; set; }
    public string? Country { get; set; }
}