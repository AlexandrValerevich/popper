namespace Poppers.Application.Gif.Interfaces;

public interface IGifRemover
{
    Task RemoveAsync(Guid Id);
}