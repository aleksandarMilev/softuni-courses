using System.Text.RegularExpressions;
namespace _02DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"(\=[A-Z][A-Za-z]{2,}\=)|(\/[A-Z][A-Za-z]{2,}\/)";
            int travelPoints = 0;
            List<string> destinations = new();

            MatchCollection matchCollection = Regex.Matches(text, pattern);
            foreach (Match match in matchCollection)
            {
                var str = match.Value.Where(ch => char.IsLetter(ch));
                string destination = new string(str.ToArray());
                destinations.Add(destination);
                travelPoints += destination.Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}