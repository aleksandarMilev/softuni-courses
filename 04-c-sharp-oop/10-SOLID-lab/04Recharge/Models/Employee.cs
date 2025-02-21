using Recharge.Models;
using System;
namespace Recharge
{
    public class Employee : Worker, ISleeper
    {
        public Employee(string id) : base(id)
        {
        }

        public void Sleep()
        {
            // sleep...
        }

        public override void Work()
        {
            // work...
        }
    }
}
