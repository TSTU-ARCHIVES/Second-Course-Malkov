namespace P
{
    public static class Ariphmetics
    {
        public static long GCD(long a, long b)
        {
            return Extendedgcd(a, b).gcd;
        }
        private static (long gcd, long x, long y) Extendedgcd(long a, long b)
        {
            long gcd, x, y, x1, y1;
            if (b == 0)     
                return (a, 1, 0);
            (gcd, x1, y1) = Extendedgcd(b, a % b);
            x = y1;
            y = x1 - (a / b) * y1;
            return (gcd, x, y);
        }
        public static int MLC(int num1, int num2)
        {
            return (num1 * num2) / (int)Ariphmetics.GCD(num1, num2);
        }
        public static List<int> ContRatio(Rational k)
        {
            List<int> ints = new();
            int q = k.GetNumerator() / k.GetDenominator();
            Rational alpha = new Rational(k.GetDenominator(), k.GetNumerator() % k.GetDenominator());
            ints.Add(q);
            while (alpha.GetDenominator() != 0)
            {
                q = alpha.GetNumerator() / alpha.GetDenominator();
                ints.Add(q);
                alpha = new Rational(alpha.GetDenominator(), alpha.GetNumerator() % alpha.GetDenominator());
            }

            return ints;
        }
    }
    public class Rational
    {
        private int a;
        private int b;

        public Rational(int a, int b)
        {
            int gcd = (int)Ariphmetics.GCD(a, b);
            //a /= gcd;
            //b /= gcd;
            this.a = a;
            this.b = b;
        }   

        public Rational()
        {
            this.a = 0;
            this.b = 1;
        }

        public int GetNumerator()
        {
            return this.a;
        }

        public int GetDenominator()
        {
            return this.b;
        }

        public static Rational operator + (Rational that, Rational second)
        {
            return new Rational(
                that.a * second.GetDenominator() + second.GetNumerator() * that.b,
                that.b * second.GetDenominator()
                );
        }
    }
    public static class P
    {
        public static int GetUserInput(string s)
        {
            Console.WriteLine(s);
            return int.Parse(Console.ReadLine());
        }
        public static void MLCGCD()
        {
            int a = GetUserInput("Введите первое число");
            int b = GetUserInput("Введите второе число");
            Console.WriteLine("НОК = " + Ariphmetics.MLC(a, b) + "\n" +
                "НОД = " + Ariphmetics.GCD(a, b)
                );
        }
        public static void Draw(List<int> a)
        {
            Console.Write("[");
            foreach(int k in a)
            {
                Console.Write($"{k}, ");
            }
            Console.Write("]");
        }
        public static void Cont()
        {
            int a = GetUserInput("Введите Числитель");
            int b = GetUserInput("Введите знаменатель");
            List<int> res = Ariphmetics.ContRatio(new Rational(a, b));
            Draw(res);
        }

        public static void Error()
        {
            Console.WriteLine("Неизвестный выбор");
        }
        public static void Main()
        {
            Console.WriteLine("Введите 1, если хотите найти НОК и НОД чисел \n" +
                "Введите 2, если хотите получить разложение в непрерывную дробь");
            int choice = GetUserInput("");
            switch (choice) {
                case 1:
                    MLCGCD();
                    break;
                case 2:
                    Cont();
                    break;
                default:
                    Error();
                    break;
            }


        }
    }
}