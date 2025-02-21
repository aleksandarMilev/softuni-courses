namespace DateModifier
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string startDay = Console.ReadLine();
            string endDate = Console.ReadLine();

            int difference = DateModifier.GetDiffernce(startDay, endDate);
            Console.WriteLine(difference);
        }
    }
}