using System;
using System.Collections;

namespace Visitor
{
    class Program
    {
        static void Main()
        {
            Village village = new Village();
            village.Add(new BoysHouse());
            village.Add(new GirlsHouse());

            village.Accept(new Santa());
            village.Accept(new Troll());
        }
    }

    abstract class Visitor
    {
        public abstract void VisitBoysHouse(BoysHouse boysHouse);
        public abstract void VisitGirlsHouse(GirlsHouse girlsHouse);
    }

    abstract class House
    {
        public abstract void Accept(Visitor visitor);
    }

    class Village
    {
        ArrayList houseList = new ArrayList();

        public void Add(House house)
        {
            houseList.Add(house);
        }

        public void Remove(House house)
        {
            houseList.Remove(house);
        }

        public void Accept(Visitor visiotor)
        {
            foreach (House house in houseList)
            {
                house.Accept(visiotor);
            }
        }
    }

    class BoysHouse : House
    {
        public override void Accept(Visitor visitor)
        {
            if ( visitor is Troll )
                Console.WriteLine("Call police");
            else
                visitor.VisitBoysHouse(this);
        }

        public void TellFairyTale()
        {
            Console.WriteLine("Fairy tale...");
        }

        public void Trolling()
        {
            Console.WriteLine("Trolling boy");
        }
    }

    class GirlsHouse : House
    {
        public override void Accept(Visitor visitor)
        {
            if(visitor is Troll)
                Console.WriteLine("Call police");
            else
                visitor.VisitGirlsHouse(this);
        }

        public void GiveDress()
        {
            Console.WriteLine("Dress as a gift.");
        }

        public void Trolling()
        {
            Console.WriteLine("Trolling girl");
        }
    }

    class Santa : Visitor
    {
        public override void VisitBoysHouse(BoysHouse boysHouse)
        {
            boysHouse.TellFairyTale();
        }

        public override void VisitGirlsHouse(GirlsHouse girlsHouse)
        {
            girlsHouse.GiveDress();
        }
    }

    class Troll : Visitor
    {
        public override void VisitBoysHouse(BoysHouse boysHouse)
        {
            boysHouse.Trolling();
        }

        public override void VisitGirlsHouse(GirlsHouse girlsHouse)
        {
            girlsHouse.Trolling();
        }
    }
}
