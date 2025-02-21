namespace _01Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffect = new(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> bombCasing = new(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int daturaBombs = 0;
            int cherryBombs = 0;
            int smokeDecoyBombs = 0;
            bool success = false;

            while (bombEffect.Any() && bombCasing.Any())
            {
                int result = bombEffect.Peek() + bombCasing.Peek();
                if (result == 40 || result == 60 || result == 120)
                {
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                    CheckForCorrectResult(ref daturaBombs, ref cherryBombs, ref smokeDecoyBombs, result);
                }
                else
                {
                    while (result != 40 && result != 60 && result != 120)
                    {
                        bombCasing.Push(bombCasing.Pop() - 5);
                        result = bombEffect.Peek() + bombCasing.Peek();

                        CheckForCorrectResult(ref daturaBombs, ref cherryBombs, ref smokeDecoyBombs, result);
                    }

                    bombEffect.Dequeue();
                    bombCasing.Pop();
                }

                if (daturaBombs >= 3 && cherryBombs >= 3 && smokeDecoyBombs >= 3)
                {
                    success = true;
                    break;
                }
            }

            if (success)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffect.Any())
            {
                string effectResult = "";

                Console.Write("Bomb Effects: ");
                while (bombEffect.Any())
                {
                    effectResult += $"{bombEffect.Dequeue()}, ";
                }

                Console.WriteLine(effectResult.TrimEnd(',', ' '));
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasing.Any())
            {
                string casingResult = "";

                Console.Write("Bomb Casings: ");
                while (bombCasing.Any())
                {
                    casingResult += $"{bombCasing.Pop()}, ";
                }

                Console.WriteLine(casingResult.TrimEnd(',', ' '));
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            Console.WriteLine($"Cherry Bombs: {cherryBombs}");
            Console.WriteLine($"Datura Bombs: {daturaBombs}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyBombs}");
        }

        private static void CheckForCorrectResult(ref int daturaBombs, ref int cherryBombs, ref int smokeDecoyBombs, int result)
        {
            if (result == 40)
            {
                daturaBombs++;
            }
            else if (result == 60)
            {
                cherryBombs++;
            }
            else if (result == 120)
            {
                smokeDecoyBombs++;
            }
        }
    }
}
