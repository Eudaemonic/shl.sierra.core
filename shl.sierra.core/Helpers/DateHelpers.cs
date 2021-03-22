using System;
using System.Text;

namespace shl.sierra.core.Helpers
{
    public static class DateHelpers
    {
        public static string FormatSierraDateRange(DateTime startDate, DateTime endDate)
        {

            var sb = new StringBuilder();
            if (endDate != default)
            {
                sb.Append("[");
                sb.Append(startDate.ToString("s"));
                sb.Append(",");
                sb.Append(endDate.ToString("s"));
                sb.Append("]");
                return sb.ToString();
            }
            return startDate.ToString("s");
        }
    }
}
