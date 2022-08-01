namespace GifFile.Services.DTO;

public record GifCreationResultDTO
{
    public Stream FileStream { get; init; }
}