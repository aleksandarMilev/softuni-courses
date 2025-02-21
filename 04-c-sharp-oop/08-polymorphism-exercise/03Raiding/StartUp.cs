using Raiding.Core;
using Raiding.Core.Interfaces;
using Raiding.Factories;
namespace Raiding
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine(new HeroFactory());
            engine.Run();
        }
    }
}
