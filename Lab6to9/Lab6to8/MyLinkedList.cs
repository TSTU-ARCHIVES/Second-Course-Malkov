namespace Lab6to8
{
    /// <summary>
    /// Реализует структуру данных связный список
    /// </summary>
    /// <typeparam name="T">Тип данных в связнном списке</typeparam>
    public class MyLinkedList<T>
    {
        /// <summary>
        /// Ссылка на первый элемент в списке
        /// </summary>
        public MyNode<T> First { get; set; }
        /// <summary>
        /// Создает новый пустой двусвязный список
        /// </summary>
        public MyLinkedList()
        {

        }
        /// <summary>
        /// Создает новый связный список с единственным элементом
        /// </summary>
        /// <param name="val">Элемент в связном списке</param>
        public MyLinkedList(T val)
        {
            First = new MyNode<T>(val);
        }
        /// <summary>
        /// Возвращает первый узел связного списка
        /// </summary>
        /// <returns>Первый узел связного списка</returns>
        public MyNode<T> GetFirstNode()
        {
            return this.First;
        }
        /// <summary>
        /// Вставляет узел в начало списка
        /// </summary>
        /// <param name="newNode">Вставляемый узел</param>
        protected void InsertFirstNode(MyNode<T> newNode)
        {
            newNode.SetNext(First);
            First = newNode;
        }
        /// <summary>
        /// Вставляет узел в конец списка
        /// </summary>
        /// <param name="newNode">Вставляемый узел</param>
        protected void InsertLastNode(MyNode<T> newNode)
        {
            if (First == null)
            {
                First = newNode;
                return;
            }
            MyNode<T> cur = First;
            while(cur.GetNext() != null)
            {
                cur = cur.GetNext();
            }
            cur.SetNext(newNode);
        }
        /// <summary>
        /// Вставляет элемент в начало списка
        /// </summary>
        /// <param name="val">Вставляемый элемент</param>
        public void InsertFirst(T val)
        {
            this.InsertFirstNode(new MyNode<T>(val));
        }
        /// <summary>
        /// Вставляет элемент в конец списка
        /// </summary>
        /// <param name="val">Вставляемый элемент</param>
        public void InsertLast(T val)
        {
            this.InsertLastNode(new MyNode<T>(val));
        }
        /// <summary>
        /// Удаляет элемент из списка по значению
        /// </summary>
        /// <param name="val">Удаляемый элемент</param>
        public void DeleteByVal(T val)
        {
            MyNode<T> prev = First;
            while (prev.GetNext() != null)
            {
                if (prev.GetNext().GetValue().Equals(val))
                {
                    prev.SetNext(prev.GetNext().GetNext());
                    break;
                }
                prev = prev.GetNext();
            }
        }
        /// <summary>
        /// Удаляет первый элемент из списка
        /// </summary>
        public void DeleteFirst()
        {
            First = First.GetNext();
        }
        /// <summary>
        /// Копирует отрезок из связного списка в новый список
        /// </summary>
        /// <param name="from">Порядковый номер первого копируемого элемента</param>
        /// <param name="to">Порядковый номер предпоследнего копируемого элемента</param>
        public MyLinkedList<T> Copy(int from, int to)
        {
            MyLinkedList<T> list = new MyLinkedList<T>();
            int i = 0;
            MyNode<T> cur = First;
            for (i = 0; i < from; i++)
                cur = cur.GetNext();

            while (i < to)
            {
                list.InsertFirst(cur.GetValue());
                i++;
            }

            return list;
        }
        /// <summary>
        /// Объединяет текущий список с данным, присоединяя его в конец
        /// </summary>
        /// <param name="ll">Присоединяемый в конец связный список</param>
        public void UnifyWith(MyLinkedList<T> ll)
        {
            MyNode<T> myNode = First;
            while (myNode.GetNext() != null)
                myNode = myNode.GetNext();

            myNode.SetNext(ll.GetFirstNode());
        }
        /// <summary>
        /// Возвращает новый связный список, соединяющий в себе
        /// текущий и данный
        /// </summary>
        /// <param name="ll">Присоединяемый в конец связный список</param>
        /// <returns>Новый связный список, соединяющий в себе
        /// текущий и данный</returns>
        public MyLinkedList<T> UnifiedWith(MyLinkedList<T> ll)
        {
            MyNode<T> cur;
            MyLinkedList<T> res = new();
            MyStackOnNodes<T> Stack = new();

            cur = First;
            while (cur != null)
            {
                Stack.Push(cur.GetValue());
                cur = cur.GetNext();
            }

            cur = ll.GetFirstNode();
            while (cur != null)
            {
                Stack.Push(cur.GetValue());
                cur = cur.GetNext();
            }

            while (!Stack.IsEmpty())
            {
                res.InsertFirst(Stack.Pop());
            }

            return res;
        }
        /// <summary>
        /// Проверяет текущий список на пустоту
        /// </summary>
        /// <returns>
        /// True: текущий список пуст
        /// False: все иные случаи
        /// </returns>
        public bool IsEmpty()
        {
            return this.First == null;
        }
        /// <summary>
        /// Возвращает список, состоящий из элементов
        /// текущего связного списка
        /// </summary>
        /// <returns>Список, состоящий из элементов
        /// текущего связного списка</returns>
        public List<T> GetValues()
        {
            List<T> res = new();

            MyNode<T> myNode = First;
            while (myNode != null)
            {
                res.Add(myNode.GetValue());
                myNode = myNode.GetNext();
            }
            return res;
        }

    }
}
