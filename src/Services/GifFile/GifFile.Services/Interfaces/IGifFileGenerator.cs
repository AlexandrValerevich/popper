using GifFile.Services.DTO;

namespace GifFile.Services.Interfaces;

public interface IGifFileGenerator
{
    Task<GifCreationResultDTO> Generate(IEnumerable<byte[]> images, int delay);
}