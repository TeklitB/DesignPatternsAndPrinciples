﻿using NoThreadSafeSingleton = DesignPatterns.Singleton.NonThreadSafe;
using ThreadSafeSingleton = DesignPatterns.Singleton.ThreadSafe;

namespace DesignPatterns
{
    internal class Program
    {
        public static void TestSingleton(string value)
        {
            ThreadSafeSingleton.SingleToken singleton = ThreadSafeSingleton.SingleToken.GetSingleTokenInstance(value);
            Console.WriteLine(singleton.TokenValue);
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

            // Thread safe Singleton pattern
            //Thread thread1 = new Thread(() => { TestSingleton("PUBLIC_TOKEN"); });
            //Thread thread2 = new Thread(() => { TestSingleton("PRIVATE_TOKEN"); });

            //thread1.Start();
            //thread2.Start();

            //thread1.Join();
            //thread2.Join();

            Parallel.Invoke(() => TestSingleton("PUBLIC_TOKEN"), () => TestSingleton("PRIVATE_TOKEN"));
            // END --------------------- Singleton Pattern ---------------------------
        }
    }
}