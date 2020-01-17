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

            var test = DateTimeHelper.GetMonthStart(DateTime.Now);
            Console.WriteLine(test);

        }
    }
}