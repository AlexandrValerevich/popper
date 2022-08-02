namespace Screenshots.Application.DTO;

public class ScreenshotsListDTO
{
    public IEnumerable<byte[]> Screenshots { get; set; } = new List<byte[]>();
}