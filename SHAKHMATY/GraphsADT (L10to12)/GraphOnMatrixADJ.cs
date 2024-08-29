using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsADT__L10to12_
{
    public class GraphOnMatrixADJ : Graph
    {
        protected int[,] matrixADJ { get; set; }
        public GraphOnMatrixADJ(int[,] matrixADJ)
        {
            this.matrixADJ = matrixADJ;
            NVertexes = matrixADJ.GetLength(0);
        }
        public GraphOnMatrixADJ()
        {
            matrixADJ = new int[1, 1];
            NVertexes = 1;
        }
        public GraphOnMatrixADJ(int N)
        {
            matrixADJ = new int[N, N];
            NVertexes = N;
        }
        public override int GetVertexWithNoCons()
        {
            for (int i = 0; i < NVertexes; i++)
            {
                bool hasNoCons = true;
                for (int j = 0; j < NVertexes; j++)
                {
                    if (Adjastent(j, i))
                        hasNoCons = false;
                }
                if (hasNoCons)
                    return i;
            }
            return -1;
        }
        public override void AddEgde(int from, int to, int cost = 1)
        {
            if (from >= NVertexes || to >= NVertexes)
            {
                int newN = Math.Max(from, to) + 1;
                int[,] newMat = new int[newN, newN];
                for ( int i = 0; i < NVertexes; i++)
                {
                    for (int j = 0; j < NVertexes; j++)
                    {
                        newMat[i, j] = matrixADJ[i, j];
                    }
                }
                matrixADJ = newMat;
                NVertexes = matrixADJ.GetLength(0);
            }
            matrixADJ[from, to] = cost;
        }
        public override void RemoveEdge(int from, int to)
        {
            matrixADJ[from, to] = 0;
            matrixADJ[to, from] = 0;
        }
        public override bool Adjastent(int V1, int V2)
        {
            return matrixADJ[V1, V2] != 0;
        }
        public override int FindAdjNotSeen(int V, ref bool[] seen)
        {
            for (int i = 0; i < NVertexes; i++)
            {
                if (i != V && Adjastent(V, i) && !seen[i])
                    return i;
            }
            return -1;
        }

        public override int GetEdgeValue(int from, int to)
        {
            return matrixADJ[from, to];
        }

        public new GraphOnMatrixADJ SubGraph()
        {
            GraphOnMatrixADJ graph = (GraphOnMatrixADJ)base.SubGraph();
            return graph;
        }

        public override int VertexDegree(int vertex)
        {
            int counter = 0;
            foreach (int V in this)
            {
                if (Adjastent(V, vertex))
                    counter++; 
                if (Adjastent(vertex, V))
                    counter++;
            }
            return counter;
        }

        public override IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < NVertexes; i++)
            {
                yield return i;
            }
            yield break;
        }

        public override object Clone()
        {
            int[,] mat = (int[,])this.matrixADJ.Clone();
            return new GraphOnMatrixADJ(mat);
        }
    }
}
