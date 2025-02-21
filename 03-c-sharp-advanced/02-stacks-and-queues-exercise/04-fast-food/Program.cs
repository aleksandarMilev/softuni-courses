namespace _04FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            Queue<int> orders = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Console.WriteLine(orders.Max());

            bool foodOver = false;
            while (orders.Any())
            {
                if (foodQuantity - orders.Peek() >= 0)
                {
                    foodQuantity -= orders.Dequeue();
                }
                else
                {
                    foodOver = true;
                    break;
                }
            }

            if (foodOver)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}