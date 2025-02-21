namespace _01Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> threads = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int valueKill = int.Parse(Console.ReadLine());

            while (tasks.Any() && threads.Any())
            {
                int thread = threads.Peek();
                int task = tasks.Peek();

                if (task == valueKill)
                {
                    Console.WriteLine($"Thread with value {thread} killed task {task}");
                    break;
                }

                if (thread >= task)
                {
                    tasks.Pop();
                }
                
                threads.Dequeue();
            }

            if (threads.Any())
            {
                Console.WriteLine(string.Join(" ", threads));
            }
        }
    }
}
