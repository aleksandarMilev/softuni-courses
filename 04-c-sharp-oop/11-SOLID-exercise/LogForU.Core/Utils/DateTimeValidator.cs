﻿using System;
using System.Collections.Generic;
using System.Globalization;
namespace LogForU.Core.Utils
{
    public static class DateTimeValidator
    {
        private static readonly ISet<string> formats = new HashSet<string>() { "M/d/yyyy h:mm:ss tt" };

        public static void AddFormat(string format) => formats.Add(format);

        internal static bool ValidateDateTime(string dateTime)
        {
            foreach (string format in formats)
            {
                if (DateTime.TryParseExact(dateTime, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
