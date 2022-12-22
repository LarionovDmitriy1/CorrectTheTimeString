using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CorrectTheTimeString;

public class DateTimeCorrect
{
    public static string CorrectTheTime(string date)
    {
        if (String.IsNullOrEmpty(date) || date == " " || date.Length == 0) { return date; }
        Regex regex = new Regex(@"^\d{2}:\d{2}:\d{2}$");
        if (regex.IsMatch(date))
        {
            string[] words = date.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            bool isHour = int.TryParse(words[0], out var hour);
            bool isMinute = int.TryParse(words[1], out var minute);
            bool isSecond = int.TryParse(words[2], out var second);
            TimeSpan dateTime = new TimeSpan(hour, minute, second);
            var a = dateTime.ToString();
            string[] words2 = a.Split(new char[] { ':', '.' }, StringSplitOptions.RemoveEmptyEntries);
            bool isParse = int.TryParse(words2[words2.Length - 1], out var second2);
            bool isParse1 = int.TryParse(words2[words2.Length - 2], out var minute2);
            bool isParse2 = int.TryParse(words2[words2.Length - 3], out var hour2);
            DateTime result = new(2015, 7, 20, hour2, minute2, second2);
            date = result.ToLongTimeString();
            return date;
        }
        return null;
    }
}
