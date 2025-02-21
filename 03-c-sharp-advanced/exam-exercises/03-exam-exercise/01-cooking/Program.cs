namespace _01Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> ingredients = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int breadCount = 0;
            int cakeCount = 0;
            int fruitPieCount = 0;
            int pastryCount = 0;
            while (liquids.Any() && ingredients.Any())
            {
                int sum = 0;
                while (sum != 25 && sum != 50 && sum != 75 && sum != 100)
                {
                    if (!liquids.Any() || !ingredients.Any())
                    {
                        break;
                    }

                    int liquid = liquids.Dequeue();
                    int ingredient = ingredients.Pop();

                    sum = liquid + ingredient;
                    if (sum == 25)
                    {
                        breadCount++;
                    }
                    else if (sum == 50)
                    {
                        cakeCount++;
                    }
                    else if (sum == 75)
                    {
                        pastryCount++;
                    }
                    else if (sum == 100)
                    {
                        fruitPieCount++;
                    }
                    else
                    {
                        ingredients.Push(ingredient + 3);
                    }
                }
            }

            if (breadCount != 0 && cakeCount != 0 && fruitPieCount != 0 && pastryCount != 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (!liquids.Any())
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                string liquidsLeft = "";
                foreach (int liquid in liquids)
                {
                    liquidsLeft += $"{liquid}, ";
                }
                Console.WriteLine($"Liquids left: {liquidsLeft.TrimEnd(',', ' ')}");
            }

            if (!ingredients.Any())
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                string ingredientsLeft = "";
                foreach (int ingredient in ingredients)
                {
                    ingredientsLeft += $"{ingredient}, ";
                }
                Console.WriteLine($"Ingredients left: {ingredientsLeft.TrimEnd(',', ' ')}");
            }

            Console.WriteLine($"Bread: {breadCount}");
            Console.WriteLine($"Cake: {cakeCount}");
            Console.WriteLine($"Fruit Pie: {fruitPieCount}");
            Console.WriteLine($"Pastry: {pastryCount}");
        }
    }
}
