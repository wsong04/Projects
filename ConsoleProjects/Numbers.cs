using CognitioConsulting.Numerics;
using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
  class Numbers
  {
    public void FindPItotheNthDigit()
    {
      var n = EnteraNumber();
      var pi = CalculatePi(n);
      pi = AddDecimalPoint(pi);
      Console.WriteLine(pi);
    }

    public void FindetotheNthDigit()
    {
      var n = EnteraNumber();
      var e = Calculatee();
      Console.WriteLine(ToNDecimalPlaces(e.ToString(), n));
    }

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

    public void NextPrimeNumber()
    {
      var n = EnteraNumber();
      var a = new bool[n + 1];
      for (var i = 0; i < a.Length; i++)
      {
        a[i] = true;
      }
      for (var i = 2; i <= Math.Sqrt(n); i++)
      {
        if (a[i])
        {
          for (var j = i * i; j <= n; j += i)
          {
            a[j] = false;
          }
        }
      }
      for (var i = 2; i <= n; i++)
      {
        if (a[i]) Console.WriteLine(i);
      }
    }

    public void ChangeReturnProgram()
    {
      Console.Write("Enter a cost: ");
      var line = Console.ReadLine();
      var cost = Convert.ToDecimal(line);
      Console.Write("Enter the amount of money given: ");
      line = Console.ReadLine();
      var amount = Convert.ToDecimal(line);

      var change = amount - cost;
      int temp = (int)(change * 100);
      var quaters = temp / 25;
      temp = temp % 25;
      var dimes = temp / 10;
      temp = temp % 10;
      var nickels = temp / 5;
      temp = temp % 5;
      var pennies = temp;
      Console.WriteLine($"The change is {change}.");
      Console.WriteLine($"Quarters: {quaters}, dimes: {dimes}, nickels: {nickels}, pennies: {pennies}");
    }

    public void BinaryDecimalConverter()
    {
      Console.Write("Convert binary to decimal? (y/n): ");
      var mode = Console.ReadLine();
      Console.Write("Enter a number: ");
      var line = Console.ReadLine();
      if (mode.Equals("y", StringComparison.OrdinalIgnoreCase))
      {
        ConvertBinarytoDecimal(line);
      }
      else
      {
        ConvertDecimaltoBinary(line);
      }
    }

    public void DistanceBetweenTwoCities()
    {
      Console.Write("Enter city 1: ");
      var city1 = Console.ReadLine();
      Console.Write("Enter city 2: ");
      var city2 = Console.ReadLine();
      Console.Write("Enter unit of distance (km/mi): ");
      var unit = Console.ReadLine();

      var point1 = FindCityCoordinates(city1);
      var point2 = FindCityCoordinates(city2);
      var coord1 = new GeoCoordinate(point1.Latitude, point1.Longitude);
      var coord2 = new GeoCoordinate(point2.Latitude, point2.Longitude);
      var distanceInMeters = coord1.GetDistanceTo(coord2);
      if ("mi".Equals(unit))
      {
        Console.WriteLine((int)(distanceInMeters / 1000 / 1.60934) + " mi");
      }
      else
      {
        //Console.WriteLine((int)(distanceInMiles * 1.60934) + " km");
        Console.WriteLine((int)(distanceInMeters / 1000) + "km");
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

    private void ConvertBinarytoDecimal(string n)
    {
      //var a = n.ToCharArray();
      //var result = 0;
      //for (var i=0; i<a.Length; i++)
      //{
      //  result += (int)Char.GetNumericValue(a[i]) * (int)Math.Pow(2, a.Length - i - 1);
      //}
      //Console.WriteLine(result);
      Console.WriteLine(Convert.ToInt32(n, 2));
    }

    private void ConvertDecimaltoBinary(string n)
    {
      Console.WriteLine(Convert.ToString(Convert.ToInt32(n), 2));
    }

    private MapPoint FindCityCoordinates(string address)
    {
      var locationService = new GoogleLocationService();
      var point = locationService.GetLatLongFromAddress(address);
      return point;
    }
    #endregion
  }
}
