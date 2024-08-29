using P;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6to8
{
    /// <summary>
    /// Реализует структуру данных стэк
    /// </summary>
    /// <typeparam name="T">Тип данных, хранимый в экземпляре стека</typeparam>
    public class MyStack<T>
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
        public MyStack()
        {

        }
        /// <summary>
        /// Создает новый стэк с единственным элементом
        /// </summary>
        /// <param name="elem">Элемент</param>
        public MyStack(T elem)
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
        public T GetCurrent()
        {
            return this.Current.GetValue();
        }
        /// <summary>
        /// Вставляет элемент на верхушку стека
        /// </summary>
        /// <param name="val">Вставляемый элемент</param>
        public void InsertElem(T val)
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
        public T PopElem()
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
        public bool IsEmpty()
        {
            return this.Current == null;
        }

    }
}
