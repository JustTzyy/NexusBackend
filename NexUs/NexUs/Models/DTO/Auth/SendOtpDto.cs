using System.ComponentModel.DataAnnotations;

namespace NexUs.Models.DTO.Auth;

public class SendOtpDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}
