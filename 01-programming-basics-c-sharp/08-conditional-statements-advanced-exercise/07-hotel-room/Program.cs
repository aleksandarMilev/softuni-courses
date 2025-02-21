using System;
namespace _07HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            double nights = days;
            double studio = 0.0;
            double apartment = 0.0;
            if (month == "May" || month == "October")
            {
                studio = nights * 50.00;
                apartment = nights * 65;
                if (nights > 7 && nights < 14)
                {
                    studio = studio - (studio * 0.05);
                }
                else if (nights > 14)
                {
                    studio = studio - (studio * 0.30);
                    apartment = apartment - (apartment * 0.10);
                }
            }
            else if (month == "June" || month == "September")
            {
                studio = nights * 75.20;
                apartment = nights * 68.70;
                if (nights > 14)
                {
                    studio = studio - (studio * 0.20);
                    apartment = apartment - (apartment * 0.10);
                }
            }
            else if (month == "July" || month == "August")
            {
                studio = nights * 76;
                apartment = nights * 77;
                if (nights > 14)
                {
                    apartment = apartment - (apartment * 0.10);
                }
            }
            Console.WriteLine($"Apartment: {apartment:F2} lv.");
            Console.WriteLine($"Studio: {studio:F2} lv.");
        }
    }
}