using System;

namespace Template_Method
{
    class Program
    {
        static void Main()
        {
            TwoColorFlag polandFlag = new PolandFlag();
            polandFlag.Draw();
        }
    }

    abstract class TwoColorFlag
    {
        public void Draw() //Template method
        {
            DrawTopPart();
            DrawBottomPart();
            Console.BackgroundColor = ConsoleColor.Black;
        }

        protected abstract void DrawTopPart();
        protected abstract void DrawBottomPart();
    }

    class PolandFlag : TwoColorFlag
    {
        protected override void DrawBottomPart()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(new string(' ', 7));
        }

        protected override void DrawTopPart()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(new string(' ', 7));
        }
    }

    class UkraineFlag : TwoColorFlag
    {
        protected override void DrawBottomPart()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new string(' ', 7));
        }

        protected override void DrawTopPart()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(new string(' ', 7));
        }
    }
}
