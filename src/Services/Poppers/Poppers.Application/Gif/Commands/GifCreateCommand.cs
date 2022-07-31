using MediatR;
using Poppers.Application.Gif.Common;

namespace Poppers.Application.Gif.Commands;

public class GifCreateCommand : IRequest<GifFile>
{
    public int Duration { get; set; }
    public string ElementSelector { get; set; }
    public string Uri { get; set; }
}