using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6to8
{
    /// <summary>
    /// Класс, отображающий узел в двусвязном списке
    /// </summary>
    /// <typeparam name="T">Тип данных, хранимый в узле</typeparam>
    public class MyDoubleNode<T> : MyNode<T>
    {
        /// <summary>
        /// Ссылка на следующий узел
        /// </summary>
        protected new MyDoubleNode<T> Next;
        /// <summary>
        /// Ссылка на предыдущий узел
        /// </summary>
        private MyDoubleNode<T> Prev;
        /// <summary>
        /// Создает новый узел на основе данного значения
        /// </summary>
        /// <param name="value">Данное значение</param>
        public MyDoubleNode(T value) : base(value) {   }
        /// <summary>
        /// Создает пустой узел
        /// </summary>
        public MyDoubleNode() {  }
        /// <summary>
        /// Возвращает ссылку на следующий узел в списке
        /// </summary>
        /// <returns>Ссылка на следующий узел в списке</returns>
        public new MyDoubleNode<T> GetNext()
        {
            return this.Next;
        }
        /// <summary>
        /// Назначает ссылку на следующий узел в списке
        /// </summary>
        /// <param name="newNode">Ссылка на следующий узел в списке</param>
        public void SetNext(MyDoubleNode<T> newNode)
        {
            this.Next = newNode;
        }
        /// <summary>
        /// Возвращает ссылку на предыдущий узел в списке
        /// </summary>
        /// <returns>Ссылка на предыдущий узел в списке</returns>
        public MyDoubleNode<T> GetPrev()
        {
            return this.Prev;
        }
        /// <summary>
        /// Назначает ссылку на предыдущий узел в списке
        /// </summary>
        /// <param name="newNode">Ссылка на предыдущий узел в списке</param>
        public void SetPrev(MyDoubleNode<T> newNode)
        {
            this.Prev = newNode;
        }
    }
}
