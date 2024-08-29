using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsADT__L10to12_
{
    public abstract class GraphWithEvents : Graph
    {
        #region ОБРАБОТКА СОБЫТИЙ 
        public class GraphEventArgs : EventArgs
        {
            public int Vertex { get => _vertex; }

            protected int _vertex;

            public GraphEventArgs(int vertex)
            {
                _vertex = vertex;
            }
        }

        public event CheckVertexEventHandler VertexCheck;

        public delegate void CheckVertexEventHandler
            (GraphWithEvents sender, GraphEventArgs e);


        public event CheckVertexEventHandler VertexAccept;

        public delegate void AcceptVertexEventHandler
            (GraphWithEvents sender, GraphEventArgs e);

        private void CheckVertex(int vertex)
        {
            if (VertexCheck != null)
            {
                VertexCheck(this, new(vertex));
            }
        }

        private void AcceptVertex(int vertex)
        {
            if (VertexAccept != null)
            {
                VertexAccept(this, new(vertex));
            }
        }
        #endregion
        #region ДФС И БФС с событиями
        public override void DFS(int start, ref bool[] seen)
        {
            int curV = start < 0 || start > NVertexes ?
                0 : start;
            Stack<int> vertexes = new Stack<int>();

            seen[curV] = true;
            vertexes.Push(curV);

            while (vertexes.Count > 0)
            {
                curV = vertexes.Peek();

                CheckVertex(curV);

                int checkV = FindAdjNotSeen(curV, ref seen);
                if (checkV != -1)
                {
                    vertexes.Push(checkV);
                    seen[checkV] = true;

                    AcceptVertex(checkV);
                }
                else
                {
                    curV = vertexes.Pop();
                }
            }
        }

        public override void BFS(int start, ref bool[] seen)
        {
            int curV = start < 0 || start > NVertexes ?
                0 : start;
            Queue<int> vertexes = new Queue<int>();

            seen[curV] = true;
            vertexes.Enqueue(curV);

            while (vertexes.Count > 0)
            {
                curV = vertexes.Peek();

                CheckVertex(curV);

                int checkV = FindAdjNotSeen(curV, ref seen);
                if (checkV != -1)
                {
                    vertexes.Enqueue(checkV);
                    seen[checkV] = true;

                    AcceptVertex(checkV);
                }
                else
                {
                    curV = vertexes.Dequeue();
                }
            }
        }
        #endregion

        public void ClearEvents()
        {
            VertexCheck = null;
            VertexAccept = null;
        }
    }
}
