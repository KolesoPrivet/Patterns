using System;

namespace Bridge
{
    class Program
    {
        static void Main()
        {
            Abstraction abstraction = new RefinedAbstraction(new ConcreteImplementor());

            abstraction.Operation();
        }
    }

    abstract class Abstraction
    {
        private Implementor imp;

        public Abstraction(Implementor imp)
        {
            this.imp = imp;
        }

        public virtual void Operation()
        {
            Console.WriteLine("Рисовать фигуру");
            imp.OperationImp();
        }
    }

    class RefinedAbstraction : Abstraction
    {
        public RefinedAbstraction(Implementor imp) : base(imp)
        {
            
        }

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("Рисовать круг");
        }
    }

    abstract class Implementor
    {
        public abstract void OperationImp();
    }

    class ConcreteImplementor : Implementor
    {
        public override void OperationImp()
        {
            Console.WriteLine("Рисовать точками");
        }
    }
}
