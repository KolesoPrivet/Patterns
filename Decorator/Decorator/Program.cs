using System;

namespace Decorator
{
    class Program
    {
        static void Main()
        {
            Component carlson = new Carlson();
            Decorator propeller = new Propeller();
            Decorator shoes = new Shoes();

            shoes.Component = carlson;
            propeller.Component = shoes;

            propeller.Operation();
        }
    }

    abstract class Component
    {
        public abstract void Operation();
    }

    class Carlson : Component
    {
        public override void Operation()
        {
            Console.WriteLine("Карлсон");
        }
    }

    abstract class Decorator : Component
    {
        public Component Component { get; set; }

        public override void Operation()
        {
            if(Component != null)
                Component.Operation();
        }
    }

    class Propeller : Decorator
    {
        string state = "летит";

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine(state);
        }
    }

    class Shoes : Decorator
    {
        string state = "в костюме";

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine(state);
        }
    }
}
