﻿

using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace aoc2022;
class Program
{
    static void Main(string[] args)
    {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            
            var c1= new D1();
            int [] i =c1.Part1();
            Console.WriteLine("The Result for Part 1 is " + i[0] + " The Result for Part 2 is " + i[1]);
            //ulong i =c1.Part2();
            //Console.WriteLine("The Result for Part 2 is " + i);
            
            sw.Stop();

            Console.WriteLine("Elapsed={0}",sw.Elapsed.TotalMilliseconds);
    }
}
