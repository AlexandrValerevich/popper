namespace Shared.Poppers.Contracts.V1.Authentication.Requests;

public record LoginRequest(string Email,
    string Password,
    string DeviceId);