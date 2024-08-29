using GraphsADT__L10to12_;
using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Visualisation
{
    
    public partial class Form1 : Form
    {
        internal Graphics g;
        internal GraphDrawyer gd;
        public static Pen pen = new Pen(Color.Black, 20);
        public static Pen prn = new Pen(Color.Blue, 10);
        public static Brush brush = new SolidBrush(Color.Black);
        public static Font font = new Font("Times New Roman", 25);
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Update();

            int[,] graph = Graph.GetRandomGraph(int.Parse(txBx_NOfVs.Text));
            GraphOnMatrixADJ gr = new GraphOnMatrixADJ(graph);

            gd = new(gr);
            gd.Draw(g, pen, prn, font, brush);

        }

        private void btn_DFS_Click(object sender, EventArgs e)
        {
            gd.DrawCircles(g, pen);
            Pen inPen = new Pen(Color.Red, 20);
            Pen outPen = new Pen(Color.Gray, 20);
            gd.DrawDFS(g, inPen, outPen);
        }

        private void btn_BFS_Click(object sender, EventArgs e)
        {
            gd.DrawCircles(g, pen);
            Pen inPen = new Pen(Color.Red, 20);
            Pen outPen = new Pen(Color.Gray, 20);
            gd.DrawBFS(g, inPen, outPen);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string header = "Все пути в графе";
            string text = gd.g.PrintCostOfAllWays();
            Form2 form2 = new Form2(header, text);
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string header = "Скобочная структура";
            string text = gd.g.PrintBraceStructure();
            Form2 form2 = new Form2(header, text);
            form2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string header = "Время посещения вершин";
            string text = gd.g.PrintTimeOfEntries();
            Form2 form2 = new Form2(header, text);
            form2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(gd.g.SubGraph());
            form2.Show();
        }
    }

    public class GraphDrawyer
    {
        private int N;
        private const int r = 50;
        private const int vertMargin = 150;
        private const int horMargin = 150;
        private const int vertStep = 100;
        private const int horStep = 125;
        public GraphOnMatrixADJ g;
        private Point[] centers;
        private (Point[], int)[] arrowsAndValues;
        public GraphDrawyer(GraphOnMatrixADJ g)
        {
            this.g = g;
            N = g.NVertexes;
            centers = GetCenters();
            arrowsAndValues = GetArrows(centers);
        }
        public void DrawDFS(Graphics canvas, Pen curVpen, Pen tempVpen)
        {
            bool[] seen = new bool[N];
            int curV = g.GetVertexWithNoCons();
            curV = curV == -1 ? 1 : curV;
            Stack<int> vertexes = new Stack<int>();
            seen[curV] = true;
            vertexes.Push(curV);

            canvas.DrawEllipse(curVpen, centers[curV].X, centers[curV].Y, r, r);


            while (vertexes.Count > 0)
            {
                curV = vertexes.Peek();
                int checkV = g.FindAdjNotSeen(curV, ref seen);
                Thread.Sleep(1000);
                if (checkV != -1)
                {
                    vertexes.Push(checkV);
                    seen[checkV] = true;

                    canvas.DrawEllipse(tempVpen, centers[checkV].X, centers[checkV].Y, r, r);
                    Thread.Sleep(1000);
                }
                else
                {
                    curV = vertexes.Pop();
                    canvas.DrawEllipse(curVpen, centers[curV].X, centers[curV].Y, r, r);
                }
            }


        }
        public void DrawBFS(Graphics canvas, Pen curVpen, Pen tempVpen)
        {
            Queue<int> vertexes = new();
            //make all of them unseen
            bool[] seen = new bool[N];

            int curV = g.GetVertexWithNoCons();
            seen[curV] = true;

            canvas.DrawEllipse(curVpen, centers[curV].X, centers[curV].Y, r, r);
            Thread.Sleep(1000);

            do
            {
                int tempV = g.FindAdjNotSeen(curV, ref seen);
                bool has = tempV != -1;

                if (has)
                {
                    vertexes.Enqueue(tempV);
                    seen[tempV] = true;
                    canvas.DrawEllipse(tempVpen, centers[tempV].X, centers[tempV].Y, r, r);
                }
                else
                {
                    if (vertexes.Count == 0)
                        break;
                    curV = vertexes.Dequeue();
                    canvas.DrawEllipse(curVpen, centers[curV].X, centers[curV].Y, r, r);
                }
                Thread.Sleep(1000);
            } while (true);

        }
        public void DrawCircles(Graphics canvas, Pen circlePen)
        {
            foreach (Point point in centers)
            {
                canvas.DrawEllipse(circlePen, point.X, point.Y, r, r);
            }
        }
        public void Draw(Graphics canvas, Pen circlePen, Pen arrowPen, Font f, Brush b)
        {
            char c = 'A';
            DrawCircles(canvas, circlePen);
            for (int i = 0; i < N; i++)
            {
                string letter = Convert.ToString((char)(c + i));
                int x = centers[i].X;
                int y = centers[i].Y + f.Height + (int)circlePen.Width;
                Point p = new Point(x, y);
                canvas.DrawString(letter, f, b, p);
            }
            for (int i = 0; i < arrowsAndValues.Length; i++)
            {
                int x1 = arrowsAndValues[i].Item1[0].X;
                int x2 = arrowsAndValues[i].Item1[1].X;
                int y1 = arrowsAndValues[i].Item1[0].Y;
                int y2 = arrowsAndValues[i].Item1[1].Y;

                //(double len, double angle) = CalcRPhi(x1, y1, x2, y2);
                //len -= r;
                //int xOffset =  (int) (len - Math.Sin(angle) * len);
                //int yOffset = (int) (Math.Cos(angle) * len);

                GraphicsPath capPath = new GraphicsPath();
                capPath.AddLine(-1, 0, 1, 0);
                capPath.AddLine(-1, 0, 0, 1);
                capPath.AddLine(0, 1, 1, 0);

                Point start = new Point(x1, y1);
                Point end = new Point(x2, y2);

                arrowPen.CustomEndCap =  new CustomLineCap(null, capPath);
                canvas.DrawLine(arrowPen, end, start);
                canvas.DrawString(arrowsAndValues[i].Item2.ToString(), f, b, (x1+x2)/2, (y1+y2)/2 );

            }
        }
        private (double len, double phi) CalcRPhi(int x1, int y1, int x2, int y2)
        {
            double len = Math.Sqrt(
                    Math.Pow((x2 - x1),2) + Math.Pow((y2 - y1), 2)
                    );
            double phi = (x2 - x1) == 0 ? 
                Math.PI / 2 : 
                Math.Atan(
                    (double)(y2 - y1) / (double)(x2 - x1)
                    );
            return (len, - phi);

        }
        private (Point[], int)[] GetArrows(Point[] centers)
        {
            int[, ]mat = g.matrixADJ;
            List<(Point[], int)> arrows = new List<(Point[], int)>();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (mat[i, j] != default(int))
                    {
                        Point p1 = centers[i];
                        Point p2 = centers[j];
                        p1.Offset(r / 2, r / 2);
                        p2.Offset(r / 2, r / 2);
                        arrows.Add((new Point[] { p1, p2 }, mat[i,j]));
                    }
                }
            }
            return arrows.ToArray();
        }

        private Point[] GetCenters()
        {
            Point[] centers = new Point[N];
            int x = horMargin, y = vertMargin;

            //dfs
            Stack<int> vertexes = new();
            //make all of them unseen
            bool[] seen = new bool[N];

            int curV = g.GetVertexWithNoCons();
            seen[curV] = true;
            centers[curV] = new Point(x, y);

            do
            {
                int tempV = g.FindAdjNotSeen(curV, ref seen);
                bool has = tempV != -1;

                if (has)
                {
                    x += horStep;
                    vertexes.Push(tempV);
                    seen[tempV] = true;
                    centers[tempV] = new Point(x, y);
                }
                else
                {
                    y += vertStep;
                    if (vertexes.Count == 0)
                        break;
                    curV = vertexes.Pop();
                }
            } while (true);

            return centers;
        }
    }
}