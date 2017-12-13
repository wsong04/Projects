using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
  class Program
  {
    static void Main(string[] args)
    {
      var numbers = new Numbers();

      Console.WriteLine("Please specify the project you want to run: ");
      Console.WriteLine("1. Find PI to the Nth Digit");
      Console.WriteLine("2. Find e to the Nth Digit");
      Console.WriteLine("3. Fibonacci Sequence");
      Console.WriteLine("4. Prime Factorization");
      Console.WriteLine("5. Next Prime Number");
      Console.Write("Your choice: ");
      var line = Console.ReadLine();
      var choice = Convert.ToInt32(line);

      switch(choice)
      {
        case 1:
          numbers.FindPItotheNthDigit();
          break;
        case 2:
          numbers.FindetotheNthDigit();
          break;
        case 3:
          numbers.FibonacciSequence();
          break;
        case 4:
          numbers.PrimeFacorization();
          break;
        case 5:
          numbers.NextPrimeNumber();
          break;
        default:
          break;
      }
    }
  }
}
