using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonApp
{
#nullable enable
    public sealed class SingletonClass4
    {
        // reading this will init the _instance either
        public static readonly string GREETING = "Hi!";

        public static SingletonClass4 Instance
        {
            get
            {
                Console.WriteLine("Instance called");

                return Nested._instance;
            }
        }

        private class Nested
        {
            static Nested()
            {
            }
            internal static readonly SingletonClass4 _instance = new SingletonClass4();
        }

        private SingletonClass4()
        {
            // cannot be create d except withing this class
            Console.WriteLine("Constructor invoked");
        }
    }
}
