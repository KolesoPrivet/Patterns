using System;

namespace State
{
    class Program
    {
        static void Main()
        {
            Context context = new Context(new ConcreteState1());

            Console.WriteLine(context.State); //state 1

            context.Request(); //change state
            Console.WriteLine(context.State); //state 2

            context.Request(); //change state
            Console.WriteLine(context.State); //state 1
        }
    }

    class Context
    {
        public State State { get; set; }

        public Context(State state)
        {
            State = state;
        }

        public void Request()
        {
            State.Handle(this);
        }
    }

    abstract class State
    {
        public abstract void Handle(Context context);
    }

    class ConcreteState1 : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteState2();
        }
    }

    class ConcreteState2 : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteState1();
        }
    }
}
