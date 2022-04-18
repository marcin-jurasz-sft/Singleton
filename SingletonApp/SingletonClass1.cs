using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonApp
{
    # nullable enable
    public sealed class SingletonClass1
    {
        private static SingletonClass1? _instance;
        private static readonly object padlock = new object();

        public static SingletonClass1 Instance
        {
            get
            {
                Console.WriteLine("Instance called");

                lock (padlock) // to ensure threads enter here one by one
                {
                    return _instance ??= new SingletonClass1();
                }
            }
        }

        private SingletonClass1()
        {
            Console.WriteLine("Constructor invoked");
        }
    }
}
