
using System.Globalization;

namespace LegacyCode_Kab
{
    public class DateUtil : IDateUtil
    {
        private const string DdMmYyyyFormat = "dd'/'MM'/'yyyy";
        private const string MmDdYyyyFormat = "MM'/'dd'/'yyyy";
        private static readonly CultureInfo Invariant = CultureInfo.InvariantCulture;
        private const int MinYear = 1900;
        private const int MaxYear = 2100;

        public bool TryParseDdMmYyyy(string input, out DateTime date)
        {
            return TryParseExact(input, DdMmYyyyFormat, out date);
        }

        public bool TryParseMmDdYyyy(string input, out DateTime date)
        {
            return TryParseExact(input, MmDdYyyyFormat, out date);
        }

        private bool TryParseExact(string input, string format, out DateTime date)
        {
            date = default;
            if (string.IsNullOrWhiteSpace(input)) return false;

            // TryParseExact уже проверит формат и значения (включая корректность дня/месяца)
            if (!DateTime.TryParseExact(input, format, Invariant, DateTimeStyles.None, out date))
                return false;

            if (date.Year < MinYear || date.Year > MaxYear)
                return false;

            return true;
        }

        public bool TryConvert(string input, DateFormat source, out string result)
        {
            result = null;
            if (source == DateFormat.DdMmYyyy)
            {
                if (!TryParseDdMmYyyy(input, out var dt)) return false;
                result = dt.ToString(MmDdYyyyFormat, Invariant);
                return true;
            }
            else // MmDdYyyy
            {
                if (!TryParseMmDdYyyy(input, out var dt)) return false;
                result = dt.ToString(DdMmYyyyFormat, Invariant);
                return true;
            }
        }

        public bool TryGetDayOfWeek(string input, out DayOfWeek dayOfWeek)
        {
            dayOfWeek = default;
            if (!TryParseDdMmYyyy(input, out var dt)) return false;
            dayOfWeek = dt.DayOfWeek;
            return true;
        }

        public bool TryGetDaysDifference(string d1, string d2, out int days)
        {
            days = 0;
            if (!TryParseDdMmYyyy(d1, out var dt1) || !TryParseDdMmYyyy(d2, out var dt2)) return false;
            days = Math.Abs((dt2 - dt1).Days);
            return true;
        }

        public bool TryAddDays(string input, int n, out string result)
        {
            result = null;
            if (!TryParseDdMmYyyy(input, out var dt)) return false;
            var newDt = dt.AddDays(n);
            if (newDt.Year < MinYear || newDt.Year > MaxYear) return false;
            result = newDt.ToString(DdMmYyyyFormat, Invariant);
            return true;
        }

        public bool IsLeapYear(int year)
        {
            return DateTime.IsLeapYear(year);
        }
    }
}

