// <copyright file="Program.cs" company="Prism">
// Copyright (c) Prism. All rights reserved.
// </copyright>

namespace Prism.Archi.Samples.Await
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    internal class Program
    {
        private static readonly Random Dice = new Random();

        public static async Task Main(string[] args)
        {
            await ThisDoesNotWorkAsync();
            await ThisWorkAsync();
        }

        public static async Task<TimeSpan> WaitRandomTime()
        {
            var waitTime = Dice.Next(1000, 2000);
            await Task.Delay(waitTime);
            return TimeSpan.FromMilliseconds(waitTime);
        }

        private static void Log(string content)
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff} - {content}");
        }

        private static async Task ThisDoesNotWorkAsync()
        {
            Console.WriteLine("===> This code does NOT work in //");

            var response1 = await WaitRandomTime();
            Log("Call 1 started");
            var response2 = await WaitRandomTime();
            Log("Call 2 started");
            var response3 = await WaitRandomTime();
            Log("Call 3 started");
            var response4 = await WaitRandomTime();
            Log("Call 4 started");
            var response5 = await WaitRandomTime();
            Log("Call 5 started");

            var elapsed1 = response1.TotalMilliseconds;
            Log($"Call 1 done : {elapsed1}");
            var elapsed2 = response2.TotalMilliseconds;
            Log($"Call 2 done : {elapsed2}");
            var elapsed3 = response3.TotalMilliseconds;
            Log($"Call 3 done : {elapsed3}");
            var elapsed4 = response4.TotalMilliseconds;
            Log($"Call 4 done : {elapsed4}");
            var elapsed5 = response5.TotalMilliseconds;
            Log($"Call 5 done : {elapsed5}");
        }

        private static async Task ThisWorkAsync()
        {
            Console.WriteLine("===> This code does work //");

            var task1 = WaitRandomTime();
            Log("Call 1 started");
            var task2 = WaitRandomTime();
            Log("Call 2 started");
            var task3 = WaitRandomTime();
            Log("Call 3 started");
            var task4 = WaitRandomTime();
            Log("Call 4 started");
            var task5 = WaitRandomTime();
            Log("Call 5 started");

            var elapsed1 = await task1;
            Log($"Call 1 done : {elapsed1.TotalMilliseconds}");
            var elapsed2 = await task2;
            Log($"Call 2 done : {elapsed2.TotalMilliseconds}");
            var elapsed3 = await task3;
            Log($"Call 3 done : {elapsed3.TotalMilliseconds}");
            var elapsed4 = await task4;
            Log($"Call 4 done : {elapsed4.TotalMilliseconds}");
            var elapsed5 = await task5;
            Log($"Call 5 done : {elapsed5.TotalMilliseconds}");
        }
    }
}