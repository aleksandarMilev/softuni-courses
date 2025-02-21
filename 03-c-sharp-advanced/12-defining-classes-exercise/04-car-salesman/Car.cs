using System.Text;

namespace CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;


        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }
        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }


        public string Model { get; set; } 
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }


        public string PrintCar()
        {
            StringBuilder sb = new();

            sb.AppendLine($"{Model}:");
            sb.AppendLine($" {Engine.Model}:");
            sb.AppendLine($"  Power: {Engine.Power}");
            string displacement = Engine.Displacement != -1 ? Engine.Displacement.ToString() : "n/a";
            sb.AppendLine($"  Displacement: {displacement}");
            sb.AppendLine($"  Efficiency: {Engine.Efficiency}");
            string weight = Weight != -1 ? Weight.ToString() : "n/a";
            sb.AppendLine($" Weight: {weight}");
            sb.AppendLine($" Color: {Color}");

            return sb.ToString();
        }
    }
}
