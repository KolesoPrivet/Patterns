using System;
using System.Collections;

namespace Composite
{
    class Program
    {
        static void Main()
        {
            Component root = new Composite("Root");
            Component branch1 = new Composite("Branch1");
            Component branch2 = new Composite("Branch2");
            Component leaf1 = new Leaf("Leaf1");

            root.Add(branch1);                   //            ROOT
            root.Add(branch2);                  //            /    \
            branch1.Add(leaf1);                //        BRANCH1  BRANCH2 
        }                                     //            /
    }                                        //          LEAF1

    abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Operation();
        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public abstract Component GetChild(int i);
    }

    class Leaf : Component
    {
        public Leaf(string name) : base(name)
        {
            
        }

        public override void Add(Component component)
        {
            throw new InvalidOperationException();
        }

        public override Component GetChild(int i)
        {
            throw new InvalidOperationException();
        }

        public override void Operation()
        {
            Console.WriteLine(name);
        }

        public override void Remove(Component component)
        {
            throw new InvalidOperationException();
        }
    }

    class Composite : Component
    {
        ArrayList nodes = new ArrayList();

        public Composite(string name) : base(name)
        {
            
        }

        public override void Add(Component component)
        {
            nodes.Add(component);
        }

        public override Component GetChild(int i)
        {
            return nodes[i] as Component;
        }

        public override void Operation()
        {
            Console.WriteLine(name);

            foreach (Component component in nodes)
            {
                component.Operation();
            }
        }

        public override void Remove(Component component)
        {
            nodes.Remove(component);
        }
    }


}
