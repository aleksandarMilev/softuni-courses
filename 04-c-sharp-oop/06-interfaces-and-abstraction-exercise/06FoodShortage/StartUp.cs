using FoodShortage.Core;
using FoodShortage.Core.Interfaces;
namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
