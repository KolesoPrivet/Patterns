using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main()
        {
            Client client = null;

            client = new Client(new CocaColaFactory());
            client.Run();

            client = new Client(new AquaMineraleFactory());
            client.Run();
        }
    }

    class Client
    {
        private AbsWater _water;
        private AbsBottle _bottle;
        private AbsLabel _label;

        public Client(AbsFactory factory)
        {
            // Абстрагирования процессов инстанцирования
            _water = factory.CreateWater();
            _bottle = factory.CreateBottle();
            _label = factory.CreateLabel();
        }

        public void Run()
        {
            // Абстрагирование вариантов использования
            _bottle.Interact(_water);
            _bottle.Interact(_label);
        }
    }

    abstract class AbsFactory
    {
        public abstract AbsBottle CreateBottle();
        public abstract AbsWater CreateWater();
        public abstract AbsLabel CreateLabel();
    }

    abstract class AbsBottle
    {
        public abstract void Interact(AbsWater absWater);
        public abstract void Interact(AbsLabel absLabel);
    }

    abstract class AbsWater
    {
        
    }

    abstract class AbsLabel
    {
        
    }

    class CocaColaFactory : AbsFactory
    {
        public override AbsBottle CreateBottle()
        {
            return new CocaColaBottle();
        }

        public override AbsLabel CreateLabel()
        {
            return new CocaColaLabel();
        }

        public override AbsWater CreateWater()
        {
            return new CocaColaWater();
        }
    }

    class CocaColaBottle : AbsBottle
    {
        public override void Interact(AbsLabel absLabel)
        {
            Console.WriteLine(this + " interact with " + absLabel);
        }

        public override void Interact(AbsWater absWater)
        {
            Console.WriteLine(this + " interact with " + absWater);
        }
    }

    class CocaColaWater : AbsWater
    {
        
    }

    class CocaColaLabel : AbsLabel
    {
         
    }

    class AquaMineraleFactory : AbsFactory
    {
        public override AbsBottle CreateBottle()
        {
            return new AquaMineraleBottle();
        }

        public override AbsLabel CreateLabel()
        {
            return new AquaMineraleLabel();
        }

        public override AbsWater CreateWater()
        {
            return new AquaMineraleWarer();
        }
    }

    class AquaMineraleBottle : AbsBottle
    {
        public override void Interact(AbsLabel absLabel)
        {
            Console.WriteLine(this + " interact with " + absLabel);
        }

        public override void Interact(AbsWater absWater)
        {
            Console.WriteLine(this + " interact with " + absWater);
        }
    }

    class AquaMineraleWarer : AbsWater
    {
        
    }

    class AquaMineraleLabel : AbsLabel
    {
         
    }
}
