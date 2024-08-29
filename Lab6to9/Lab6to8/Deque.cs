using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6to8
{
    public abstract class MyDequeue<T>
    {
        public abstract void InsertFirst(T elem);
        public abstract void InsertLast(T elem);

        public abstract T GetFirst();
        public abstract T GetLast();
        public abstract T PopFirst();
        public abstract T PopLast();

        public abstract bool IsEmpty();

    }
    /// <summary>
    /// Реализует структуру данных Дек
    /// </summary>
    /// <typeparam name="T">Тип данных, хранимый в экземпляре дека</typeparam>
    public class MyDequeueOnNodes<T> : MyDequeue<T>
    {
        /// <summary>
        /// Узел, являющийся первым элементом дека
        /// </summary>
        private MyDoubleNode<T> first;
        /// <summary>
        /// Узел, являющийся последним элементом дека
        /// </summary>
        private MyDoubleNode<T> last;
        /// <summary>
        /// Количество элементов в деке
        /// </summary>
        private int Length = 0;
        /// <summary>
        /// Создает новый пустой дек
        /// </summary>
        public MyDequeueOnNodes()
        {
            last = first;
        }
        /// <summary>
        /// Создает новый дек с данным элементом
        /// </summary>
        /// <param name="first">Первый элемент дека</param>
        public MyDequeueOnNodes(T first)
        {
            this.first = new MyDoubleNode<T>(first);
            this.last = this.first;
            Length++;
        }
        /// <summary>
        /// Осуществляет вставку данного элемента в начало дека
        /// </summary>
        /// <param name="elem">Вставляемый элемент</param>
        public override void InsertFirst(T elem)
        {
            MyDoubleNode<T> node = new(elem);
            if (Length == 0)
            {
                first = node;
                last = first;
                first.SetNext(last);
                last.SetPrev(first);
                Length++;
                return;
            }
            node.SetNext(first);
            first.SetPrev(node);
            first = node;
            Length++;
        }
        /// <summary>
        /// Осуществляет вставку данного элемента в конец дека
        /// </summary>
        /// <param name="elem">Вставляемый элемент</param>
        public override void InsertLast(T elem)
        {
            MyDoubleNode<T> node = new(elem);
            if (Length == 0)
            {
                last = node;
                first = last;
                first.SetNext(last);
                last.SetPrev(first);
                Length++;
                return;
            }
            node.SetPrev(last);
            last.SetNext(node);
            last = node;
            Length++;
        }
        /// <summary>
        /// Возвращает первый элемент дека
        /// </summary>
        /// <returns>Первый элемент дека</returns>
        public override T GetFirst()
        {
            return first.GetValue();
        }
        /// <summary>
        /// Возвращает последний элемент дека
        /// </summary>
        /// <returns>Последний элемент дека</returns>
        public override T GetLast()
        {
            return last.GetValue();
        }
        /// <summary>
        /// Возвращает первый элемент дека, удаляя его
        /// </summary>
        /// <returns>Первый элемент дека</returns>
        public override T PopFirst()
        {
            MyDoubleNode<T> node = first;
            first = first.GetNext();
            first?.SetPrev(null);
            Length--;
            return node.GetValue();
        }
        /// <summary>
        /// Возвращает последний элемент дека, удаляя его
        /// </summary>
        /// <returns>Последний элемент дека</returns>
        public override T PopLast()
        {
            MyDoubleNode<T> node = last;
            last = last.GetPrev();
            last?.SetNext(null);
            Length--;
            return node.GetValue();
        }
        /// <summary>
        /// Возвращает длину дека,
        /// т.е. количество элементов
        /// </summary>
        /// <returns>Длину дека,
        /// т.е. количество элементов</returns>
        public int GetLength()
        {
            return this.Length;
        }
        /// <summary>
        /// Проверяет, пуст ли данный дек
        /// </summary>
        /// <returns>
        /// True: дек пуст и не содержит элементов
        /// False: все остальные случаи
        /// </returns>
        public override bool IsEmpty()
        {
            return Length == 0;
        }

    }

    public class MyDequeueOnArray<T> : MyDequeue<T>
    {
        private T[] array;
        private int front;
        private int rear;
        private int size;
        private int capacity;

        public MyDequeueOnArray(int capacity)
        {
            this.capacity = capacity;
            array = new T[capacity];
            front = -1;
            rear = 0;
            size = 0;
        }

        public override void InsertFirst(T item)
        {
            if ((front == 0 && rear == capacity - 1) || (front == rear + 1))
            {
                throw new InvalidOperationException("Deque is full");
            }
            if (front == -1)
            {
                front = 0;
                rear = 0;
            }
            else if (front == 0)
            {
                front = capacity - 1;
            }
            else
            {
                front--;
            }
            array[front] = item;
            size++;
        }

        public override void InsertLast(T item)
        {
            if ((front == 0 && rear == capacity - 1) || (front == rear + 1))
            {
                throw new InvalidOperationException("Deque is full");
            }
            if (front == -1)
            {
                front = 0;
                rear = 0;
            }
            else if (rear == capacity - 1)
            {
                rear = 0;
            }
            else
            {
                rear++;
            }
            array[rear] = item;
            size++;
        }

        public override T PopFirst()
        {
            if (front == -1)
            {
                throw new InvalidOperationException("Deque is empty");
            }
            T item = array[front];
            if (front == rear)
            {
                front = -1;
                rear = -1;
            }
            else if (front == capacity - 1)
            {
                front = 0;
            }
            else
            {
                front++;
            }
            size--;
            return item;
        }

        public override T PopLast()
        {
            if (front == -1)
            {
                throw new InvalidOperationException("Deque is empty");
            }
            T item = array[rear];
            if (front == rear)
            {
                front = -1;
                rear = -1;
            }
            else if (rear == 0)
            {
                rear = capacity - 1;
            }
            else
            {
                rear--;
            }
            size--;
            return item;
        }

        public override T GetFirst()
        {
            if (front == -1)
            {
                throw new InvalidOperationException("Deque is empty");
            }
            return array[front];
        }

        public override T GetLast()
        {
            if (rear == -1)
            {
                throw new InvalidOperationException("Deque is empty");
            }
            return array[rear];
        }
    

        public override bool IsEmpty()
        {
            return front == -1;
        }

    }
}
