using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonApp
{
#nullable enable
    public sealed class SingletonClass5
    {
        // reading this will init the _instance either
        public static readonly Lazy<SingletonClass5> _lazy = new Lazy<SingletonClass5>(() => new SingletonClass5());

        public static SingletonClass5 Instance
        {
            get
            {
                Console.WriteLine("Instance called");

                return _lazy.Value;
            }
        }

        private SingletonClass5()
        {
            // cannot be create d except withing this class
            Console.WriteLine("Constructor invoked");
        }
    }
}
