using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main()
        {
            Creator creator;
            Product product;

            creator = new ConcreteCreator();
            product = creator.FactoryMethod();

            creator.FactoryMethod();
        }
    }

    abstract class Creator
    {
        private Product product;
        public abstract Product FactoryMethod();

        public void AnOperation()
        {
            product = FactoryMethod();
        }
    }

    class ConcreteCreator : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProduct();
        }
    }

    abstract class Product
    {
        
    }

    class ConcreteProduct : Product
    {
        public ConcreteProduct()
        {
            Console.WriteLine(GetType());
            Console.WriteLine(GetHashCode());
        }
    }
}
