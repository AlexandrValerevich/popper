namespace Poppers.Application.Common.Models;

public record RefreshToken
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Created { get; set; }
    public DateTime Expire { get; set; }
    public string CreateByIp { get; set; }
}