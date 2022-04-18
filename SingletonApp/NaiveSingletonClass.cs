using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonApp
{
    // not thread safe, bad style
    public sealed class NaiveSingletonClass
    {
        private static NaiveSingletonClass _instance;

        public static NaiveSingletonClass Instance
        {
            get 
            {
                Console.WriteLine("Instance called");

                if (_instance == null)
                {
                    _instance = new NaiveSingletonClass();
                }

                return _instance;
            }
        }

        private NaiveSingletonClass()
        {
            Console.WriteLine("Constructor invoked");
        }
    }
}
