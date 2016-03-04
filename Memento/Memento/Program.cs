using System;

namespace Memento
{
    class Program
    {
        static void Main()
        {
            Man alex = new Man();
            Robot r2d2 = new Robot();

            alex.Clothes = "Футболка, джинсы, кеды";
            r2d2.Backpack = alex.Undress();

            alex.Clothes = "Шорты спортивные";
            alex.Dress(r2d2.Backpack);
        }
    }

    class Man
    {
        public string Clothes { get; set; }

        public void Dress(Backpack backpack)
        {
            Clothes = backpack.Contents;
        }

        public Backpack Undress()
        {
            return new Backpack(Clothes);
        }
    }

    class Backpack
    {
        public string Contents { get; private set; }

        public Backpack(string contents)
        {
            Contents = contents;
        }
    }

    class Robot
    {
        public Backpack Backpack { get; set; }
    }
}
