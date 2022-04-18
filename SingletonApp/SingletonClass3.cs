using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonApp
{
    # nullable enable
    public sealed class SingletonClass3
    {
        private static readonly SingletonClass3 _instance = new SingletonClass3();
        // reading this will init the _instance either
        public static readonly string GREETING = "Hi!";

        // let's tell the c# compiler not to mark type as beforefieldinit
        static SingletonClass3()
        { 
            
        }

        public static SingletonClass3 Instance
        {
            get 
            {
                Console.WriteLine("Instance called");

                return _instance;
            }
        }

        private SingletonClass3()
        {
            Console.WriteLine("Constructor invoked");
        }
    }
}
