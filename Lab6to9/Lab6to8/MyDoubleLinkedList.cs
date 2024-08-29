namespace Lab6to8
{
    /// <summary>
    /// Реализует структуру данных двусвязный список
    /// </summary>
    /// <typeparam name="T">Тип данных в двусвязнном списке</typeparam>
    public class MyDoubleLinkedList<T>
    {
        /// <summary>
        /// Ссылка на первый элемент в списке
        /// </summary>
        public MyDoubleNode<T> First { get; set; }
        /// <summary>
        /// Ссылка на последний элемент в списке
        /// </summary>
        public MyDoubleNode<T> Last { get; set; }
        /// <summary>
        /// Создает новый пустой двусвязный список
        /// </summary>
        public MyDoubleLinkedList()
        {
            Last = First;
        }
        /// <summary>
        /// Создает новый двусвязный список с единственным элементом
        /// </summary>
        /// <param name="val">Элемент в двусвязном списке</param>
        public MyDoubleLinkedList(T val)
        {
            First = new MyDoubleNode<T>(val);
            Last = First;
        }
        /// <summary>
        /// Возвращает первый узел двусвязного списка
        /// </summary>
        /// <returns>Первый узел двусвязного списка</returns>
        protected MyDoubleNode<T> GetFirstNode()
        {
            return this.First;
        }
        /// <summary>
        /// Вставляет узел в начало списка
        /// </summary>
        /// <param name="newNode">Вставляемый узел</param>
        protected void InsertFirstNode(MyDoubleNode<T> newNode)
        {
            if (First == null)
            {
                First = newNode;
                Last = First;
                First.SetNext(Last);
                Last.SetPrev(First);
                return;
            }
            newNode.SetNext(First);
            First.SetPrev(newNode);
            First = newNode;
        }
        /// <summary>
        /// Вставляет узел в конец списка
        /// </summary>
        /// <param name="newNode">Вставляемый узел</param>
        protected void InsertLastNode(MyDoubleNode<T> newNode)
        {
            if (Last == null)
            {
                Last = newNode;
                First = Last;
                First.SetNext(Last);
                Last.SetPrev(First);
                return;
            }
            newNode.SetPrev(Last);
            Last.SetNext(newNode);
            Last = newNode;
        }
        /// <summary>
        /// Вставляет элемент в начало списка
        /// </summary>
        /// <param name="val">Вставляемый элемент</param>
        public void InsertFirst(T val)
        {
            this.InsertFirstNode(new MyDoubleNode<T>(val));
        }
        /// <summary>
        /// Вставляет элемент в конец списка
        /// </summary>
        /// <param name="val">Вставляемый элемент</param>
        public void InsertLast(T val)
        {
            this.InsertLastNode(new MyDoubleNode<T>(val));
        }
        /// <summary>
        /// Удаляет из списка первый элемент
        /// </summary>
        public void DeleteFirst()
        {
            if (First == Last)
            {
                First = null;
                return;
            }
            this.First = this.First.GetNext();
            this.First.SetPrev(null);
        }
        /// <summary>
        /// Удаляет из списка последний элемент
        /// </summary>
        public void DeleteLast()
        {
            if (First == Last)
            {
                Last = null;
                return;
            }
            this.Last = this.Last.GetPrev();
            this.Last.SetNext(null);
        }
        /// <summary>
        /// Удаляет элемент из списка по значению
        /// </summary>
        /// <param name="val">Удаляемый элемент</param>
        public void DeleteByVal(T val)
        {
            MyDoubleNode<T> left = First;
            MyDoubleNode<T> right = Last;
            while (left != null && right != null && right != left)
            {
                if(left.GetValue().Equals(val))
                {
                    MyDoubleNode<T> next = left.GetNext();
                    MyDoubleNode<T> prev = left.GetPrev();
                    prev.SetNext(next);
                    next.SetPrev(prev);
                    break;
                }
                if (right.GetValue().Equals(val))
                {
                    MyDoubleNode<T> next = right.GetNext();
                    MyDoubleNode<T> prev = right.GetPrev();
                    prev.SetNext(next);
                    next.SetPrev(prev);
                    break;
                }
                right = right.GetPrev();
                left = left.GetNext();
            }
        }
        /// <summary>
        /// Копирует отрезок из двусвязного списка в новый список
        /// </summary>
        /// <param name="from">Порядковый номер первого копируемого элемента</param>
        /// <param name="to">Порядковый номер предпоследнего копируемого элемента</param>
        /// <returns>Новый двусвязный список</returns>
        public MyDoubleLinkedList<T> Copy(int from, int to)
        {
            MyDoubleLinkedList<T> list = new MyDoubleLinkedList<T>();
            int i = 0;
            MyDoubleNode<T> cur = First;
            for (i = 0; i < from; i++)
                cur = cur.GetNext();

            while (i < to)
            {
                list.InsertFirstNode(cur);
                i++;
            }

            return list;
        }
        /// <summary>
        /// Объединяет текущий список с данным, присоединяя его в конец
        /// </summary>
        /// <param name="ll">Присоединяемый в конец двусвязный список</param>
        public void UnifyWith(MyDoubleLinkedList<T> ll)
        {
            if (ReferenceEquals(ll,this))
                return;
            MyDoubleNode<T> myNode = First;
            while (myNode.GetNext() != null)
                myNode = myNode.GetNext();

            myNode.SetNext(ll.GetFirstNode());
            ll.GetFirstNode().SetPrev(myNode);
        }
        /// <summary>
        /// Возвращает новый двусвязный список, соединяющий в себе
        /// текущий и данный
        /// </summary>
        /// <param name="ll">Присоединяемый в конец двусвязный список</param>
        /// <returns>Новый двусвязный список, соединяющий в себе
        /// текущий и данный</returns>
        public MyDoubleLinkedList<T> UnifiedWith(MyDoubleLinkedList<T> ll)
        {
            MyDoubleNode<T> cur;
            MyDoubleLinkedList<T> res = new();

            cur = First;
            while (cur != null)
            {
                res.InsertLast(cur.GetValue());
                cur = cur.GetNext();
            }

            cur = ll.GetFirstNode();
            while (cur != null)
            {
                res.InsertLast(cur.GetValue());
                cur = cur.GetNext();
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
        /// текущего двусвязного списка
        /// </summary>
        /// <returns>Список, состоящий из элементов
        /// текущего двусвязного списка</returns>
        public List<T> GetValues()
        {
            List<T> res = new();

            MyDoubleNode<T> myNode = First;
            while (myNode != null)
            {
                res.Add(myNode.GetValue());
                myNode = myNode.GetNext();
            }
            return res;
        }

    }
}
