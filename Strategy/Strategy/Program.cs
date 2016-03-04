using System;

namespace Strategy
{
    class Program
    {
        static void Main()
        {
            Context context = new Context(new ConcreteStrategy1());
            context.ContextInterface(); // Strategy.ConcreteStrategy1
            
            context = new Context(new ConcreteStrategy2());
            context.ContextInterface(); // Strategy.ConcreteStrategy2
        }
    }

    class Context
    {
        Strategy strategy;

        public Context(Strategy strategy)
        {
            this.strategy = strategy;
        }

        public void ContextInterface()
        {
            strategy.AlgoruthmInterface();
        }
    }

    abstract class Strategy
    {
        public abstract void AlgoruthmInterface();
    }

    class ConcreteStrategy1 : Strategy
    {
        public override void AlgoruthmInterface()
        {
            Console.WriteLine(GetType());
        }
    }

    class ConcreteStrategy2 : Strategy
    {
        public override void AlgoruthmInterface()
        {
            Console.WriteLine(GetType());
        }
    }


}
