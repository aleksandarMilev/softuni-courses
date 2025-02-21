using Recharge.Models;
namespace Recharge
{
    public class Robot : Worker, IRechargeable
    {
        private int capacity;
        private int currentPower;

        public Robot(string id, int capacity)
            : base(id)
        {
            Capacity = capacity;
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set { this.capacity = value; }
        }

        public int CurrentPower
        {
            get { return this.currentPower; }
            private set { this.currentPower = value; }
        }

        public void Recharge()
            => CurrentPower = Capacity;

        public override void Work()
        {
            // work ...
        }
    }
}