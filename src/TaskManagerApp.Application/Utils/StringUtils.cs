namespace TaskManagerApp.Application.Utils
{
    public static class StringUtils
    {
        public static string Repeat(this string str, int count)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return string.Concat(Enumerable.Repeat(str, count));
        }
    }
}
