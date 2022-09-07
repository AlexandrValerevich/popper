namespace Shared.GifFiles.Contracts.V1.Requests;

public record GetGifByIdRequest(
    Guid GifId,
    Guid UserId
);
