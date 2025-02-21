using Vehicles.Core;
using Vehicles.Core.Interfaces;
using Vehicles.Factories;
namespace Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine(new VehicleFactory());
            engine.Run();
        }
    }
}
