namespace _05FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int capacity = int.Parse(Console.ReadLine());

            int racks = 1;
            int sum = 0;
            while (clothes.Any())
            {
                if (sum + clothes.Peek() < capacity)
                {
                    sum += clothes.Pop();
                }
                else if (sum + clothes.Peek() == capacity)
                {
                    sum += clothes.Pop();
                    if (clothes.Any())
                    {
                        racks++;
                        sum = 0;
                    }
                }
                else
                {
                    racks++;
                    sum = 0;
                }
            }

            Console.WriteLine(racks);
        }
    }
}