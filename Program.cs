using System;

namespace DateTimeHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DateTime Helper");
            Console.WriteLine("Global class providing DateTime methods.");
            Console.WriteLine();
            Console.WriteLine(DateTimeHelper.IsValidFromTo(new DateTime(2020, 2, 2), new DateTime(2020, 2, 2)));
        }
    }
}