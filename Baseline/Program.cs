using System;

namespace Baseline
{
    class Program
    {
        static void Main(string[] args)
        {
            Options first_option = new Options(100, 3000, 0.005, true);

            Console.WriteLine(first_option.get_bns_price());
            Console.WriteLine("Hello World!");
        }
    }
}
