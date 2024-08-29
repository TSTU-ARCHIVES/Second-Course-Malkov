using WindowsFormsApp1;

namespace Lab4to5
{
    
    public static class Program
    {
        static int GetUserInput(int from, int to)
        {
            int res;
            Console.WriteLine($"Введите число от {from} до {to}");
            if (!int.TryParse(Console.ReadLine(), out res))
            {
                Console.WriteLine("Некорректный ввод");
                return from - 1;
            }
            if (res > to || res < from)
            {
                Console.WriteLine("Число вне отрезка значений");
                return from - 1;
            }
            return res;
        }
        public static int[] InputArr()
        {
            int N = GetUserInput(1, int.MaxValue);
            int[] res = new int[N];
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Введите {i}-ый элемент");
                res[i] = GetUserInput(int.MinValue, int.MaxValue);
            }
            return res;
        }
        public static void Main()
        {
            /*
            int[] arr = InputArr();
            Console.WriteLine("1. Поиск в массиве \n2. Сортировка массива ");
            int C = GetUserInput(1, 2);
            if (C == 1)
            {
                FinderInArray<int> finder = new(arr);
                Console.WriteLine("Введите искомый элемент");
                int example = GetUserInput(int.MinValue, int.MaxValue);
                Console.WriteLine("1. Линейный поиск\n2. Бинарный поиск\n3. Интерполяционный поиск" +
                    "\n4. Эксполяционный поиск");
                int C2 = GetUserInput(1, 4);
                switch(C2)
                {
                    case 1:
                        Console.WriteLine(finder.LinearSearch(example));
                        break;
                    case 2:
                        Console.WriteLine(finder.BinarySearch(example));
                        break;
                    case 3:
                        Console.WriteLine(FinderInArray<int>.InterpolateSearch(example, arr));
                        break;
                    case 4:
                        Console.WriteLine(FinderInArray<int>.ExponentialSearch(example, arr));
                        break;

                } 
            } else
            {
                Sorter<int> srtr = new(arr);
                Console.WriteLine("1. Сортировка Пузырьком\n2. Сортировка простыми вставками\n3. Сортировка выбором" +
                    "\n4. Сортировка Шелла" + "\n5. Быстрая сортировка" + "\n6. Пирамидальная сортировка");
                int C2 = GetUserInput(1, 6);
                switch (C2)
                {
                    case 1:
                        srtr.BubbleSort();
                        break;
                    case 2:
                        srtr.InsertSort();
                        break;
                    case 3:
                        srtr.SelectSort();
                        break;
                    case 4:
                        srtr.ShellSort();
                        break;
                    case 5:
                        srtr.FastSort();
                        break;
                    case 6:
                        srtr.HeapSort();
                        break;

                }

                for (int i = 0; i < srtr.Count; i++)
                    Console.Write(srtr[i] + " ");
                Console.WriteLine();
            }
            */
            int[] numbers = { 1, 2, 5, 6, 8, 10, 12, 150 };
            FinderInArray<int> finderInArray = new FinderInArray<int>(numbers);

            Console.WriteLine(finderInArray.LinearSearch(2)); ;
            Console.WriteLine(finderInArray.BinarySearch(6));
            Console.WriteLine(FinderInArray<int>.InterpolateSearch(12, numbers));
            Console.WriteLine(FinderInArray<int>.ExponentialSearch(150, numbers));


            Sorter<int> sorter = new Sorter<int>(numbers);

            sorter.Shuffle();
            for (int i = 0; i < numbers.Length; i++)
                Console.Write(numbers[i] + " ");
            Console.WriteLine();


            sorter.BubbleSort();
            for (int i = 0; i < numbers.Length; i++)
                Console.Write(numbers[i] + " ");
            Console.WriteLine();
            sorter.Shuffle();

            sorter.InsertSort();
            for (int i = 0; i < numbers.Length; i++)
                Console.Write(numbers[i] + " ");
            Console.WriteLine();
            sorter.Shuffle();


            sorter.FastSort();
            for (int i = 0; i < numbers.Length; i++)
                Console.Write(numbers[i] + " ");
            Console.WriteLine();
            sorter.Shuffle();


            sorter.HeapSort();
            for (int i = 0; i < numbers.Length; i++)
                Console.Write(numbers[i] + " ");
            Console.WriteLine();
            sorter.Shuffle();


            sorter.ShellSort();
            for (int i = 0; i < numbers.Length; i++)
                Console.Write(numbers[i] + " ");
            Console.WriteLine();
            sorter.Shuffle();


            sorter.SelectSort();
            for (int i = 0; i < numbers.Length; i++)
                Console.Write(numbers[i] + " ");
            Console.WriteLine();
            sorter.Shuffle();

        }
    }
}