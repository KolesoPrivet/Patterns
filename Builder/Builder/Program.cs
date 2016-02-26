using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Builder
{
    class Program
    {
        static void Main()
        {
            Builder builder = new ConcreteBuilder();
            Director director = new Director(builder);

            director.Construct();

            House house = builder.GetResults();
        }
    }

    class Director
    {
        Builder builder;

        public Director(Builder builder)
        {
            this.builder = builder;
        }

        public void Construct()
        {
            builder.BuildBasement();
            builder.BuildRoof();
        }
    }

    class ConcreteBuilder : Builder
    {
        House house = new House();

        public override void BuildBasement()
        {
            house.Add(new Basement());
        }

        public override void BuildRoof()
        {
            house.Add(new Roof());
        }

        public override House GetResults()
        {
            return house;
        }
    }

    abstract class Builder
    {
        public abstract void BuildBasement();
        public abstract void BuildRoof();
        public abstract House GetResults();
    }

    class House
    {
        ArrayList parts = new ArrayList();

        public void Add(object part)
        {
            parts.Add(part);
        }
    }

    class Basement
    {
        public Basement()
        {
            Console.WriteLine("Фундамент построен");
        }
    }

    class Roof
    {
        public Roof()
        {
            Console.WriteLine("Крыша построена");
        }
    }
}
