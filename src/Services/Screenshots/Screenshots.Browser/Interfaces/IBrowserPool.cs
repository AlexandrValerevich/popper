namespace Screenshots.Browser.Interfaces;

internal interface IBrowserPool
{
    IBrowser Get();
    void Return(IBrowser browser);
}