namespace Poppers.Browser.Interfaces;

internal interface IBrowserPool
{
    IBrowser Get();
    void Return(IBrowser browser);
}