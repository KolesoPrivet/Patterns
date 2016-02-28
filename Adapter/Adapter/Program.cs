using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
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
