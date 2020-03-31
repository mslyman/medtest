using System;
using System.Collections.Generic;

namespace tmp
{
    class A
    {
        public void M0()
        {
            Console.WriteLine("a0");
        }
        public virtual void M1()
        {
            Console.WriteLine("a");
        }
    }
    class B : A
    {
        public new void M0()
        {
            Console.WriteLine("b0");
        }
        public override void M1()
        {
            Console.WriteLine("b");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            var x = new List<int>
            {
                1, 3, 5, 0
            };
            var y = x.Contains(0);
            Console.WriteLine("Hello World!");
            
        }
    }
}
