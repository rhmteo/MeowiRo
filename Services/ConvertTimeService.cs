using TimeZoneConverter;

namespace MeowiRo.Services
{
    public enum TimeFormat { PST, EST, GMT2, UTC, GMT7, GMT8 }

    public class ConvertTimeService : IConvertTimeService
    {

        public DateTime PSTFormat { get; private set; }
        public DateTime ESTFormat { get; private set; }
        public DateTime GMT2Format { get; private set; }
        public DateTime UTCFormat { get; private set; }
        public DateTime GMT7Format { get; private set; }
        public DateTime GMT8Format { get; private set; }
        public void ConvertTimeFormat(DateTime dateTime, TimeFormat timeFormat)
        {
            UTCFormat = TimeZoneInfo.ConvertTimeToUtc(dateTime, FindTimeZone(timeFormat));
            PSTFormat = TimeZoneInfo.ConvertTimeFromUtc(UTCFormat, FindTimeZone(TimeFormat.PST));
            ESTFormat = TimeZoneInfo.ConvertTimeFromUtc(UTCFormat, FindTimeZone(TimeFormat.EST));
            GMT2Format = TimeZoneInfo.ConvertTimeFromUtc(UTCFormat, FindTimeZone(TimeFormat.GMT2));
            GMT7Format = TimeZoneInfo.ConvertTimeFromUtc(UTCFormat, FindTimeZone(TimeFormat.GMT7));
            GMT8Format = TimeZoneInfo.ConvertTimeFromUtc(UTCFormat, FindTimeZone(TimeFormat.GMT8));
        }
        private TimeZoneInfo FindTimeZone(TimeFormat timezone)
        {
            string format = "";
            if (timezone == TimeFormat.PST)
            {
                format = "Pacific Standard Time";
            }
            else if (timezone == TimeFormat.EST)
            {
                format = "Eastern Standard Time";
            }
            else if (timezone == TimeFormat.GMT2)
            {
                format = "E. Europe Standard Time";

            }
            else if (timezone == TimeFormat.GMT7)
            {
                format = "SE Asia Standard Time";
            }
            else if (timezone == TimeFormat.GMT8)
            {
                format = "Singapore Standard Time";
            }
            TimeZoneInfo tzi = TZConvert.GetTimeZoneInfo(format);
            return tzi;
        }

    }

}
