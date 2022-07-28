namespace Poppers.Infrastructure.Browser.Interfaces;

public interface IBrowserPool
{
    IBrowser Get();
    void Return(IBrowser browser);
}