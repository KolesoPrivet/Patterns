using System;

namespace Chain_of_responsibility
{
    class Program
    {
        static void Main()
        {
            Handler conHandler1 = new ConcreteHandler1();
            Handler conHandler2 = new ConcreteHandler2();

            conHandler1.Succesor = conHandler2;
            conHandler1.HandleRequest(3);
        }
    }

    abstract class Handler
    {
        public Handler Succesor { get; set; }
        public abstract void HandleRequest(int request);
    }

    class ConcreteHandler1 : Handler
    {
        public override void HandleRequest(int request)
        {
            if(request == 1)
                Console.WriteLine("One");
            else if(Succesor != null)
                Succesor.HandleRequest(request);
        }
    }

    class ConcreteHandler2 : Handler
    {
        public override void HandleRequest(int request)
        {
            if ( request == 2 )
                Console.WriteLine("Two");
            else if ( Succesor != null )
                Succesor.HandleRequest(request);
        }
    }
}
