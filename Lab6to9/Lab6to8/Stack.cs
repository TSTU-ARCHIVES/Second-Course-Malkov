using P;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6to8
{
    public abstract class MyStack<T>
    {
        public abstract T Peek();
        public abstract T Pop();
        public abstract void Push(T item);
        public abstract bool IsEmpty();
    }
    /// <summary>
    /// Реализует структуру данных стэк
    /// </summary>
    /// <typeparam name="T">Тип данных, хранимый в экземпляре стека</typeparam>
    public class MyStackOnNodes<T> : MyStack<T>
    {
        /// <summary>
        /// Ссылка на узел, являющийся верхушкой стека
        /// </summary>
        private MyNode<T> Current;
        /// <summary>
        /// Количество элементов в стеке
        /// </summary>
        private int Length = 0;
        /// <summary>
        /// Создает новый пустой стэк
        /// </summary>
        public MyStackOnNodes()
        {

        }
        /// <summary>
        /// Создает новый стэк с единственным элементом
        /// </summary>
        /// <param name="elem">Элемент</param>
        public MyStackOnNodes(T elem)
        {
            Current = new MyNode<T>(elem);
            Length++;
        }
        /// <summary>
        /// Возвращает количество элементов в стеке
        /// </summary>
        /// <returns>Количество элементов в стеке</returns>
        public int GetLength()
        {
            return this.Length;
        }
        /// <summary>
        /// Возвращает верхний элемент стека
        /// </summary>
        /// <returns>Верхний элемент стека</returns>
        public override T Peek()
        {
            return this.Current.GetValue();
        }
        /// <summary>
        /// Вставляет элемент на верхушку стека
        /// </summary>
        /// <param name="val">Вставляемый элемент</param>
        public override void Push(T val)
        {
            MyNode<T> newNode = new MyNode<T>(val);
            newNode.SetNext(Current);
            Current = newNode;
            Length++;
        }
        /// <summary>
        /// Возвращает верхний элемент стека, удаляя его
        /// </summary>
        /// <returns>Верхний элемент стека</returns>
        public override T Pop()
        {
            MyNode<T> oldNode = Current;
            MyNode<T> newNode = Current.GetNext();
            Current = newNode;
            Length--;
            return oldNode.GetValue();
        }
        /// <summary>
        /// Проверяет стек на пустоту
        /// </summary>
        /// <returns>
        /// True: стек пуст и не содержит элементов
        /// False: все остальные случаи
        /// </returns>
        public override bool IsEmpty()
        {
            return this.Current == null;
        }

    }

    /// <summary>
    /// Реализует структуру данных стэк
    /// </summary>
    /// <typeparam name="T">Тип данных, хранимый в экземпляре стека</typeparam>
    public class MyStackOnArray<T> : MyStack<T>
    {
        private T[] _buffer;
        private int _top;

        public MyStackOnArray(int capacity)
        {
            _buffer = new T[capacity];
            _top = -1;
        }

        /// <summary>
        /// Вставляет элемент на верхушку стека
        /// </summary>
        /// <param name="val">Вставляемый элемент</param>
        public override void Push(T item)
        {
            if (_top == _buffer.Length - 1)
            {
                throw new Exception("Буффер кончился!");
            }
            _buffer[++_top] = item;
        }

        /// <summary>
        /// Возвращает верхний элемент стека, удаляя его
        /// </summary>
        /// <returns>Верхний элемент стека</returns>
        public override T Pop()
        {
            T res = this.Peek();
            _top--;
            return res;
        }

        /// <summary>
        /// Возвращает верхний элемент стека
        /// </summary>
        /// <returns>Верхний элемент стека</returns>
        public override T Peek()
        {
            if (_top == -1)
            {
                throw new Exception("Стэк пуст");
            }
            return _buffer[_top];
        }

        /// <summary>
        /// Проверяет стек на пустоту
        /// </summary>
        /// <returns>
        /// True: стек пуст и не содержит элементов
        /// False: все остальные случаи
        /// </returns>
        public override bool IsEmpty()
        {
            return _top == -1;
        }z
    }




}
