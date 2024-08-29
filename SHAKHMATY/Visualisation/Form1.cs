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
        public static Pen prn = new Pen(Color.Blue, 12);
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

            EventedGraphOnADJList solution = new EventedGraphOnADJList(
                new GraphOnMatrixADJ(graph));

            gd = new(solution);
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
            Form2 form2 = new Form2(gd.SubGraph());
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
        public GraphWithEvents g;
        private Point[] centers;
        private (Point[], int)[] arrowsAndValues;
        public GraphDrawyer(GraphWithEvents g)
        {
            this.g = g;
            N = g.NVertexes;
            centers = GetCenters();
            arrowsAndValues = GetArrows(centers);
        }
        public void DrawDFS(Graphics canvas, Pen curVpen, Pen tempVpen)
        {
            g.VertexCheck += (g, evArgs) =>
            {
                canvas.DrawEllipse(curVpen, centers[evArgs.Vertex].X, centers[evArgs.Vertex].Y, r, r);
                Thread.Sleep(1000);
            };

            g.VertexAccept += (g, evArgs) =>
            {
                canvas.DrawEllipse(tempVpen, centers[evArgs.Vertex].X, centers[evArgs.Vertex].Y, r, r);
                Thread.Sleep(1000);
            };

            g.DFS();
            g.ClearEvents();

        }
        public void DrawBFS(Graphics canvas, Pen curVpen, Pen tempVpen)
        {
            g.VertexCheck += (g, evArgs) =>
            {
                canvas.DrawEllipse(curVpen, centers[evArgs.Vertex].X, centers[evArgs.Vertex].Y, r, r);
                Thread.Sleep(1000);
            };

            g.VertexAccept += (g, evArgs) =>
            { 
                canvas.DrawEllipse(tempVpen, centers[evArgs.Vertex].X, centers[evArgs.Vertex].Y, r, r);
                Thread.Sleep(1000);
            };

            g.BFS();

            g.ClearEvents();
        }

        public GraphWithEvents SubGraph()
        {
            return new EventedGraphOnADJList(g.SubGraph());
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

                (double len, double angle) = CalcRPhi(x1, y1, x2, y2);

                angle = -angle;
                int xOffset = (int)(Math.Cos(angle) * ( r));
                int yOffset = (int)(Math.Sin(angle) * ( r));

                Point start = new(x1, y1);
                Point end = new Point(x2, y2);
                start.Offset(-xOffset, -yOffset);

                GraphicsPath capPath = new GraphicsPath();
                capPath.AddLine(-1, 0, 1, 0);
                capPath.AddLine(-1, 0, 0, 1);
                capPath.AddLine(0, 1, 1, 0);

                arrowPen.CustomEndCap =  new CustomLineCap(null, capPath);
                canvas.DrawLine(arrowPen, end, start);
                canvas.DrawString(arrowsAndValues[i].Item2.ToString(), f, b, (x1+x2)/2, (y1+y2)/2 );

            }
        }
        private (double len, double phi) CalcRPhi(int x1, int y1, int x2, int y2)
        {
            int y = y2 - y1, x = x2 - x1;
            int quater;
            if (x >= 0 && y >= 0)
                quater = 1;
            if (x <= 0 && y >= 0)
                quater = 2;
            if (x <= 0 && y <= 0)
                quater = 3;
            else
                quater = 4;


            double len = Math.Sqrt(
                    Math.Pow(x,2) + Math.Pow(y, 2)
                    );
            double phi = PhiParse(x, y, quater);
            
            return (len, Math.PI - phi);

        }

        private double PhiParse(int x, int y, int quater)
        {
            double absATan = Math.Atan(
                    Math.Abs((double)y) / Math.Abs((double)x)
                    );
            if (quater == 1)
            {
                return x == 0 ?
                Math.PI / 2 :
                absATan;
            }
            if (quater == 2)
            {
                return x == 0 ?
                Math.PI / 2 :
                Math.PI - absATan;
            }
            if (quater == 3)
            {
                return x == 0 ?
                -Math.PI / 2 :
                Math.PI + absATan;
            }
            else
            {
                return x == 0 ?
                -Math.PI / 2 :
                -absATan;

            }
        }
        private (Point[], int)[] GetArrows(Point[] centers)
        {
            List<(Point[], int)> arrows = new List<(Point[], int)>();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (g.GetEdgeValue(i, j) != default(int))
                    {
                        Point p1 = centers[i];
                        Point p2 = centers[j];
                        p1.Offset(r / 2, r / 2);
                        p2.Offset(r / 2, r / 2);
                        arrows.Add((new Point[] { p2, p1 }, g.GetEdgeValue(i, j)));
                    }
                }
            }
            return arrows.ToArray();
        }

        private Point[] GetCenters()
        {
            Point[] centers = new Point[N];


            int x = horMargin - horStep, y = vertMargin - vertStep;

            g.VertexCheck += (g, evArgs) =>
            {
                centers[evArgs.Vertex] = new(x, y);
                x = x + horStep;
            };

            g.VertexAccept += (g, evArgs) =>
            {
                y = y + vertStep;
            };

            g.DFS();

            g.ClearEvents();
            return centers;
        }

    }
}