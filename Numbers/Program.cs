﻿using System;
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
      Console.Write("Your choice: ");
      var line = Console.ReadLine();
      var choice = Convert.ToInt32(line);

      switch(choice)
      {
        case 1:
          numbers.FindPItotheNthDigit();
          break;
        default:
          break;
      }
    }
  }
}
