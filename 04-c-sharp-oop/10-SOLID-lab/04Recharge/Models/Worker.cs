﻿namespace Recharge.Models
{
    public abstract class Worker
    {
        private string id;
        private int workingHours;

        public Worker(string id)
        {
            this.id = id;
        }

        public abstract void Work();
    }
}