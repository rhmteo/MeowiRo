namespace MeowiRo.Services
{
    public interface IClipboardService
    {
        ValueTask<string> ReadTextAsync();
        ValueTask WriteTextAsync(string text);
    }
}