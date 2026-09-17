using Microsoft.AspNetCore.Identity;

namespace Flowly.Infrastructure.Models.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public string? DisplayName { get; set; }
    public string? Bio { get; set; }
    public string? AvatarUrl { get; set; }
    public string? Location { get; set; }
    public string? Website { get; set; }
    public string? GitHub { get; set; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}
