namespace MeowiRo.Services
{
    public interface IConvertTimeService
    {
        DateTime ESTFormat { get; }
        DateTime GMT2Format { get; }
        DateTime GMT7Format { get; }
        DateTime GMT8Format { get; }
        DateTime PSTFormat { get; }
        DateTime UTCFormat { get; }

        void ConvertTimeFormat(DateTime dateTime, TimeFormat timeFormat);
    }
}