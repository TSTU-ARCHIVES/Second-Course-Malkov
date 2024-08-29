using System.Text;
using static System.Net.WebRequestMethods;

namespace P
{
    /// <summary>
    /// Класс, позволяющий работать со строками
    /// </summary>
    public static class StringMethods
    {
        /// <summary>
        /// Позволяет найти индекс первой встречи подстроки в данной строке
        /// </summary>
        /// <param name="srcStr">Строка, в которой осуществляется поиск</param>
        /// <param name="targetStr">Искомая строка</param>
        /// <returns>Индекс первой встречи подстроки в данной строке
        /// либо -1 в случае если подстроки нет в данной строке</returns>
        public static int NaiveSubstringFind(string srcStr, string targetStr)
        {
            int len = targetStr.Length;
            for (int i = 0; i < srcStr.Length - len; i++)
            {
                bool find = true;
                for (int j = 0; j < len; j++)
                {
                    if (srcStr[i + j] != targetStr[j])
                    {
                        find = false;
                        break;
                    }
                }
                if (find)
                    return i;
            }
            return -1;
        }
        /// <summary>
        /// Класс, позволяющий считать хэш-функцию
        /// для алгоритма Рабина
        /// </summary>
        private static class RabineHashF
        {
            public const int p = 997;
            public const int r = int.MaxValue;
            /// <summary>
            /// Считает значение хэш-функции для данной строки
            /// </summary>
            /// <param name="str">Данная строка</param>
            /// <returns>Значение хэш-функции для данной строки</returns>
            public static long RabineHash(string str)
            {
                long res = 0;

                for (int i = 0; i<str.Length;i++)
                {
                    res += ((int)(char)str[i] * ((int)Math.Pow(p, i))) % r;
                }
                return res % r;
            }
            /// <summary>
            /// Считает значение хэш функции для символа
            /// </summary>
            public static int RabineHash(char c)
            {
                return (int)c;
            }
            /// <summary>
            /// Позволяет пересчитать значение хэш-функции
            /// </summary>
            public static long Recalc(long starting, string scrStr, int i, int len)
            {
                long res = starting;
                res -= ((int)(char)scrStr[i]);
                res /= p;
                res += ((int)(char)scrStr[i + len] * ((int)Math.Pow(p, len - 1))) % r;
                RabineHash(scrStr.Substring(i, len));
                return res % r;
            }

        }
        /// <summary>
        /// Осуществляет поиск подстроки в данной алгоритмом Рабина
        /// </summary>
        /// <param name="srcStr">Строка, в которой осуществляется поиск</param>
        /// <param name="targetStr">Искомая строка</param>
        /// <returns>Индекс первой встречи подстроки в данной строке
        /// либо -1 в случае если подстроки нет в данной строке</returns>
        public static int RabineFind(string srcStr, string targetStr)
        {
            long targetHash = RabineHashF.RabineHash(targetStr);
            int len = targetStr.Length;
            long startingHash = RabineHashF.RabineHash(srcStr.Substring(0, len));
            for (int i = 0; i < srcStr.Length - len; i++)
            {
                if (startingHash == targetHash)
                {
                    bool correct = true;
                    for (int j = 0; j < len; j++)
                    {
                        if (srcStr[i + j] != targetStr[j])
                        {
                            correct = false;
                            break;
                        }
                    }
                    if (correct)
                        return i;
                }
                startingHash = RabineHashF.Recalc(startingHash, srcStr, i, len);
            }
            return -1;
        }
        /// <summary>
        /// Префикс функция для алгоритма КМП
        /// </summary>
        private static int[] PrefixFunction(string s)
        {
            int[] result = new int[s.Length];
            int i = 1;
            int j = 0;

            while (i < s.Length)
            {
                if (s[j] == s[i])
                {
                    result[i] = j + 1;
                    i += 1;
                    j += 1;
                }
                else
                {
                    if (j == 0)
                    {
                        result[i] = 0;
                        i += 1;
                    }
                    else
                    {
                        j = result[j - 1];
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Осуществляет поиск подстроки с помощью алгоритма КМП
        /// </summary>
        /// <param name="srcStr">Строка, в которой осуществляется поиск</param>
        /// <param name="targetStr">Искомая строка</param>
        /// <returns>Индексы встречи подстроки в данной строке
        /// либо -1 в случае если подстроки нет в данной строке</returns>
        public static int[] KMP(string srcStr, string targetStr)
        {
            int[] P = PrefixFunction(targetStr);
            List<int> result = new List<int>();
            int n = srcStr.Length;
            int m = targetStr.Length;

            int i = 0;
            int j = 0;

            // лилилосьлилилилась
            //           лилила
            // [0, 0, 1, 2, 3]
            while (i < n)
            {
                if (srcStr[i] == targetStr[j])
                {
                    i += 1;
                    j += 1;
                    if (j == m)
                    {
                        result.Add(i - j);
                        j -= 1;
                    }
                }
                else
                {
                    if (j > 0) 
                    { 
                        j = P[j - 1]; 
                    }
                    else 
                    { 
                        i += 1; 
                    }
                }
            }
            if (result.Count == 0)
                result.Add(-1);
            return result.ToArray();
        }
        /// <summary>
        /// Класс, содержащий морфемы для стемминга
        /// </summary>
        private static class StammingConstrains
        {
            /// <summary>
            /// Массив приставок
            /// </summary>
            public static string[] Pristavki =
            {
                "пере", "подо", "о", "в", "с", "у",
                "а","на", "за",
                "о", "по" , "со" , "до" , "во" , "от", "об",
                "вы" , "вз", "из" , "ис" ,
                "о", "обо", "под", "воз",
                "а", "над", "раз","рас",
                "при", "пре", "изо", "пере", "про"
            };
            /// <summary>
            /// Массив окончаний
            /// </summary>
            public static string[] Okonchaniya =
            {
                "ер", "ик", "ок", "ук", "ак", "ов", 
                "ев", "ий", "их", "ый", "ой", "ая", 
                "яя", "ея", "ия", "ым", "им", "ем",
                "ам", "ям", "ею", "ию", "ою", "аю",
                "яю", "ей", "ий", "ой", "ый", "ая",
                "яя", "ее", "ие", "ое", "ые", "ть",
                "тся", "му", "ми", "мя" 
            };
            /// <summary>
            /// Массив суффиксов
            /// </summary>
            public static string[] Suffiksy =
            {
                 "один", "два", "три", "четыре", "пять", 
                "десять", "сто", "тысяча", "миллион", 
                "миллиард", "ы", "и", "ах", "ях", "а", 
                "я", "у", "ю", "у", "ю", "а", "я", "ом",
                "ой", "е", "и", "ый", "ой", "ий", "ая", 
                "ое", "ие", "ейший", "ейшая", "ейшее", 
                "ее", "ей", "ого", "его", "их", "ых", 
                "ой", "его", "их", "ем", "ете", "ут", 
                "ю", "ешь", "ет", "ем", "ете", "ут", "л", 
                "ла", "ло", "ли", "у", "ешь", "ет", "и", 
                "ите", "не", "ни", "я", "вши", "ши", "ший",
                "вш", "ющ", "о", "е", "ей", "ее", "ым", 
                "им", "й", "го", "му", "м", "х", "я", "е",
                "и", "его", "их" , "то" , "нибудь",
                "ни", "некто", "ничто", "ой", "его", "их", 
                "ся","сь", "ин", "ов", "ев", "енн"
            };

        }
        /// <summary>
        /// Осуществляет примитивный стэмминг данного слова
        /// </summary>
        /// <param name="word">Слово</param>
        /// <returns>Основа слова</returns>
        public static string Stamm(string word)
        {
            Array.Sort(StammingConstrains.Pristavki, (x, y) => -x.Length.CompareTo(y.Length));
            Array.Sort(StammingConstrains.Suffiksy, (x, y) => -x.Length.CompareTo(y.Length));
            Array.Sort(StammingConstrains.Okonchaniya, (x, y) => -x.Length.CompareTo(y.Length));

            string stammedWord = word;
            foreach (string rule in StammingConstrains.Okonchaniya)
            {
                if (stammedWord.EndsWith(rule))
                {
                    stammedWord = stammedWord.Remove(stammedWord.Length - rule.Length - 1);
                    break;
                }
            }
            foreach (string rule in StammingConstrains.Suffiksy)
            {
                if (stammedWord.EndsWith(rule))
                {
                    stammedWord = stammedWord.Remove(stammedWord.Length - rule.Length);
                    break;
                }
            }
            foreach (string rule in StammingConstrains.Suffiksy)
            {
                if (stammedWord.EndsWith(rule))
                {
                    stammedWord = stammedWord.Remove(stammedWord.Length - rule.Length);
                    break;
                }
            }
            foreach (string rule in StammingConstrains.Suffiksy)
            {
                if (stammedWord.EndsWith(rule))
                {
                    stammedWord = stammedWord.Remove(stammedWord.Length - rule.Length);
                    break;
                }
            }
            foreach (string rule in StammingConstrains.Pristavki)
            {
                if (stammedWord.StartsWith(rule))
                {
                    stammedWord = stammedWord.Substring(rule.Length);
                    break;
                }
            }

            return stammedWord;
        }


    }

    public static class IntArrExtention {
        public static string GetFormatted(this int[] arr)
        {
            StringBuilder sb = new();
            foreach(int i in arr)
            {
                sb.Append(i);
                sb.Append(" ");
            }
            return sb.ToString();
        }
    }

    class Program
    {
        enum OPTIONS
        {
            NAIVE_FIND = 1, RABINE_FIND, KMP_FIND, STAMM
        }
        static Dictionary<OPTIONS, Func<string, string, string>> stringMethos = new() {
            {OPTIONS.NAIVE_FIND, (src, find) => StringMethods.NaiveSubstringFind(src, find).ToString() },
            {OPTIONS.RABINE_FIND,  (src, find) => StringMethods.RabineFind(src, find).ToString()},
            {OPTIONS.KMP_FIND, (src, find) => StringMethods.KMP(src, find).GetFormatted() },
            {OPTIONS.STAMM, (src, find) => StringMethods.Stamm(src) },
        };
        public static void Main()
        {
            int c;
            string scrStr = "", findStr = "";
            Console.WriteLine("Выберите действие");
            Console.WriteLine("1. Наивный поиск подстроки\n" +
                "2. Поиск подстроки методом Рабина\n" +
                "3. Поиск подстроки методом КМП\n" +
                "4. Примитивный стэмминг\n ");
            if (!int.TryParse(Console.ReadLine(), out c) || c < 1 || c > 4)
            {
                Console.WriteLine("Некорректный ввод");
                return;
            }
            Console.WriteLine("Введите обрабатываемую строку");
            scrStr = Console.ReadLine();
            if (ReferenceEquals(scrStr, null))
            {
                Console.WriteLine("Некорректный ввод");
                return;
            }
            if (c == 1 || c ==2 || c == 3)
            {
                Console.WriteLine("Введите искомую строку");
                findStr = Console.ReadLine();
                if (ReferenceEquals(findStr, null))
                {
                    Console.WriteLine("Некорректный ввод");
                    return;
                }
            }
            Console.WriteLine(stringMethos[(OPTIONS)c].Invoke(scrStr, findStr));
        }
    }
}