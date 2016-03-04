using System;


namespace Mediator
{
    class Program
    {
        static void Main()
        {
            ConcreteMediator mediator = new ConcreteMediator();
            Farmer farmer = new Farmer(mediator);
            Cannery cannery = new Cannery(mediator);
            Shop shop = new Shop(mediator);

            mediator.Farmer = farmer;
            mediator.Cannery = cannery;
            mediator.Shop = shop;

            farmer.GrowTomato();
        }
    }

    abstract class Mediator
    {
        public abstract void Send(string msg, Colleage colleage);
    }

    abstract class Colleage
    {
        protected Mediator mediator;

        public Colleage(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }

    class Farmer : Colleage
    {
        public Farmer(Mediator mediator) : base(mediator)
        {
            
        }

        public void GrowTomato()
        {
            string tomato = "Tomato";
            Console.WriteLine(GetType().Name + " raised " + tomato);
            mediator.Send(tomato, this);
        }
    }

    class Cannery : Colleage
    {
        public Cannery(Mediator mediator) : base(mediator)
        {
            
        }

        public void MakeKetchup(string msg)
        {
            string ketchup = msg + "Ketchup";
            Console.WriteLine(GetType().Name + " produced " + ketchup);
            mediator.Send(ketchup, this);
        }
    }

    class Shop : Colleage
    {
        public Shop(Mediator mediator) : base(mediator)
        {
            
        }

        public void SellKetchup(string msg)
        {
            Console.WriteLine(GetType().Name + " sold " + msg);
        }
    }

    class ConcreteMediator : Mediator
    {
        public Farmer Farmer { get; set; }
        public Cannery Cannery { get; set; }
        public Shop Shop { get; set; }

        public override void Send(string msg, Colleage colleage)
        {
            if (colleage == Farmer)
            {
                Cannery.MakeKetchup(msg);
            }
            else if (colleage == Cannery)
            {
                Shop.SellKetchup(msg);
            }
        }
    }

    
}
