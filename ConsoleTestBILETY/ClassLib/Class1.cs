using System.Linq;

namespace ClassLib
{
    public class Theme
    {
        public string Value { get; }
        public Theme (string Theme)
        {
            this.Value = Theme;
        }
        public override string ToString()
        {
            return this.Value;
        }
    }
    public class Task
    {
        public enum TYPE { THEORY, PRACTISE, BLITZ, OTHER }
        
        public int Difficulty { get; }
        public TYPE Type { get; }
        public Theme Theme { get; }
        public Task(int difficulty, TYPE type, Theme theme)
        {
            this.Difficulty = difficulty;
            this.Type = type;
            this.Theme = theme;
        }
        public Task(int difficulty, string type, string theme)
        {
            this.Difficulty = difficulty;
            this.Type = DefineType(type);
            this.Theme = new Theme(theme);
        }

        private TYPE DefineType(string type)
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
        public override string ToString()
        {
            return $"Задача по теме \"{this.Theme.ToString()}\": " +
                $"сложность {this.Difficulty}, тип {this.Type}.";
        }

    }

    public class Ticket
    {
        public Task[] Tasks { get; }
        public int TasksAmount { get; }
        public double DifficultyLevel { get; }
        public Ticket(Task[] Tasks)
        {
            this.Tasks = Tasks;
            this.TasksAmount = Tasks.Length;
            this.DifficultyLevel = CalcDifficultyLevel();
        }
        public double CalcDifficultyLevel()
        {
            double difficultyLevel = 0;
            foreach (Task t in Tasks)
            {
                difficultyLevel += t.Difficulty;
            }
            return difficultyLevel / TasksAmount;
        }

        public override string ToString()
        {
            string res = $"Билет на {this.TasksAmount} задач средней сложности {DifficultyLevel.ToString()}.\n";
            int counter = 1;
            foreach (Task t in Tasks)
            {
                res += $"{counter}.";
                res += (t.ToString());
                res += "\n";
                counter++;
            }
            return res;
        }

    }

    public class TicketGenerator
    {
        public int AmountOfTasks { get; }
        public (double, double) DifficultyInterval { get; }
        public (Task.TYPE, int)[] Values { get; }

        public Task[] TaskBase;

        private static List<Theme> usedThemes = new List<Theme>();

        public TicketGenerator(int amountOfTasks, (double, double) difficultyInterval,
            (Task.TYPE, int)[] values, Task[] TaskBase
            )
        {
            this.AmountOfTasks = amountOfTasks;
            this.DifficultyInterval= difficultyInterval;
            this.Values = values;
            this.TaskBase = TaskBase;
        }
        public TicketGenerator(int amountOfTasks, double difficultyIntervalStart, double difficultyIntervalEnd,
            (Task.TYPE, int)[] values, Task[] TaskBase
            )
        {
            this.AmountOfTasks = amountOfTasks;
            this.DifficultyInterval = (difficultyIntervalStart, difficultyIntervalEnd);
            this.Values = values;
            this.TaskBase = TaskBase;
        }
        public Ticket GenerateTicket()
        {
            List<Task> tasks = new List<Task>();


            for (int i = 0; i < Values.Length; i++)
            {
                Task.TYPE requiredType = Values[i].Item1;
                int requiredAmountOfTasks = Values[i].Item2;

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
                   throw new Exception("Unable to generate ticket with defined params");
            }

            return new Ticket(tasks.ToArray());
        }

        private bool InDifficultyInterval(int k)
        {
            return k <= DifficultyInterval.Item2 && k >= DifficultyInterval.Item1;
        }
    }

}