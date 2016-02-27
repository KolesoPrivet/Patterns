using System;

namespace Prototype
{
    class Program
    {
        static void Main()
        {
            Prototype prototype;
            Prototype clone;

            prototype = new ConcretePrototype(1);
            clone = prototype.Clone();
            Console.WriteLine("{0} {1}\n{2} {3}",
                prototype.GetHashCode(), clone.GetHashCode(), 
                prototype.GetType(), clone.GetType());
        }
    }

    class CLient
    {
        
    }

    abstract class Prototype
    {
        public int Id { get; set; }

        protected Prototype(int id)
        {
            Id = id;
        }
        public abstract Prototype Clone();
    }

    class ConcretePrototype : Prototype
    {
        public ConcretePrototype(int id) : base(id) { }
        public override Prototype Clone()
        {
            return new ConcretePrototype(Id);
        }
    }
}
