namespace GifFiles.Application.Interfaces;

public interface IGifRemover
{
    Task RemoveById(Guid id);
}