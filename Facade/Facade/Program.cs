using System;

namespace Facade
{
    class Program
    {
        static void Main()
        {
            Facade facade = new Facade();

            facade.OperationA();
            facade.OperationB();
        }
    }

    class Facade
    {
        SubSystemA subA = new SubSystemA();
        SubSystemB subB = new SubSystemB();
        SubSystemC subC = new SubSystemC();

        public void OperationA()
        {
            subA.OperationA();
            subB.OperationB();
        }

        public void OperationB()
        {
            subB.OperationB();
            subC.OperationC();
        }
    }

    class SubSystemA
    {
        public void OperationA()
        {
            Console.WriteLine(GetType());
        }
    }

    class SubSystemB
    {
        public void OperationB()
        {
            Console.WriteLine(GetType());
        }
    }

    class SubSystemC
    {
        public void OperationC()
        {
            Console.WriteLine(GetType());
        }
    }
}
