using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCode_Kab
{
    public interface Utils
    {
        /// <summary>
        /// Интерфейс для утилит работы с датами.
        /// </summary>
        public interface IDateUtil
        {
            bool TryParseDdMmYyyy(string input, out DateTime date);
            bool TryParseMmDdYyyy(string input, out DateTime date);

            /// <summary>
            /// Конвертирует дату из одного формата в другой.
            /// Возвращает true и out result при успехе.
            /// </summary>
            bool TryConvert(string input, DateFormat source, out string result);

            bool TryGetDayOfWeek(string input, out DayOfWeek dayOfWeek);
            bool TryGetDaysDifference(string d1, string d2, out int days);
            bool TryAddDays(string input, int n, out string result);
            bool IsLeapYear(int year);
        }

        public enum DateFormat
        {
            DdMmYyyy,
            MmDdYyyy
        }
    }
}
