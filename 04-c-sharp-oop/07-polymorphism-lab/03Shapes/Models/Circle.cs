﻿using System;
namespace Shapes.Models
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get => radius;
            private set => radius = value;
        }

        public override double CalculateArea()
            => Math.PI * Radius * Radius;

        public override double CalculatePerimeter()
            => 2 * Math.PI * Radius;
    }
}
