using System.Collections;

namespace GraphsADT__L10to12_
{
    /// <summary>
    /// Абстрактный класс Граф, определяющий, какие 
    /// операции можно будет производить над графами
    /// </summary>
    public abstract class Graph : IEnumerable<int>, ICloneable
    {
        /// <summary>
        /// Количество вершин графа
        /// </summary>
        public int NVertexes;
        #region to implement in real class
        /// <summary>
        /// Возвращает вес ребра
        /// </summary>
        /// <param name="from">Вершина, из которой ребро исходит</param>
        /// <param name="to">Вершина, в которую ребро входит</param>
        /// <returns>Вес данного ребра</returns>
        public abstract int GetEdgeValue(int from, int to);

        /// <summary>
        /// Удаляет ребро между двумя вершинами
        /// </summary>
        /// <param name="from">Вершина, из которой выходит удаляемое ребро</param>
        /// <param name="to">Вершина, в которую входит удаляемое ребро</param>
        public abstract void RemoveEdge(int from, int to);

        /// <summary>
        /// Создает ребро между двумя вершинами
        /// </summary>
        /// <param name="from">Вершина, из которой выходит создаваемое ребро</param>
        /// <param name="to">Вершина, в которую входит создаваемое ребро</param>
        /// <param name="cost">Длина ребра</param>
        public abstract void AddEgde(int from, int to, int cost);

        /// <summary>
        /// Находит смежное с данным непосещенное ребро либо
        /// -1 если такое не найдено
        /// </summary>
        /// <param name="from">Данное ребро</param>
        /// <param name="seen">Массив, отображающий повещенные ребра</param>
        /// <returns></returns>
        public abstract int FindAdjNotSeen(int from, ref bool[] seen);

        /// <summary>
        /// Находит в данном графе вершину без последователей
        /// </summary>
        /// <returns>Вершина без последователей</returns>
        public abstract int GetVertexWithNoCons();

        /// <summary>
        /// Проверяет, являются ли данные вершины смежными
        /// </summary>
        /// <param name="from">Первая вершина</param>
        /// <param name="to">Вторая вершина</param>
        /// <returns>
        /// True: вершины смежные
        /// False: вершины несмежные
        /// </returns>
        public abstract bool Adjastent(int from, int to);

        /// <summary>
        /// Определяет степень вершины
        /// </summary>
        /// <param name="vertex">Вершина, степень которой необходимо опрделить</param>
        /// <returns>Степень вершины</returns>
        public abstract int VertexDegree(int vertex);

        /// <summary>
        /// Enumerator, поддерживающий перечисление по 
        /// всем вершинам графа, представляемыми целыми числами
        /// </summary>
        /// <returns>Enumerator, поддерживающий перечисление по 
        /// всем вершинам графа</returns>
        public abstract IEnumerator<int> GetEnumerator();

        /// <summary>
        /// Клонирует текущий граф
        /// </summary>
        /// <returns>Граф-клон текущего</returns>
        public abstract object Clone();
        #endregion

        #region lab 10
        /// <summary>
        /// Осуществлет DFS - поиск вглубину
        /// </summary>
        public void DFS()
        {
            bool[] seen = new bool[NVertexes];
            DFS(GetVertexWithNoCons(), ref seen);
            //unlinked vertexes
            for (int i = 0; i < NVertexes; i++)
            {
                if (!seen[i])
                {
                    DFS(i, ref seen);
                }
            }
        }

        /// <summary>
        /// Вспомогательная функция для поиска вглубину
        /// </summary>
        public virtual void DFS(int start, ref bool[] seen)
        {
            int curV = start < 0 || start > NVertexes ?
                0 : start;
            Stack<int> vertexes = new Stack<int>();

            seen[curV] = true;
            vertexes.Push(curV);

            while (vertexes.Count > 0)
            {
                curV = vertexes.Peek();
                int checkV = FindAdjNotSeen(curV, ref seen);
                if (checkV != -1)
                {
                    vertexes.Push(checkV);
                    seen[checkV] = true;
                }
                else
                {
                    curV = vertexes.Pop();
                }
            }
        }


        /// <summary>
        /// Осуществляет BFS - поиск вширину
        /// </summary>
        public void BFS()
        {
            bool[] seen = new bool[NVertexes];
            BFS(GetVertexWithNoCons(), ref seen);
            //unlinked vertexes
            for (int i = 0; i < NVertexes; i++)
            {
                if (!seen[i])
                {
                    BFS(i, ref seen);
                }
            }
        }

        /// <summary>
        /// Вспомогательная функция для поиска вширину
        /// </summary>
        public virtual void BFS(int start, ref bool[] seen)
        {
            int curV = start < 0 || start > NVertexes ?
                0 : start;
            Queue<int> vertexes = new Queue<int>();

            seen[curV] = true;
            vertexes.Enqueue(curV);

            while (vertexes.Count > 0)
            {
                curV = vertexes.Peek();
                int checkV = FindAdjNotSeen(curV, ref seen);
                if (checkV != -1)
                {
                    vertexes.Enqueue(checkV);
                    seen[checkV] = true;
                }
                else
                {
                    curV = vertexes.Dequeue();
                }
            }
        }

        /// <summary>
        /// Создает список всех путей в графе
        /// </summary>
        /// <returns>Список всех путей в графе </returns>
        public string PrintAllWays()
        {
            string res = "";
            for (int j = 0; j < NVertexes; j++)
            {
                bool[] seen = new bool[NVertexes];
                int curV = j;
                Stack<int> vertexes = new Stack<int>();

                seen[curV] = true;
                vertexes.Push(curV);
                LinkedList<int> way = new LinkedList<int>();
                way.AddLast(curV);
                while (vertexes.Count > 0)
                {
                    curV = vertexes.Peek();
                    int checkV = FindAdjNotSeen(curV, ref seen);
                    if (checkV != -1)
                    {
                        vertexes.Push(checkV);
                        way.AddLast(checkV);
                        seen[checkV] = true;
                    }
                    else
                    {
                        curV = vertexes.Pop();
                        if (way.Count <= 1)
                            continue;
                        foreach (int i in way)
                        {
                            res += Convert.ToChar(i + 'A').ToString() + " ";
                        }
                        res += "\r\n;";
                        way.RemoveLast();
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// Создает список всех путей в графе и их стоимость
        /// </summary>
        /// <returns>Список всех путей в графе и их стоимость</returns>
        public string PrintCostOfAllWays()
        {
            string res = "";
            for (int j = 0; j < NVertexes; j++)
            {
                bool[] seen = new bool[NVertexes];
                int curV = j;
                Stack<int> vertexes = new Stack<int>();

                seen[curV] = true;
                vertexes.Push(curV);
                LinkedList<int> way = new LinkedList<int>();
                way.AddLast(curV);

                int curValue = 0;
                while (vertexes.Count > 0)
                {
                    curV = vertexes.Peek();
                    int checkV = FindAdjNotSeen(curV, ref seen);
                    if (checkV != -1)
                    {
                        vertexes.Push(checkV);
                        way.AddLast(checkV);
                        curValue += GetEdgeValue(curV, checkV);
                        seen[checkV] = true;
                    }
                    else
                    {
                        curV = vertexes.Pop();
                        if (way.Count <= 1)
                            continue;
                        foreach (int i in way)
                        {
                            res += Convert.ToChar(i + 'A').ToString() + " ";
                        }
                        res += ": cost = " + curValue.ToString() + "\n;";
                        way.RemoveLast();
                        int prevV = vertexes.Peek();

                        curValue -= GetEdgeValue(curV, checkV);
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// Создает подграф поиска, т.е. граф, состоящий из 
        /// вершин, которые соединены в том порядке, в котором
        /// по ним проходит поиск в глубину
        /// </summary>
        /// <returns>Подграф поиска</returns>
        public virtual Graph SubGraph()
        {
            Graph graph = new GraphOnADJList();

            bool[] seen = new bool[NVertexes];
            int curV = 0;
            Stack<int> vertexes = new Stack<int>();

            seen[curV] = true;
            vertexes.Push(curV);
            while (vertexes.Count > 0)
            {
                curV = vertexes.Peek();
                int checkV = FindAdjNotSeen(curV, ref seen);
                if (checkV != -1)
                {
                    vertexes.Push(checkV);
                    graph.AddEgde(curV, checkV, 1);
                    seen[checkV] = true;
                }
                else
                {
                    curV = vertexes.Pop();
                }
            }

            return graph;
        }

        /// <summary>
        /// Создает строку, отображающую время посещения вершин
        /// при поиске в глубину
        /// </summary>
        /// <returns>Строка, отображающая время посещения вершин
        /// при поиске в глубину</returns>
        public string PrintTimeOfEntries()
        {
            int[] InTimes = new int[NVertexes];

            bool[] seen = new bool[NVertexes];
            int curV = GetVertexWithNoCons();
            curV = curV == -1 ? 1 : curV;
            Stack<int> vertexes = new Stack<int>();

            int time = 0;
            seen[curV] = true;
            vertexes.Push(curV);
            InTimes[curV] = time;
            while (vertexes.Count > 0)
            {
                time++;
                curV = vertexes.Peek();
                int checkV = FindAdjNotSeen(curV, ref seen);
                if (checkV != -1)
                {
                    vertexes.Push(checkV);
                    InTimes[checkV] = time;
                    seen[checkV] = true;
                }
                else
                {
                    curV = vertexes.Pop();
                }

            }

            string res = "";
            for (int i = 0; i < NVertexes; i++)
            {
                res += $"Vertex No.{i} - Entry Time = {InTimes[i]}; ";
            }
            return res;
        }

        /// <summary>
        /// Создает строку, отображающую скобочную структуру графа
        /// </summary>
        /// <returns>Строка, отображающая скобчную структуру графа</returns>
        public string PrintBraceStructure()
        {
            string BraceStructure = "";

            bool[] seen = new bool[NVertexes];
            int curV = 0;
            Stack<int> vertexes = new Stack<int>();

            seen[curV] = true;
            vertexes.Push(curV);
            BraceStructure += $"({curV}";
            while (vertexes.Count > 0)
            {
                curV = vertexes.Peek();
                int checkV = FindAdjNotSeen(curV, ref seen);
                if (checkV != -1)
                {
                    vertexes.Push(checkV);
                    seen[checkV] = true;
                    BraceStructure += $"({checkV} ";
                }
                else
                {
                    BraceStructure += $" {curV})";
                    curV = vertexes.Pop();
                }
            }

            return BraceStructure;
        }
        #endregion

        #region lab 11
        /// <summary>
        /// Реализует алгоритм поиска связанных компонент - 
        /// алгоритм Тарьяна
        /// </summary>
        public void Tarjan()
        {
            int index = 0;
            bool[] seen = new bool[NVertexes];
            int[] low = new int[NVertexes];
            bool[] onStack = new bool[NVertexes];
            Stack<int> stack = new Stack<int>();

            List<List<int>> result = new List<List<int>>();

            for (int i = 0; i < NVertexes; i++)
            {
                if (!seen[i])
                {
                    TarjanDFS(i, result, ref seen,
            ref low, ref onStack, ref stack, ref index);
                }
            }

            return;
        }
        /// <summary>
        /// Вспомогательная функция для алгоритма Тарьяна
        /// </summary>
        protected virtual void TarjanDFS(int node, List<List<int>> result, ref bool[] seen,
            ref int[] low, ref bool[] onStack, ref Stack<int> stack, ref int index)
        {
            seen[node] = true;
            low[node] = index;
            index++;
            stack.Push(node);
            onStack[node] = true;

            for (int i = 0; i < NVertexes; i++)
            {
                if (!Adjastent(node, i))
                    continue;

                if (!seen[i])
                {
                    TarjanDFS(node, result, ref seen,
                                        ref low, ref onStack, ref stack, ref index);
                    low[node] = Math.Min(low[node], low[i]);
                }
                else if (onStack[i])
                {
                    low[node] = Math.Min(low[node], low[i]);
                }
            }

            if (low[node] == index - 1)
            {
                List<int> component = new List<int>();

                int currentNode;
                do
                {
                    currentNode = stack.Pop();
                    onStack[currentNode] = false;
                    component.Add(currentNode);
                } while (currentNode != node);

                result.Add(component);
            }
        }

        #endregion

        #region lab 12
        /// <summary>
        /// Проверяет граф на наличие эйлерового цикла - 
        /// цикла, объединяющего все вершины
        /// </summary>
        /// <returns>
        /// True: такой цикл существует
        /// False: такого цикла не существует
        /// </returns>
        public bool HasEulerPath()
        {
            int oddVertex = 0;
            foreach (int vertex in this)
            {
                if (VertexDegree(vertex) % 2 == 1)
                    oddVertex++;
            }
            if (oddVertex > 2)
                return false;
            //check if connected
            bool[] visited = new bool[NVertexes];
            foreach (int vertex in this)
            {
                if (VertexDegree(vertex) > 0)
                {
                    DFS(vertex, ref visited);
                    break;
                }
            }
            foreach (int vertex in this)
            {
                if (VertexDegree(vertex) > 0 && !visited[vertex])
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Находит, если такой существует, эйлеров путь
        /// в графе, реализуя алгоритм Флери
        /// </summary>
        /// <returns>Последовательность вершин, 
        /// составляющая эйлеров путь</returns>
        public int[] GetEulerPath()
        {
            if (!HasEulerPath())
                throw new Exception("Граф не содержит эйлеров цикл");

            Graph temp = (Graph)this.Clone();
            List<int> res = new();
            GetEulerPath(FindOddVertex(), temp, res);
            return res.ToArray();
        }

        private int FindOddVertex()
        {
            foreach (int v in this)
            {
                if (VertexDegree(v) % 2 == 1)
                    return v;
            }
            return 0;
        }
        private void GetEulerPath(int vertex, Graph temp, List<int> path)
        {
            for (int i = 0; i < temp.NVertexes; i++)
            {
                if (!temp.Adjastent(vertex, i))
                    continue;
                // If edge u-v is a valid next edge
                if (temp.IsValidEdge(vertex, i, temp))
                {
                    path.Add(vertex);
                    path.Add(i);
                    temp.RemoveEdge(vertex, i);
                    GetEulerPath(i, temp, path);
                }
            }
        }

        private bool IsValidEdge(int vertex, int second, Graph temp)
        {
            int couter = 0;
            for (int i = 0; i < temp.NVertexes; i++)
            {
                if (i == vertex)
                    continue;
                if (temp.Adjastent(vertex, i))
                    couter++;
            }
            if (couter == 1)
            {
                return true;
            }

            // 2) If there are multiple adjacents, then
            // u-v is not a bridge
            // Do following steps 
            // to check if u-v is a bridge
            // 2.a) count of vertices reachable from u
            bool[] isVisited = new bool[temp.NVertexes];
            int count1 = temp.DfsCount(vertex, isVisited, temp);

            // 2.b) Remove edge (u, v) and after removing
            // the edge, count vertices reachable from u
            temp.RemoveEdge(vertex, second);
            isVisited = new bool[temp.NVertexes];
            int count2 = temp.DfsCount(vertex, isVisited, temp);

            // 2.c) Add the edge back to the graph
            temp.AddEgde(vertex, second, 1);
            return (count1 > count2) ? false : true;
        }

        private int DfsCount(int v, bool[] seen, Graph temp)
        {
            seen[v] = true;
            int count = 1;

            foreach (int i in temp)
            {
                if (temp.Adjastent(v, i))
                    if (!seen[i])
                    {
                        count = count + DfsCount(i, seen, temp);
                    }
            }
            return count;
        }


        /// <summary>
        /// Enumerator, поддерживающий перечисление по 
        /// всем вершинам графа
        /// </summary>
        /// <returns>Enumerator, поддерживающий перечисление по 
        /// всем вершинам графа</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
        /// <summary>
        /// Создает случайный граф
        /// </summary>
        /// <param name="N">Количество вершин в новом графе</param>
        /// <returns>Матрица смежности созданного случайного графа</returns>
        public static int[,] GetRandomGraph(int N)
        {
            RandomElemsCreate R = new RandomElemsCreate(N);
            return R.FillOriented();
        }
    }
    
    

    
}