﻿using NoThreadSafeSingleton = DesignPatterns.Singleton.NonThreadSafe;
using ThreadSafeSingleton = DesignPatterns.Singleton.ThreadSafe;
using SingletonEagerLoading = DesignPatterns.Singleton.EagerLoading;
using SingletonLazyLoading = DesignPatterns.Singleton.LazyLoading;

namespace DesignPatterns
{
    internal class Program
    {
        public static void TestSingleTokenThreadSafe(string value)
        {
            ThreadSafeSingleton.SingleToken singleton = ThreadSafeSingleton.SingleToken.GetSingleTokenInstance(value);
            Console.WriteLine(singleton.TokenValue);
        }

        public static void TestSingleTokenNonThreadSafe(string value)
        {
            NoThreadSafeSingleton.SingleToken singleton = NoThreadSafeSingleton.SingleToken.GetSingleTokenInstance();
        }

        public static void TestSingleTokenEagerLoading(string value)
        {
            SingletonEagerLoading.SingleToken singleton = SingletonEagerLoading.SingleToken.GetSingleTokenInstance(value);
        }

        public static void TestSingleTokenLazyLoading(string value)
        {
            SingletonLazyLoading.SingleToken singleton = SingletonLazyLoading.SingleToken.GetSingleTokenInstance(value);
        }
        static void Main(string[] args)
        {
            // BEGIN --------------------- Singleton Pattern ---------------------------
            // None thread safe Singleton pattern
            //NoThreadSafeSingleton.SingleToken token1 = NoThreadSafeSingleton.SingleToken.GetSingleTokenInstance();
            //NoThreadSafeSingleton.SingleToken token2 = NoThreadSafeSingleton.SingleToken.GetSingleTokenInstance();
            ////Check if the two instances are equal
            //if (token1 == token2) Console.WriteLine("Creation of Single instance succeeded!");
            //else Console.WriteLine("Creation of Single instance failed!");
            //Parallel.Invoke(() => TestSingleTokenNonThreadSafe("PUBLIC_TOKEN"), () => TestSingleTokenNonThreadSafe("PRIVATE_TOKEN"));

            // Thread safe Singleton pattern
            //Thread thread1 = new Thread(() => { TestSingleton("PUBLIC_TOKEN"); });
            //Thread thread2 = new Thread(() => { TestSingleton("PRIVATE_TOKEN"); });

            //thread1.Start();
            //thread2.Start();

            //thread1.Join();
            //thread2.Join();

            //Parallel.Invoke(() => TestSingleTokenThreadSafe("PUBLIC_TOKEN"), () => TestSingleTokenThreadSafe("PRIVATE_TOKEN"));

            // Singleton instance using Eager Loading
            //Parallel.Invoke(() => TestSingleTokenEagerLoading("PUBLIC_TOKEN"), () => TestSingleTokenEagerLoading("PRIVATE_TOKEN"));

            // Singleton instance using Lazy Loading
            Parallel.Invoke(() => TestSingleTokenLazyLoading("PUBLIC_TOKEN"), () => TestSingleTokenLazyLoading("PRIVATE_TOKEN"));
            // END --------------------- Singleton Pattern ---------------------------
        }
    }
}