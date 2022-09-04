namespace Poppers.Application.Common.Models;

public record RefreshToken
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Created { get; set; }
    public DateTime Expire { get; set; }
    public string CreateByIp { get; set; }
    public string DeviceId { get; set; }
    public bool IsRevoked { get; set; }

    public bool IsExpired => DateTime.Now > Expire;
    public bool IsActive => !(IsExpired || IsRevoked);
}