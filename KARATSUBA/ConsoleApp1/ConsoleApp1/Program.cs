using System.Diagnostics;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Timers;

namespace P
{
    public static class MultExt
    {
        static string OffsetLeft(BigInteger x, int m)
        {
            if (m >= x.ToString().Length)
                return "0";
            string str = x.ToString().Substring(0, x.ToString().Length - m);
            return str;
        }

        static string OffsetRight(BigInteger x, int m)
        {
            if (m <= 0)
                return x.ToString();
            StringBuilder sb = new StringBuilder(x.ToString(), x.ToString().Length + m);
            for (int i = 0; i < m; i++)
                sb.Append("0");
            return sb.ToString();
        }

        static string Cut(BigInteger x, int m)
        {
            if (m >= x.ToString().Length)
                return x.ToString();
            string str = x.ToString().Substring(x.ToString().Length - m);
            return str;
        }
        public static BigInteger KaratsubaMultiply(this BigInteger x, BigInteger y)
        {
            if (x < 10 || y < 10)
                return x * y;

            int n = Math.Max((int)x.GetBitLength(), (int)y.GetBitLength());
            int m = (n + 1) / 2;

            BigInteger a = x >> m;
            BigInteger b = x & ((BigInteger.One << m) - 1);
            BigInteger c = y >> m;
            BigInteger d = y & ((BigInteger.One << m) - 1);

            BigInteger ac = a.KaratsubaMultiply(c);
            BigInteger bd = b.KaratsubaMultiply(d);
            BigInteger k = (a + b).KaratsubaMultiply(c + d) - ac - bd;

            return 
                ac * ((BigInteger.One << (2 * m))) 
                + k * ((BigInteger.One << m)) 
                + bd;
        }
    }
    public static class P
    {
        public static void Main()
        {
            int size = 512;
            byte[] byteArray1 = new byte[size];
            byte[] byteArray2 = new byte[size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                byteArray1[i] = (byte)random.Next(0, 256);
                byteArray2[i] = (byte)random.Next(0, 256);
            }

            BigInteger first = new BigInteger
                (byteArray1);
            BigInteger second = new BigInteger
                (byteArray2);


            Console.WriteLine(first);
            Console.WriteLine();
            Console.WriteLine(second);
            Console.WriteLine();
            Stopwatch stopwatch = new Stopwatch();


            stopwatch.Start();
            BigInteger f = first.KaratsubaMultiply(second);
            stopwatch.Stop();
            Console.WriteLine("Karatsuba - " + stopwatch.ElapsedTicks);

            stopwatch.Restart();
            f = first* second;
            stopwatch.Stop();
            Console.WriteLine("Internal BigInt - " + stopwatch.ElapsedTicks);

            stopwatch.Restart();

            BigInteger result = 0;
            BigInteger position = 1;

            BigInteger num2 = second, num1 = first;
            while (num2 > 0)
            {
                BigInteger digit = BigInteger.ModPow(num2,1, 10);
                BigInteger partialResult = num1 * digit;

                result += partialResult * BigInteger.Pow(10, (int)position - 1);
                num2 /= 10;
                position++;
            }
            f = result;

            Console.WriteLine("Default - " + stopwatch.ElapsedTicks);
            stopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine(first.KaratsubaMultiply(second));
            Console.WriteLine();
            Console.WriteLine(first * second);
            Console.WriteLine();
            Console.WriteLine(f);
            Console.WriteLine();
        }
    }
}