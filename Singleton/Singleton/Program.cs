using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var instance = Singleton.GetInstance();
            var instance2 = Singleton.GetInstance();
            if(instance.Equals(instance2))
                Console.WriteLine("instance.Equals(instance2) is equal to "+ instance.Equals(instance2));
            else
                Console.WriteLine("instance.Equals(instance2) is equal to " + instance.Equals(instance2));

            if(instance==instance2)
                Console.WriteLine("instance == instance2 is equal to "+(instance==instance2));
            else
                Console.WriteLine("instance == instance2 is equal to " + (instance == instance2));
            Console.ReadKey();
        }
    }

    //Lazy initialization
    public class Singleton
    {
        private static Singleton _instance;

        private Singleton()
        { }

        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }

            return _instance;
        }
    }

    //Simple Thread safety
    public class SingletonThreadSafe
    {
        private static SingletonThreadSafe _instance;
        private static readonly object lockObj = new object();
        private SingletonThreadSafe() { }

        public static SingletonThreadSafe GetInstance()
        {
            lock (lockObj)
            {
                if (_instance == null)
                {
                    _instance = new SingletonThreadSafe();
                }
            }

            return _instance;
        }
    }

    //Not Lazy but thread safe without using lock
    public class SingletonThreadSafeWithoutLock
    {
        private static readonly SingletonThreadSafeWithoutLock _instance = new SingletonThreadSafeWithoutLock();

        static SingletonThreadSafeWithoutLock() { }
        private SingletonThreadSafeWithoutLock() { }

        public static SingletonThreadSafeWithoutLock GetInstance()
        {
            return _instance;
        }
    }
}
