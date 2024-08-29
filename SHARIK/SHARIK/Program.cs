namespace P
{
    class SHARIK
    {
        int target;
        bool[] building;

        string log = "";

        public string Log
        {
            get { return log; }
        }
        public SHARIK(int target, int N)
        {
            this.target = target;
            this.building = new bool[N];
            for (int i = 0; i <= target; i++)
            {
                building[i] = true;
            }
        }

        public int FindDurability(out int amountOfTests)
        {
            amountOfTests = 0;

            int start = 0, end = building.Length, cur = 0;
            do
            {
                cur += (int)Math.Sqrt(end);

                Console.WriteLine($"Шарик 1. Опыт {amountOfTests}: проверяем этаж {cur}");
                if (building[cur] == true)
                {
                    Console.WriteLine($"Результат: шарик 1 цел.");
                    start = cur;
                    amountOfTests++;
                } 
                else
                {
                    Console.WriteLine($"Результат: шарик 1 разбит. Переходим " +
                        $"к шарику 2");
                    amountOfTests++;
                    Console.WriteLine($"Шарик 2. Поиск ответа");
                    for (int i = start + 1; i < cur; i++)
                    {
                        Console.WriteLine($"Шарик 2. Опыт {amountOfTests}: проверяем этаж {i}");
                        amountOfTests++;
                        if (building[i] == false)
                        {
                            Console.WriteLine($"Результат: шарик 2 разбит. " +
                                $"Максимальная прочность обнаружена");
                            return i - 1;
                        }
                        Console.WriteLine($"Результат: шарик 2 цел.");
                    }
                    break;
                }

            }
            while (start != end);
            return building.Length;
        }
    }
    class P
    {

        static void Main()
        {
            Console.WriteLine("Введите этажность здания");
            int N = Convert.ToInt32(Console.ReadLine());
            Random R = new Random();
            int res = R.Next(N);
            int trys;
            Console.WriteLine("Сгенерированная прочность," +
                "то есть максимальный этаж когда шарик при падении" +
                "с него еще цел, = " + res);

            SHARIK p = new SHARIK(res, N);

            Console.WriteLine("Попытки" + p.Log);
            Console.WriteLine("Найденная прочность " + p.FindDurability(out trys));
            Console.WriteLine("Количество попыток " + trys);

        }
    }
}