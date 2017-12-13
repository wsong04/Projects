using CognitioConsulting.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
  class Numbers
  {
    #region FindPItotheNthDigit
    public void FindPItotheNthDigit()
    {
      var n = EnteraNumber();
      var pi = CalculatePi(n);
      pi = AddDecimalPoint(pi);
      Console.WriteLine(pi);
    }
    #endregion

    #region FindetotheNthDigit
    public void FindetotheNthDigit()
    {
      var n = EnteraNumber();
      var e = Calculatee();
      Console.WriteLine(ToNDecimalPlaces(e.ToString(), n));
    }
    #endregion

    public void FibonacciSequence()
    {
      var n = EnteraNumber();
      GenerateFibonacciSequence(n);
    }

    public void PrimeFacorization()
    {
      var n = EnteraNumber();
      var factors = PrimeFactors(n);
      foreach (var i in factors)
      {
        Console.WriteLine(i);
      }
    }

    #region Private Methods
    private int EnteraNumber()
    {
      Console.Write("Enter a number: ");
      var line = Console.ReadLine();
      return Convert.ToInt32(line);
    }

    private string CalculatePi(int digits)
    {
      digits++;

      uint[] x = new uint[digits * 10 / 3 + 2];
      uint[] r = new uint[digits * 10 / 3 + 2];

      uint[] pi = new uint[digits];

      for (int j = 0; j < x.Length; j++)
        x[j] = 20;

      for (int i = 0; i < digits; i++)
      {
        uint carry = 0;
        for (int j = 0; j < x.Length; j++)
        {
          uint num = (uint)(x.Length - j - 1);
          uint dem = num * 2 + 1;

          x[j] += carry;

          uint q = x[j] / dem;
          r[j] = x[j] % dem;

          carry = q * num;
        }


        pi[i] = (x[x.Length - 1] / 10);


        r[x.Length - 1] = x[x.Length - 1] % 10; ;

        for (int j = 0; j < x.Length; j++)
          x[j] = r[j] * 10;
      }

      var result = "";

      uint c = 0;

      for (int i = pi.Length - 1; i >= 0; i--)
      {
        pi[i] += c;
        c = pi[i] / 10;

        result = (pi[i] % 10).ToString() + result;
      }

      return result;
    }

    private string AddDecimalPoint(string pi)
    {
      return pi.Length == 1 ? pi : pi.Substring(0, 1) + "." + pi.Substring(1);
    }

    private BigDecimal Factorial(int n)
    {
      if (n == 0) return 1;
      BigDecimal factorial = 1;
      for (var i = 1; i <= n; i++)
      {
        factorial *= i;
      }
      return factorial;
    }

    private BigDecimal Calculatee()
    {
      BigDecimal e = 0;
      for (var i = 0; i < 100; i++)
      {
        e += 1.0 / Factorial(i);
      }
      return e;
    }

    private string ToNDecimalPlaces(string bigDecimal, int n)
    {
      var decimalIndex = bigDecimal.IndexOf('.');
      if (n == 0) return bigDecimal.Substring(0, decimalIndex);
      return bigDecimal.Substring(0, decimalIndex + n + 1);
    }

    private void GenerateFibonacciSequence(int n)
    {
      if (n < 1) return;
      var prev = 1;
      Console.WriteLine(prev);
      if (n == 1)
      {
        return;
      }
      var current = 1;
      Console.WriteLine(current);
      if (n == 2)
      {
        return;
      }
      for (var i = 3; i <= n; i++)
      {
        var temp = prev + current;
        Console.WriteLine(temp);
        prev = current;
        current = temp;
      }
    }

    private List<int> PrimeFactors(int n)
    {
      List<int> factors = new List<int>();
      for (var i=2; i<=n; i++)
      {
        while (n % i == 0)
        {
          factors.Add(i);
          n /= i;
        }
      }
      return factors;
    }
    #endregion
  }
}
