using System;

namespace Adapter
{
    class Program
    {
        static void Main()
        {
            Adapter adapter = new Adapter();
            adapter.Request();
        }
    }

    interface ITarget
    {
        void Request();
    }

    class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("SpecificRequest");
        }
    }

    class Adapter : ITarget
    {
        private Adaptee adaptee = new Adaptee();
        public void Request()
        {
            adaptee.SpecificRequest();
        }
    }


}
