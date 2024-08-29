using ClassLib;
using Task = ClassLib.Task;

namespace ConsoleTest
{
    class CT
    {

        public static void Main()
        {
            Task[] tasks =
            {
                new Task(2, "практика", "AVL"),
                new Task(1, "теория", "красно черные деревья"),
                new Task(3, "практика", "DFS"),
                new Task(3, "практика", "Стэк")
            };
            TicketGenerator tg = new TicketGenerator(1, (1, 4),
                new (ClassLib.Task.TYPE, int)[] { (ClassLib.Task.TYPE.PRACTISE, 1) },
                tasks
                );
            Console.WriteLine(tg.GenerateTicket().ToString());
            Console.WriteLine(tg.GenerateTicket().ToString());
        }
    }
}