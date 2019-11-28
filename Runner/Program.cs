using System;
using LiteDB5Test;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new V5Tests().Int();
                Console.WriteLine("Int ok");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                new V5Tests().Double();
                Console.WriteLine("Double ok");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            try
            {
                new V5Tests().Float();
                Console.WriteLine("Float ok");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            try
            {
                new V5Tests().Decimal();
                Console.WriteLine("Decimal ok");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}