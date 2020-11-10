using System;
using System.ComponentModel.DataAnnotations;

namespace CS.Impl._04_Advanced
{
    public abstract class Shape
    {
        public abstract double GetArea();

        public abstract double GetPerimeter();

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }

    public class Circle : Shape
    {
        private double radius;
        private double pi;
        public Circle(double radius)
        {
            this.radius = radius;
            this.pi = Math.PI;
        }

        public override double GetArea()
        {
            return Math.Floor(this.pi * (Math.Pow(this.radius,2))); 
        }

        public override double GetPerimeter()
        {
            return Math.Floor(2.0 * 3.14 * this.radius);
        }
    }

    public class Rectangle : Shape
    {
        private double length;
        private double width;

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        public override double GetArea()
        {
            return this.length * this.width;
        }

        public override double GetPerimeter()
        {
            return this.length * 2 + this.width * 2;
        }
    }

    public class Square : Shape
    {
        private double sideLength;
        public Square(double sideLength)
        {
            this.sideLength = sideLength;
        }

        public override double GetArea()
        {
            return Math.Pow(this.sideLength, 2);
        }

        public override double GetPerimeter()
        {
            return this.sideLength * 4;
        }
    }
}