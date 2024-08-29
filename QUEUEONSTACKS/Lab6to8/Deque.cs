using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6to8
{
    /// <summary>
    /// Реализует структуру данных Дек
    /// </summary>
    /// <typeparam name="T">Тип данных, хранимый в экземпляре дека</typeparam>
    public class MyDeque<T>
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
        public MyDeque()
        {
            last = first;
        }
        /// <summary>
        /// Создает новый дек с данным элементом
        /// </summary>
        /// <param name="first">Первый элемент дека</param>
        public MyDeque(T first)
        {
            this.first = new MyDoubleNode<T>(first);
            this.last = this.first;
            Length++;
        }
        /// <summary>
        /// Осуществляет вставку данного элемента в начало дека
        /// </summary>
        /// <param name="elem">Вставляемый элемент</param>
        public void InsertFirst(T elem)
        {
            MyDoubleNode<T> node = new(elem);
            node.SetNext(first);
            first.SetPrev(node);
            first = node;
            Length++;
        }
        /// <summary>
        /// Осуществляет вставку данного элемента в конец дека
        /// </summary>
        /// <param name="elem">Вставляемый элемент</param>
        public void InsertLast(T elem)
        {
            MyDoubleNode<T> node = new(elem);
            node.SetPrev(last);
            last.SetNext(node);
            last = node;
            Length++;
        }
        /// <summary>
        /// Возвращает первый элемент дека
        /// </summary>
        /// <returns>Первый элемент дека</returns>
        public T GetFirst()
        {
            return first.GetValue();
        }
        /// <summary>
        /// Возвращает последний элемент дека
        /// </summary>
        /// <returns>Последний элемент дека</returns>
        public T GetLast()
        {
            return last.GetValue();
        }
        /// <summary>
        /// Возвращает первый элемент дека, удаляя его
        /// </summary>
        /// <returns>Первый элемент дека</returns>
        public T PopFirst()
        {
            MyDoubleNode<T> node = first;
            first = first.GetNext();
            Length--;
            return node.GetValue();
        }
        /// <summary>
        /// Возвращает последний элемент дека, удаляя его
        /// </summary>
        /// <returns>Последний элемент дека</returns>
        public T PopLast()
        {
            MyDoubleNode<T> node = last;
            last = last.GetPrev();
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
        public bool IsEmpty()
        {
            return Length == 0;
        }

    }
}
