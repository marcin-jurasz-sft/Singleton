using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonApp
{
    # nullable enable
    public sealed class SingletonClass2
    {
        private static SingletonClass2? _instance;
        private static readonly object padlock = new object();

        public static SingletonClass2 Instance
        {
            get 
            {
                Console.WriteLine("Instance called");

                if (_instance == null) // double check locking
                {
                    lock (padlock) // to ensure threads enter here one by one
                    {
                        _instance = new SingletonClass2();
                    }
                }

                return _instance;
            }
        }

        private SingletonClass2()
        {
            Console.WriteLine("Constructor invoked");
        }
    }
}
