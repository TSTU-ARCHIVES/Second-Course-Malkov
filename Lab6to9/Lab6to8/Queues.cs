using P;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab6to8
{
    public abstract class MyQueue<T>
    {
        public abstract T Dequeue();
        public abstract bool IsEmpty();

        public abstract T GetCurrent();

        public abstract void Enqueue(T elem);
    }
    /// <summary>
    /// Реализует структуру данных очередь
    /// </summary>
    /// <typeparam name="T">Тип данных, хранимый в экземпляре очередь</typeparam>
    public class MyQueueOnNodes<T> : MyQueue<T>
    {
        /// <summary>
        /// Ссылка на первый элемент в очереди
        /// </summary>
        protected MyNode<T> first;
        /// <summary>
        /// Ссылка на последний элемент в очереди
        /// </summary>
        protected MyNode<T> last;
        /// <summary>
        /// Количество элементов о очереди
        /// </summary>
        protected int Length = 0;
        /// <summary>
        /// Создает новую пустую очередь
        /// </summary>
        public MyQueueOnNodes()
        {
            last = first;
        }
        /// <summary>
        /// Создает новую очередь с единственным элементом
        /// </summary>
        /// <param name="elem">Элемент</param>
        public MyQueueOnNodes(T elem)
        {
            first = new MyNode<T>(elem);
            last = first;
            Length++;
        }
        /// <summary>
        /// Возвращает количество элементов в очереди
        /// </summary>
        /// <returns>Количество элементов в очереди</returns>
        public int GetLength()
        {
            return this.Length;
        }
        /// <summary>
        /// Возвращает первый элемент в очереди
        /// </summary>
        /// <returns>Первый элемент в очереди</returns>
        public override T GetCurrent()
        {
            return this.first.GetValue();
        }
        /// <summary>
        /// Вставляет элемент в начало очереди
        /// </summary>
        /// <param name="val">Вставляемый элемент</param>
        public override void Enqueue(T val)
        {
            MyNode<T> newNode = new MyNode<T>(val);
            if (Length == 0)
            {
                this.first = newNode;
                Length++;
                return;
            }
            if (Length == 1)
            {
                this.last = newNode;
                Length++;
                this.first.SetNext(last);
                return;
            }
            this.last.SetNext(newNode);
            this.last = newNode;
            Length++;
        }
        /// <summary>
        /// Возвращает первый элемент в очереди, удаляя его
        /// </summary>
        /// <returns>Первый элемент в очереди</returns>
        public override T Dequeue()
        {
            MyNode<T> oldNode = this.first;
            MyNode<T> newNode = this.first.GetNext();
            this.first = newNode;
            Length--;
            return oldNode.GetValue();
        }
        /// <summary>
        /// Проверяет очередь на пустоту
        /// </summary>
        /// <returns>
        /// True: очередь пуста и не содержит элементов
        /// False: все остальные случаи
        /// </returns>
        public override bool IsEmpty()
        {
            return Length == 0;
        }
    }

    /// <summary>
    /// Реализует структуру данных приоритетная очередь
    /// </summary>
    /// <typeparam name="T">Тип данных, хранимый в экземпляре очередь</typeparam>
    public class MyPriorityQueue<T, K> 
        where K : IComparable<K>
    {
        /// <summary>
        /// Ссылка на первый элемент в очереди
        /// </summary>
        protected MyPriorityNode<T, K> first;
        /// <summary>
        /// Ссылка на последний элемент в очереди
        /// </summary>
        protected MyPriorityNode<T, K> last;
        /// <summary>
        /// Количество элементов о очереди
        /// </summary>
        protected int Length = 0;

        /// <summary>
        /// Создает новую пустую приоритетную очередь, в которой элементы
        /// распределяются по возрастанию
        /// </summary>
        public MyPriorityQueue() { }
        /// <summary>
        /// Создает новую приоритетную очередь с единственным элементом
        /// </summary>
        /// <param name="elem">Элемент</param>
        public MyPriorityQueue(T elem, K priority) {
            MyPriorityNode<T, K> first = new(elem, priority);
            this.first = first;
        }
        /// <summary>
        /// Вставляет элемент в очередь
        /// </summary>
        /// <param name="val">Вставляемый элемент</param>
        public void Enquque(T val, K priority)
        {

            MyPriorityNode<T, K> newNode = new MyPriorityNode<T, K>(val, priority);
            //special cases if 0 or 1 elems
            if (Length == 0)
            {
                this.first = newNode;
                Length++;
                return;
            }
            if (Length == 1)
            {
                if (this.first.GetPriority().CompareTo(priority) <= 0)
                {
                    this.last = newNode;
                } else
                {
                    this.last = first;
                    first = newNode;
                }
                first.SetNext(last);
                Length++;
                return;
            }
            Length++;

            //insert in 1st place
            if (this.first.GetPriority().CompareTo(priority) > 0)
            {
                MyPriorityNode<T, K> temp = first;
                first = newNode;
                first.SetNext(temp);
                return;
            }

            //insert in midlle
            MyPriorityNode<T, K> curNode = this.first;

            while (curNode.GetNext() != null)
            {
                if (curNode.GetNext().GetPriority().CompareTo(priority) > 0)
                {
                    MyPriorityNode<T, K> next = curNode.GetNext();
                    curNode.SetNext(newNode);
                    newNode.SetNext(next);
                    return;
                }
                curNode = curNode.GetNext();
            }
            //insert in last place

            last.SetNext(newNode);
            last = newNode;

        }
        /// <summary>
        /// Возвращает количество элементов в очереди
        /// </summary>
        /// <returns>Количество элементов в очереди</returns>
        public int GetLength()
        {
            return this.Length;
        }
        /// <summary>
        /// Возвращает первый элемент в очереди
        /// </summary>
        /// <returns>Первый элемент в очереди</returns>
        public T GetCurrent()
        {
            Queue<int> q = new Queue<int>();
            return this.first.GetValue();
        }
        /// <summary>
        /// Возвращает первый элемент в очереди, удаляя его
        /// </summary>
        /// <returns>Первый элемент в очереди</returns>
        public T Dequeue()
        {
            MyPriorityNode<T, K> oldNode = this.first;
            MyPriorityNode<T, K> newNode = this.first.GetNext();
            this.first = newNode;
            Length--;
            return oldNode.GetValue();
        }
        /// <summary>
        /// Проверяет очередь на пустоту
        /// </summary>
        /// <returns>
        /// True: очередь пуста и не содержит элементов
        /// False: все остальные случаи
        /// </returns>
        public bool IsEmpty()
        {
            return Length == 0;
        }
    }
    /// <summary>
    /// Реализует структуру данных кольцевая очередь
    /// </summary>
    /// <typeparam name="T">Тип данных, хранящийся в очереди</typeparam>
    public class MyCyclingQueue<T> : MyQueue<T>
    {
        /// <summary>
        /// Индекс первого элемента в очереди
        /// </summary>
        private int first;
        /// <summary>
        /// Индекс последнего элемента в очереди
        /// </summary>
        private int last;
        /// <summary>
        /// Размер буффера
        /// </summary>
        private int size;
        /// <summary>
        /// Массив-буффер для очереди
        /// </summary>
        private T[] buffer;
        /// <summary>
        /// Создает кольцевую очередь с буффером указанного размера
        /// </summary>
        /// <param name="size">Размер буффера</param>
        public MyCyclingQueue(int size)
        {
            this.size = size;
            buffer = new T[size];
            first = -1;
            last = -1;
        }
        /// <summary>
        /// Возвращает первый элемент очереди
        /// </summary>
        /// <returns>Первый элемент очереди</returns>
        public override T GetCurrent()
        {
            return buffer[first];
        }
        /// <summary>
        /// Возвращает первый элемент очереди, удаляя его
        /// </summary>
        /// <returns>Первый элемент очереди</returns>
        public override T Dequeue()
        {
            T elem = buffer[first];
            if (first == last)
            {
                first = -1;
                last = -1;
            } 
            else
            {
                first = (first + 1) % size;
            }
            return elem;
        }
        /// <summary>
        /// Вставляет элемент в конец очереди
        /// </summary>
        /// <param name="elem">Вставляемый элемент</param>
        public override void Enqueue(T elem)
        {
            last = (last + 1) % size;
            if (IsEmpty())
                first = 0;
            buffer[last] = elem;
        }
        /// <summary>
        /// Проверяет очередь на пустоту
        /// </summary>
        /// <returns>
        /// True: очередь пуста и не содержит элементов
        /// False: все остальные случаи
        /// </returns>
        public override bool IsEmpty()
        {
            return first == -1;
        }
    }

    public class MyQueueOnArray<T> : MyQueue<T>
    {
        private T[] _buffer;
        private int _head;
        private int _tail;

        public MyQueueOnArray(int capacity)
        {
            _buffer = new T[capacity];
            _head = 0;
            _tail = -1;
        }

        public override void Enqueue(T item)
        {
            _buffer[++_tail] = item;
        }

        public override T Dequeue()
        {
            return _buffer[_head++];
        }

        public override T GetCurrent()
        {
            return _buffer[_head];
        }

        public override bool IsEmpty()
        {
            return _head > _tail;
        }
        
    }
}
