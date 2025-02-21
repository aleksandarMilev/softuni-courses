namespace DateModifier
{
    public static class DateModifier
    {
        public static int GetDiffernce(string startDate, string endDate)
        {
            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);

            TimeSpan differenceInDays = start - end;
            return Math.Abs(differenceInDays.Days);
        }
    }
}
