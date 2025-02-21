using WildFarm.Core;
using WildFarm.Core.Interfaces;
using WildFarm.Factories;
namespace WildFarm
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine(new FoodFactory(), new AnimalFactory());
            engine.Run();
        }
    }
}
