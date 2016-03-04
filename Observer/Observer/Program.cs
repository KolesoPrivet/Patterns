using System;
using System.Collections;

namespace Observer
{
    class Program
    {
        static void Main()
        {
            ConcreteSubject concreteSubject = new ConcreteSubject();

            concreteSubject.Attach(new ConcreteObserver(concreteSubject));
            concreteSubject.Attach(new ConcreteObserver(concreteSubject));

            concreteSubject.State = "Some state";
            concreteSubject.Notify();
        }
    }

    abstract class Observer
    {
        public abstract void Update(); // Update(string state);
    }

    class ConcreteObserver : Observer
    {
        private string observerState;
        private ConcreteSubject concreteSubject;

        public ConcreteObserver(ConcreteSubject concreteSubject)
        {
            this.concreteSubject = concreteSubject;
        }

        public override void Update() // Update(string state);
        {
            observerState = concreteSubject.State; // observerState = state;
        }
    }

    abstract class Subject
    {
        ArrayList observers = new ArrayList();

        //public abstract string State { get; set; }

        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (Observer observer in observers)
            {
                observer.Update();
            }
        }
    }

    class ConcreteSubject : Subject
    {
        public string State { get; set; }
    }
}
