using Lab6to8;
using System.Collections.Generic;

namespace P
{
    
    public static class Program
    {
        public static int PrintStructures()
        {
            Console.WriteLine("1.Стэк\n" + "2.Очередь обыконовенная\n" 
                + "3.Круговая очередь\n" + "4.Приоритетная очередь\n" +
                "5.Дэк\n" + "6.Связный список\n" + "7.Двусвязный список\n");
            return GetCorrectUserInput(1, 7);
        }
        public static int GetCorrectUserInput(int from, int to)
        {
            int res;
            Console.WriteLine($"Введите число от {from} до {to}");
            if (!int.TryParse(Console.ReadLine(), out res) || res > to || res < from)
            {
                Console.WriteLine("Некорректный ввод");
                return from - 1;
            }
            return res;
        }

        public static void HandleStack()
        {
            MyStack<int> stack = new MyStackOnNodes<int>();
            Console.WriteLine("Выберите действие");
            Console.WriteLine("1. Создать пустой\n" + "2. Вывести полностью с удалением\n" + "3. Push\n"
                + "4. Pop\n" + "5. Peek\n" + "6. Завершить работу\n");
            int C = GetCorrectUserInput(1, 6);
            if (C == 0)
                return;
            while(C!=6)
            {
                switch(C)
                {
                    case 1:
                        stack = new MyStackOnNodes<int>();
                        break;
                    case 2:
                        while (!stack.IsEmpty())
                            Console.WriteLine(stack.Pop().ToString());
                        break;
                    case 3:
                        stack.Push(GetCorrectUserInput(int.MinValue, int.MaxValue));
                        break;
                    case 4:
                        if (!stack.IsEmpty())
                            Console.WriteLine(stack.Pop());
                        else
                            Console.WriteLine("Стэк пуст");
                        break;
                    case 5:
                        if (!stack.IsEmpty())
                            Console.WriteLine(stack.Peek());
                        else
                            Console.WriteLine("Стэк пуст");
                        break;
                }
                Console.WriteLine("Выберите действие");
                Console.WriteLine("1. Создать пустой\n" + "2. Вывести полностью с удалением\n" + "3. Push\n"
                    + "4. Pop\n" + "5. Peek\n" + "6. Завершить работу\n");
                C = GetCorrectUserInput(1, 6);
            }
        }

        public static void HandleQueue()
        {
            MyQueue<int> queue = new MyQueueOnNodes<int>();
            Console.WriteLine("Выберите действие");
            Console.WriteLine("1. Создать пустую\n" + "2. Вывести полностью с удалением\n" + "3. Enqueue\n"
                + "4. Dequque\n" + "5. Peek\n" + "6. Завершить работу\n");
            int C = GetCorrectUserInput(1, 6);
            if (C == 0)
                return;
            while (C != 6)
            {
                switch (C)
                {
                    case 1:
                        queue = new MyQueueOnNodes<int>();
                        break;
                    case 2:
                        while (!queue.IsEmpty())
                            Console.WriteLine(queue.Dequeue().ToString());
                        break;
                    case 3:
                        queue.Enqueue(GetCorrectUserInput(int.MinValue, int.MaxValue));
                        break;
                    case 4:
                        Console.WriteLine(queue.Dequeue());
                        break;
                    case 5:
                        Console.WriteLine(queue.GetCurrent());
                        break;
                }
                Console.WriteLine("Выберите действие");
                Console.WriteLine("1. Создать пустую\n" + "2. Вывести полностью с удалением\n" + "3. Enqueue\n"
                    + "4. Dequque\n" + "5. Peek\n" + "6. Завершить работу\n");
                C = GetCorrectUserInput(1, 6);
            }
        }

        public static void HandleCycledQueue()
        {
            MyCyclingQueue<int> queue;
            Console.WriteLine("Введите размер буффера");
            queue = new(GetCorrectUserInput(0, 100));
            Console.WriteLine("Выберите действие");
            Console.WriteLine("1. Создать пустую\n" + "2. Вывести полностью с удалением\n" + "3. Enqueue\n"
                + "4. Dequque\n" + "5. Peek\n" + "6. Завершить работу\n");
            int C = GetCorrectUserInput(1, 6);
            if (C == 0)
                return;
            while (C != 6)
            {
                switch (C)
                {
                    case 1:
                        Console.WriteLine("Введите размер буффера");
                        queue = new(GetCorrectUserInput(0, 100));
                        break;
                    case 2:
                        while (!queue.IsEmpty())
                            Console.WriteLine(queue.Dequeue().ToString());
                        break;
                    case 3:
                        queue.Enqueue(GetCorrectUserInput(int.MinValue, int.MaxValue));
                        break;
                    case 4:
                        Console.WriteLine(queue.Dequeue());
                        break;
                    case 5:
                        Console.WriteLine(queue.GetCurrent());
                        break;
                }
                Console.WriteLine("Выберите действие");
                Console.WriteLine("1. Создать пустую\n" + "2. Вывести полностью с удалением\n" + "3. Enqueue\n"
                    + "4. Dequque\n" + "5. Peek\n" + "6. Завершить работу\n");
                C = GetCorrectUserInput(1, 6);
            }
        }

        public static void HandlePriorityQueue()
        {
            MyPriorityQueue<string, int> priorityQueue = new();
            Console.WriteLine("Выберите действие");
            Console.WriteLine("1. Создать пустую\n" + "2. Вывести полностью с удалением\n" + "3. Enqueue\n"
                + "4. Dequque\n" + "5. Peek\n" + "6. Завершить работу\n");
            int C = GetCorrectUserInput(1, 6);
            if (C == 0)
                return;
            while (C != 6)
            {
                switch (C)
                {
                    case 1:
                        priorityQueue = new();
                        break;
                    case 2:
                        while (!priorityQueue.IsEmpty())
                            Console.WriteLine(priorityQueue.Dequeue().ToString());
                        break;
                    case 3:
                        Console.WriteLine("Введите элемент и его приоритет");
                        priorityQueue.Enquque(Console.ReadLine(),GetCorrectUserInput(int.MinValue, int.MaxValue));
                        break;
                    case 4:
                        Console.WriteLine(priorityQueue.Dequeue());
                        break;
                    case 5:
                        Console.WriteLine(priorityQueue.GetCurrent());
                        break;
                }
                Console.WriteLine("Выберите действие");
                Console.WriteLine("1. Создать пустую\n" + "2. Вывести полностью с удалением\n" + "3. Enqueue\n"
                    + "4. Dequque\n" + "5. Peek\n" + "6. Завершить работу\n");
                C = GetCorrectUserInput(1, 6);
            }
        }


        public static void HandleDeque()
        {
            MyDequeue<int> deque = new MyDequeueOnArray<int>(100);
            Console.WriteLine("Выберите действие");
            Console.WriteLine("1. Создать пустой\n" + "2. Вывести полностью с начала с удалением\n" + "3. Push в конец\n"
                + "4. Pop последний\n" + "5. Peek последний\n" +
                "6. Push в начало\n" + "7. Pop первый\n" + "8. Peek первый\n" + 
                "9. Вывести полностью с конца с удалением\n" +
                "10. Завершить работу\n");
            int C = GetCorrectUserInput(1, 10);
            if (C == 0)
                return;
            while (C != 10)
            {
                switch (C)
                {
                    case 1:
                        deque = new MyDequeueOnArray<int>(100);
                        break;
                    case 2:
                        while (!deque.IsEmpty())
                            Console.WriteLine(deque.PopFirst().ToString());
                        break;
                    case 3:
                        deque.InsertLast(GetCorrectUserInput(int.MinValue, int.MaxValue));
                        break;
                    case 4:
                        if (!deque.IsEmpty())
                            Console.WriteLine(deque.PopLast());
                        else
                            Console.WriteLine("Дэк пуст");
                        break;
                    case 5:
                        if (!deque.IsEmpty())
                            Console.WriteLine(deque.GetLast());
                        else
                            Console.WriteLine("Дэк пуст");
                        break;
                    case 6:
                        deque.InsertFirst(GetCorrectUserInput(int.MinValue, int.MaxValue));
                        break;
                    case 7:
                        if (!deque.IsEmpty())
                            Console.WriteLine(deque.PopFirst());
                        else
                            Console.WriteLine("Дэк пуст");
                        break;
                    case 8:
                        if (!deque.IsEmpty())
                            Console.WriteLine(deque.GetFirst());
                        else
                            Console.WriteLine("Дэк пуст");
                        break;
                    case 9:
                        while (!deque.IsEmpty())
                            Console.WriteLine(deque.PopLast());
                        break;
                }
                Console.WriteLine("Выберите действие");
                Console.WriteLine("1. Создать пустой\n" + "2. Вывести полностью с начала с удалением\n" + "3. Push в конец\n"
                    + "4. Pop последний\n" + "5. Peek последний\n" +
                    "6. Push в начало\n" + "7. Pop первый\n" + "8. Peek первый\n" +
                    "9. Вывести полностью с конца с удалением\n" +
                    "10. Завершить работу\n");
                C = GetCorrectUserInput(1, 10);
            }
        }
        public static void HandleDoubleLinkedList()
        {
            MyDoubleLinkedList<int> dblList = new();
            Console.WriteLine("Выберите действие");
            Console.WriteLine("1. Создать пустой\n" + "2. Вывести полностью с начала\n" + "3. Добавить в конец\n"
                + "4. Удалить последний\n" + 
                "5. Посмотреть последний\n" + "6. Добавить в начало\n" + "7. Удалить первый\n"+
                "8. Посмотреть первый\n" +
                "9. Вывести полностью с конца\n" + "10. Удалить по значению\n" +
                "11. Завершить работу\n");
            int C = GetCorrectUserInput(1, 11);
            if (C == 0)
                return;
            while (C != 11)
            {
                MyDoubleNode<int>? cur;
                switch (C)
                {
                    case 1:
                        dblList = new();
                        break;
                    case 2:
                        cur = dblList.First;
                        while (cur != null)
                        {
                            Console.WriteLine(cur.GetValue().ToString());
                            cur = cur.GetNext();
                        }
                        break;
                    case 3:
                        dblList.InsertLast(GetCorrectUserInput(int.MinValue, int.MaxValue));
                        break;
                    case 4:
                        dblList.DeleteLast();
                        break;
                    case 5:
                        Console.WriteLine(dblList.Last?.GetValue());
                        break;
                    case 6:
                        dblList.InsertFirst(GetCorrectUserInput(int.MinValue, int.MaxValue));
                        break;
                    case 7:
                        dblList.DeleteFirst();
                        break;
                    case 8:
                        Console.WriteLine(dblList.First?.GetValue());
                        break;
                    case 9:
                        cur = dblList.Last;
                        while (cur != null)
                        {
                            Console.WriteLine(cur.GetValue().ToString());
                            cur = cur.GetPrev();
                        }
                        break;
                    case 10:
                        dblList.DeleteByVal(GetCorrectUserInput(int.MinValue, int.MaxValue));
                        break;
                }
                Console.WriteLine("Выберите действие");
                Console.WriteLine("1. Создать пустой\n" + "2. Вывести полностью с начала\n" + "3. Добавить в конец\n"
                    + "4. Удалить последний\n" +
                    "5. Посмотреть последний\n" + "6. Добавить в начало\n" + "7. Удалить первый\n" +
                    "8. Посмотреть первый\n" +
                    "9. Вывести полностью с конца\n" + "10. Удалить по значению\n" +
                    "11. Завершить работу\n");
                C = GetCorrectUserInput(1, 11);
            }
        }

        public static void HandleLinkedList()
        {
            MyLinkedList<int> list = new();
            Console.WriteLine("Выберите действие");
            Console.WriteLine("1. Создать пустой\n" + "2. Вывести полностью с начала\n" + "3. Добавить в конец\n"
                + "4. Добавить в начало\n" + "5. Удалить первый\n" +
                "6. Посмотреть первый\n"  + "7. Удалить по значению\n" +
                "8. Завершить работу\n");
            int C = GetCorrectUserInput(1, 8);
            if (C == 0)
                return;
            while (C != 8)
            {
                MyNode<int>? cur;
                switch (C)
                {
                    case 1:
                        list = new();
                        break;
                    case 2:
                        cur = list.First;
                        while (cur != null)
                        {
                            Console.WriteLine(cur.GetValue().ToString());
                            cur = cur.GetNext();
                        }
                        break;
                    case 3:
                        list.InsertLast(GetCorrectUserInput(int.MinValue, int.MaxValue));
                        break;
                    case 4:
                        list.InsertFirst(GetCorrectUserInput(int.MinValue, int.MaxValue));
                        break;
                    case 5:
                        list.DeleteFirst();
                        break;
                    case 6:
                        Console.WriteLine(list.First?.GetValue());
                        break;
                    case 7:
                        list.DeleteByVal(GetCorrectUserInput(int.MinValue, int.MaxValue));
                        break;
                }
                Console.WriteLine("Выберите действие");
                Console.WriteLine("1. Создать пустой\n" + "2. Вывести полностью с начала\n" + "3. Добавить в конец\n"
                    + "4. Добавить в начало\n" + "5. Удалить первый\n" +
                    "6. Посмотреть первый\n" + "7. Удалить по значению\n" +
                    "8. Завершить работу\n");
                C = GetCorrectUserInput(1, 8);
            }
        }
        public static void Main()
        {
            /*
            MyDequeueOnNodes<int> myDeque = new();
            myDeque.InsertLast(12);
            myDeque.InsertLast(13);
            myDeque.InsertLast(14);
            myDeque.InsertFirst(11);
            myDeque.InsertFirst(10);
            myDeque.InsertFirst(9);
            Console.WriteLine(myDeque.PopFirst());
            while (!myDeque.IsEmpty())
                Console.WriteLine(myDeque.PopLast());
            
            */
            MyList<int> myList = new();
            Console.WriteLine(myList);
            for (int i = 0; i <= 10; i++)
            {
                myList.Add(i);
            }
            Console.WriteLine(myList);
            Console.WriteLine(myList.Count);
            for (int i = 0; i <= 10; i++)
            {
                myList.Add(i);
            }
            Console.WriteLine(myList);
            Console.WriteLine(myList.Count);
            myList.RemoveAt(5);
            myList.RemoveAt(5);
            Console.WriteLine(myList);
            Console.WriteLine(myList.Count);
            myList.Remove(10);
            myList.Remove(10);
            Console.WriteLine(myList);
            Console.WriteLine(myList.Count);
            myList.Insert(5, 999);
            myList.Insert(5, 999);
            myList.Insert(5, 999);
            myList.Insert(5, 999);
            Console.WriteLine(myList);
            Console.WriteLine(myList.Count);

            /*
            Console.WriteLine("Выберите структуру, с которой хотите работать");
            int res = PrintStructures();
            if (res == 0)
                return;
            switch (res)
            {
                case 1: 
                    HandleStack();
                    break;
                case 2:
                    HandleQueue();
                    break;
                case 3:
                    HandleCycledQueue();
                    break;
                case 4:
                    HandlePriorityQueue();
                    break;
                case 5:
                    HandleDeque();
                    break;
                case 6:
                    HandleLinkedList();
                    break;
                 case 7:
                    HandleDoubleLinkedList();
                    break;
                    

            }
            */
        }
    }
}