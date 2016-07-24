using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton instance = Singleton.getInstance();
            Singleton instance2 = Singleton.getInstance();

            Console.WriteLine("{0} {1}", instance.GetHashCode(), instance2.GetHashCode());
        }
    }

    class Singleton
    {
        private static Singleton instance;
        private static readonly object obj = new object();
        private Singleton() { }

        public static Singleton getInstance()
        {
            if (instance == null) //1st check
            {
                lock (obj)
                {
                    if(instance == null) //2nd check
                        instance = new Singleton();
                }
            }
            return instance;
        }
    }
}
