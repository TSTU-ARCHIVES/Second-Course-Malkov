using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsADT__L10to12_
{
    public class EventedGraphOnADJList : GraphWithEvents
    {
        protected Dictionary<int, List<int[]>> ADJList { get; }
        public EventedGraphOnADJList(Dictionary<int, List<int[]>> ADJList)
        {
            this.ADJList = ADJList;
            NVertexes = ADJList.Count;
        }
        public EventedGraphOnADJList()
        {
            ADJList = new Dictionary<int, List<int[]>>();
            NVertexes = 0;
        }
        public EventedGraphOnADJList(Graph g)
        {
            ADJList = new Dictionary<int, List<int[]>>();
            foreach (int i in g)
            {
                for (int j = 0; j < g.NVertexes; j++)
                {
                    if (g.GetEdgeValue(i, j) != 0)
                    {
                        AddEgde(i, j, g.GetEdgeValue(i, j));
                    }
                }
            }
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
            if (!ADJList.ContainsKey(from))
            {
                ADJList.Add(from, new List<int[]>() { new int[] { to, cost } });
                NVertexes++;
            }
            else
            {
                ADJList[from].Add(new int[] { to, cost });
            }
        }

        public override void RemoveEdge(int from, int to)
        {
            if (!ADJList.ContainsKey(from))
            {
                return;
            }
            else
            {
                List<int[]> row = ADJList[from];
                for (int i = 0; i < row.Count; i++)
                {
                    if (row[i][0] == to)
                    {
                        row.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        public override int GetEdgeValue(int from, int to)
        {
            if (!ADJList.ContainsKey(from) && from < ADJList.Keys.Max() )
            {
                if ( to < ADJList.Keys.Max())
                {
                    return default(int);
                }
            }
            for (int i = 0; i < ADJList[from].Count; i++)
            {
                if (ADJList[from][i][0] == to)
                    return ADJList[from][i][1];
            }
            return 0;
        }

        public override bool Adjastent(int V1, int V2)
        {
            if (!ADJList.ContainsKey(V1))
                return false;
            foreach (int[] VertValPair in ADJList[V1!])
            {
                if (VertValPair[0] == V2)
                    return true;
            }

            return false;
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
        public new GraphOnADJList SubGraph()
        {
            GraphOnADJList graph = (GraphOnADJList)base.SubGraph();
            return graph;
        }

        public override int VertexDegree(int vertex)
        {
            return ADJList[vertex].Count;
        }
        public override IEnumerator<int> GetEnumerator()
        {
            return this.ADJList.Keys.GetEnumerator();
        }

        public override object Clone()
        {
            Dictionary<int, List<int[]>> dict = this.ADJList;
            return new GraphOnADJList(dict);
        }
    }
}
