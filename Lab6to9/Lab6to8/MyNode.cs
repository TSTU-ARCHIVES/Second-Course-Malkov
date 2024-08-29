using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6to8
{
    /// <summary>
    /// Класс, отображающий узел в связном списке
    /// </summary>
    /// <typeparam name="T">Тип данных, хранимый в узле</typeparam>
    public class MyNode<T>
    {
        /// <summary>
        /// Значение, хранимое в узле
        /// </summary>
        protected T Value;
        /// <summary>
        /// Ссылка на следующий узел
        /// </summary>
        protected MyNode<T> Next;
        /// <summary>
        /// Создает новый узел с данным значением
        /// </summary>
        /// <param name="value"></param>
        public MyNode(T value)
        {
            Value = value;
            Next = null;
        }
        /// <summary>
        /// Создает пустой узел
        /// </summary>
        public MyNode()
        {
            Value = default(T);
            Next = null;
        }
        /// <summary>
        /// Возвращает значение в текущем узле
        /// </summary>
        /// <returns>Значение в текущем узле</returns>
        public T GetValue()
        {
            return this.Value;
        }
        /// <summary>
        /// Возвращает ссылку на следующий элемент
        /// </summary>
        /// <returns>Ссылка на следующий элемент</returns>
        public MyNode<T> GetNext()
        {
            return this.Next;
        }
        /// <summary>
        /// Назначает ссылку на следующий элемент
        /// </summary>
        /// <returns>Ссылка на следующий элемент</returns>
        public void SetNext(MyNode<T> newNode)
        {
            this.Next = newNode;
        }

    }

    /// <summary>
    /// Класс, отобрающий узел, хранящий значение, приоритет
    /// и ссылку на следующий узел
    /// </summary>
    /// <typeparam name="T">Тип данных значение</typeparam>
    /// <typeparam name="K">Тип данных приоритета</typeparam>
    public class MyPriorityNode<T, K>
    {
        /// <summary>
        /// Значение, хранимое в узле
        /// </summary>
        protected T Value;
        /// <summary>
        /// Приоритет, хранимы   в узле
        /// </summary>
        protected K Priority;
        /// <summary>
        /// Ссылка на следующий узел
        /// </summary>
        protected MyPriorityNode<T, K> Next;
        /// <summary>
        /// Создает новый узел с данным значением
        /// </summary>
        public MyPriorityNode(T value, K priority)
        {
            Value = value;
            Priority = priority;
            Next = null;
        }
        /// <summary>
        /// Создает пустой узел
        /// </summary>
        public MyPriorityNode()
        {
            Value = default(T);
            Priority = default(K);
            Next = null;
        }
        /// <summary>
        /// Возвращает значение в текущем узле
        /// </summary>
        /// <returns>Значение в текущем узле</returns>
        public T GetValue()
        {
            return this.Value;
        }/// <summary>
         /// Возвращает приоритет в текущем узле
         /// </summary>
         /// <returns>Приоритет в текущем узле</returns>
        public K GetPriority()
        {
            return this.Priority;
        }
        /// <summary>
        /// Возвращает ссылку на следующий элемент
        /// </summary>
        /// <returns>Ссылка на следующий элемент</returns>
        public MyPriorityNode<T, K> GetNext()
        {
            return this.Next;
        }
        /// <summary>
        /// Назначает ссылку на следующий элемент
        /// </summary>
        /// <returns>Ссылка на следующий элемент</returns>
        public void SetNext(MyPriorityNode<T, K> newNode)
        {
            this.Next = newNode;
        }

    }
}
