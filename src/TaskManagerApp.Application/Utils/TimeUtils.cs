namespace TaskManagerApp.Application.Utils
{
    public static class TimeUtils
    {
        public static readonly int DAY_SECONDS = 86400;

        /// <summary>
        /// Converts a "hh:mm" string to a short value
        /// </summary>
        /// <param name="time"></param>
        /// <returns>The short value as a number, "09:30" converts to 930</returns>
        public static short ConvertTimeToShort(string? time)
        {
            if (string.IsNullOrEmpty(time))
                return 0;

            var timeParts = time.Split(':');

            if (timeParts.Length != 2)
                return 0;

            return (short)((Convert.ToInt16(timeParts[0]) * 100) + Convert.ToInt16(timeParts[1]));
        }

        /// <summary>
        /// Converts a short to a "hh:mm" string
        /// </summary>
        /// <param name="time"></param>
        /// <returns>The short value as a number, 930 converts to "09:30"</returns>
        public static string ConvertShortToTime(short? shortTime)
        {
            if (!(shortTime > 0) || shortTime > 9999)
                return string.Empty;

            var time = ((short)shortTime).ToString();

            if (time.Length > 2)
                time = time.Insert(time.Length - 2, ":");

            while (time.Length < 5)
            {
                if (!time.Contains(':'))
                    time = $":{"0".Repeat(2 - time.Length)}{time}";

                time = $"0{time}";
            }
            return time;
        }
    }
}
