namespace Screenshots.Infrastructure.Extensions;

public static class ByteExtension
{
    public static string ToBase64String(this byte[] arr)
    {
        return Convert.ToBase64String(arr);
    }
}