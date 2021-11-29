using System;
using System.IO;

namespace Skiing_Amongst_Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            Skii skii = new Skii();
            Console.WriteLine(skii.CalcCollisions());
        }
    }
}
