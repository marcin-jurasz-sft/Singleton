using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace SingletonTests
{
    public class SingletonInstance
    {
        private readonly ITestOutputHelper _output;

        public SingletonInstance(ITestOutputHelper output)
        {
            _output = output;
            SingletonTestHelpers.Reset(typeof(SingletonApp.SingletonClass1));
        }

        [Fact]
        public void ReturnsNonNullSingletonInstance()
        {
            Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<SingletonApp.SingletonClass1>());

            var result = SingletonApp.SingletonClass1.Instance;

            Assert.NotNull(result);
            Assert.IsType<SingletonApp.SingletonClass1>(result);
        }

        [Fact]
        public void OnlyCallsConstructorOnceGivenThreeInstanceCalls()
        {
            Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<SingletonApp.SingletonClass1>());

            var one = SingletonApp.SingletonClass1.Instance;
            var two = SingletonApp.SingletonClass1.Instance;
            var three = SingletonApp.SingletonClass1.Instance;
        }

        [Fact]
        public void CallsConstructorMultipleTimesGivenThreeParallelInstanceCalls()
        {
            Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<SingletonApp.SingletonClass1>());

            var strings = new List<string>() { "one", "two", "three" };
            var instances = new List<SingletonApp.SingletonClass1>();
            var options = new ParallelOptions() { MaxDegreeOfParallelism = 3 };
            Parallel.ForEach(strings, options, instance =>
            {
                instances.Add(SingletonApp.SingletonClass1.Instance);
            });
        }
    }

    public static class SingletonTestHelpers
    {
        public static void Reset(Type type)
        {
            FieldInfo info = type.GetField("_instance", BindingFlags.NonPublic | BindingFlags.Static);
            info.SetValue(null, null);
        }

        public static T GetPrivateStaticInstance<T>() where T : class
        {
            Type type = typeof(T);
            FieldInfo info = type.GetField("_instance", BindingFlags.NonPublic | BindingFlags.Static);
            return info.GetValue(null) as T;
        }
    }
}
