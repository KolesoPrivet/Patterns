using System;
using System.Collections.Generic;

namespace Command
{
    class Program
    {
        static void Main()
        {
            Receiver receiver = new Receiver();
            Command command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker();

            invoker.StoreCommand(command);
            invoker.ExecuteCommand();
        }
    }

    abstract class Command
    {
        protected Receiver receiver;

        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
    }

    class ConcreteCommand : Command //листочек
    {
        public ConcreteCommand(Receiver receiver) : base(receiver)
        {
            
        }

        public override void Execute()
        {
            receiver.Action();
        }
    }

    class Invoker //официант
    {
        Command command;

        public void StoreCommand(Command command)
        {
            this.command = command;
        }

        public void ExecuteCommand()
        {
            command.Execute();
        }
    }

    class Receiver //повар
    {
        public void Action()
        {
            Console.WriteLine("Receiver");
        }
    }
}
