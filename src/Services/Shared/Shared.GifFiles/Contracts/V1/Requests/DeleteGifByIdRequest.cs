namespace Shared.GifFiles.Contracts.V1.Requests;

public record DeleteGifByIdRequest(
    Guid GifId,
    Guid UserId
);