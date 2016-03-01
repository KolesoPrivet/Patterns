using System;

namespace Proxy
{
    class Program
    {
        static void Main()
        {
            Subject proxy = new Proxy();
            proxy.Request();
        }
    }

    abstract class Subject
    {
        public abstract void Request();
    }

    class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("Real Subject");
        }
    }

    class Proxy : Subject
    {
        private RealSubject realSubject;

        public override void Request()
        {
            if(realSubject == null)
                realSubject = new RealSubject();

            realSubject.Request();
        }
    }
}
