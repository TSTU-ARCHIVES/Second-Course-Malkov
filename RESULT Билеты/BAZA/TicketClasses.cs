using System.Collections.Generic;
using System;
using System.Linq;
using System.Collections;
using System.Drawing;

namespace ClassLib
{
    /// <summary>
    /// Класс-оболочка для темы задания
    /// </summary>
    public class Theme
    {
        /// <summary>
        /// Собственно тема задания
        /// </summary>
        public string Value { 
            get { return this._Value; } 
        }
        /// <summary>
        /// 
        /// </summary>
        private string _Value;
        /// <summary>
        /// Конструктор, создающий оболочку на основе 
        /// темы в строковом виде
        /// </summary>
        /// <param name="Theme">Строка отображающая тему</param>
        public Theme(string Theme)
        {
            this._Value = Theme[0] + Theme.Substring(1);
        }
        /// <summary>
        /// Отображает тему в виде строки
        /// </summary>
        /// <returns>Строка, представляющая тему</returns>
        public override string ToString()
        {
            return this._Value;
        }
    }
    /// <summary>
    /// Класс, отображающий сведения о задании
    /// </summary>
    public class Task : IComparable<Task>
    {
        /// <summary>
        /// Перечисление, отображающее тип задания
        /// </summary>
        public enum TYPE { THEORY, PRACTISE, BLITZ, OTHER }
        /// <summary>
        /// Сложность задания
        /// </summary>
        public int Difficulty { get; }
        /// <summary>
        /// Тип задания
        /// </summary>
        public TYPE Type { get; }
        /// <summary>
        /// Тема задания
        /// </summary>
        public Theme Theme { get; }
        /// <summary>
        /// Конструктор, создающий экземпляр класса на основе
        /// данной сложности, типа и темы
        /// </summary>
        /// <param name="difficulty">Данная сложность задания</param>
        /// <param name="type">Данный тип задания</param>
        /// <param name="theme">Данная тема задания</param>
        public Task(int difficulty, TYPE type, Theme theme)
        {
            this.Difficulty = difficulty;
            this.Type = type;
            this.Theme = theme;
        }
        /// <summary>
        /// Конструктор, создающий экземпляр класса на основе
        /// данной сложности, типа и темы
        /// </summary>
        /// <param name="difficulty">Данная сложность задания</param>
        /// <param name="type">Данный тип задания</param>
        /// <param name="theme">Данная тема задания</param>
        public Task(int difficulty, string type, string theme)
        {
            this.Difficulty = difficulty;
            this.Type = DefineType(type);
            this.Theme = new Theme(theme);
        }
        /// <summary>
        /// Определет тип задания на основе строки
        /// </summary>
        /// <param name="type">Проверяемая строка</param>
        /// <returns>Тип задания</returns>
        public static TYPE DefineType(string type)
        {
            if (type.ToLower() == "теория")
            {
                return TYPE.THEORY;
            }
            else if (type.ToLower() == "практика")
            {
                return TYPE.PRACTISE;
            }
            else if (type.ToLower() == "блитц-опрос")
            {
                return TYPE.BLITZ;
            }
            else
            {
                return TYPE.OTHER;
            }
        }
        /// <summary>
        /// Конвертирует тип задания в строку
        /// </summary>
        /// <param name="t">Конвертируемый тип</param>
        /// <returns>Тип задания в виде строки</returns>
        public static string ConvertType(TYPE t)
        {
            if (t == TYPE.THEORY )
            {
                return "Теория";
            }
            else if (t == TYPE.PRACTISE)
            {
                return "Практика";
            }
            else if (t == TYPE.BLITZ)
            {
                return "Блитц-опрос";
            }
            else
            {
                return "Неизвестный тип задания";
            }
        }
        /// <summary>
        /// Возвращает строку, отображающую данные о текущем задании
        /// </summary>
        /// <returns>Строка, отображающая данные о текущем задании</returns>
        public override string ToString()
        {
            return $"Задача по теме \"{this.Theme.ToString()}\": " +
                $"сложность {this.Difficulty}, тип {ConvertType(this.Type)}.";
        }

        public int CompareTo(Task other)
        {
            return this.Difficulty.CompareTo(other.Difficulty);
        }
    }
    /// <summary>
    /// Класс, отображающий билет
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// Массив заданий в билете
        /// </summary>
        public Task[] Tasks { get; }
        /// <summary>
        /// Количество заданий в билете
        /// </summary>
        public int TasksAmount { get; }
        /// <summary>
        /// Средний уровень сложности задания в билете
        /// </summary>
        public double DifficultyLevel { get; }
        /// <summary>
        /// Создает экземпляр класса на основе массива заданий
        /// </summary>
        /// <param name="Tasks"></param>
        public Ticket(Task[] Tasks)
        {
            this.Tasks = Tasks;
            this.TasksAmount = Tasks.Length;
            this.DifficultyLevel = CalcDifficultyLevel();
        }
        /// <summary>
        /// Подсчитывает средний уровень сложности заданий
        /// </summary>
        /// <returns></returns>
        public double CalcDifficultyLevel()
        {
            double difficultyLevel = 0;
            foreach (Task t in Tasks)
            {
                difficultyLevel += t.Difficulty;
            }
            return difficultyLevel / TasksAmount;
        }
        /// <summary>
        /// Отображает строковое предстваление билета
        /// </summary>
        /// <returns>Строковое представление текущего билета</returns>
        public override string ToString()
        {
            string res = $"Билет на {this.TasksAmount} задач средней сложности " +
                $"{DifficultyLevel.ToString("F3")}.\r\n";
            int counter = 1;
            foreach (Task t in Tasks)
            {
                res += $"{counter}.";
                res += (t.ToString());
                res += "\r\n";
                counter++;
            }
            return res;
        }

    }
    /// <summary>
    /// Класс, позволяющий осуществлять генерацию билетов
    /// </summary>
    public class TicketGenerator
    {
        /// <summary>
        /// Количество заданий в генерируемых билетах
        /// </summary>
        public int AmountOfTasks { get; }
        /// <summary>
        /// Интервал сложности заданий в генерируемых билетах
        /// </summary>
        public (double, double) DifficultyInterval { get; }
        /// <summary>
        /// Массив, хранящий данные в формате 
        /// (Тип задания, необходимое количество заданий этого типа)
        /// </summary>
        public (Task.TYPE, int)[] Values { get; }
        /// <summary>
        /// Массив заданий
        /// </summary>
        public Task[] TaskBase;
        /// <summary>
        /// Список использованных тем
        /// </summary>
        private static List<Theme> usedThemes = new List<Theme>();
        /// <summary>
        /// Конструктор, создающий генератор класса на основе всех данных
        /// и перемешивающий массив заданий
        /// </summary>
        /// <param name="amountOfTasks">
        /// Необходимое количество заданий в билете
        /// </param>
        /// <param name="difficultyIntervalStart">
        /// Начало интервала сложности заданий в билете
        /// </param>
        /// <param name="difficultyIntervalEnd">
        /// Конец интервала сложности заданий в билете</param>
        /// <param name="values">
        /// Массив, хранящий данные в формате 
        /// (Тип задания, необходимое количество заданий этого типа)
        /// </param>
        /// <param name="TaskBase">
        /// Массив всех заданий
        /// </param>
        public TicketGenerator(
                int amountOfTasks, double difficultyIntervalStart,
                double difficultyIntervalEnd,
                (Task.TYPE, int)[] values, Task[] TaskBase
            )
        {
            this.AmountOfTasks = amountOfTasks;
            this.DifficultyInterval = (difficultyIntervalStart, difficultyIntervalEnd);
            this.Values = values;
            this.TaskBase = TaskBase;
        }

        //public IEnumerator<Ticket> GetEnumerator()
        //{
        //    yield return GenerateTicket();
        //}

        /// <summary>
        /// Генерирует билет, если это возможно
        /// </summary>
        /// <returns>Сгенерированный по заданным параметрам билет</returns>
        /// <exception cref="Exception">
        /// Исключение, возникающее, если генерация билета невозможна
        /// </exception>
        public Ticket GenerateTicket()
        {
            List<Task> tasks = new List<Task>();


            for (int i = 0; i < Values.Length; i++)
            {
                Task.TYPE requiredType = Values[i].Item1;
                int requiredAmountOfTasks = Values[i].Item2;

                LinkedList<Task> tasks2 = new LinkedList<Task>();
                for (int j = 0; j < TaskBase.Length; j++)
                {
                    if (TaskBase[j].Type == requiredType)
                    {
                        
                    }
                }

                List<Task> tasks1 = TaskBase
                    .Where<Task>(tsk => tsk.Type == requiredType && InDifficultyInterval(tsk.Difficulty))
                    .ToList<Task>();

                int counter = 0;
                foreach (Task tsk in tasks1)
                {
                    if (counter == requiredAmountOfTasks)
                        break;
                    if (!usedThemes.Contains(tsk.Theme))
                    {
                        tasks.Add(tsk);
                        usedThemes.Add(tsk.Theme);
                        counter++;
                    }
                }
                if (counter == requiredAmountOfTasks)
                    continue;
                else
                    throw new Exception("Невозможна генерация билетов с данными параметрами: " +
                        "невозможно найти требуемое количество заданий типа " + requiredType +
                        "в интервале сложности [" + DifficultyInterval.Item1 + " ; " +
                        DifficultyInterval.Item2 + "]");
            }

            if (tasks.Count != AmountOfTasks)
                throw new Exception("Невозможна генерация билетов с данными параметрами: " +
                    "некорректное количество заданий");
            return new Ticket(tasks.ToArray());
        }
        /// <summary>
        /// Проверяет, находится ли данное число в интервале сложности
        /// </summary>
        /// <param name="k">Проверяемое число</param>
        /// <returns>
        /// True: число находится в интервале сложности
        /// False: все остальные случаи
        /// </returns>
        private bool InDifficultyInterval(int k)
        {
            return k <= DifficultyInterval.Item2 && k >= DifficultyInterval.Item1;
        }
        /// <summary>
        /// Перетасовывет заданную коллекцию
        /// </summary>
        /// <param name="collection">
        /// Перетасовываемая коллекция
        /// </param>
        private static void Sort(IList<Task> collection)
        {
            int len = collection.Count;
            for (int i = 0; i < len; i++)
            {
                int j = i;
                while (j > 0 && collection[j].CompareTo(collection[j - 1]) <= 0)
                {
                    Task temp = collection[j];
                    collection[j] = collection[j - 1];
                    collection[j-1] = temp;
                    j--;
                }
            }
        }

    }

}