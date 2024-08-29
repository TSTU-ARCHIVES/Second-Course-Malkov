using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const int MAX_AMOUNT = 6600;
        const int step = 200;
        const int Mod = 1000;

        public long CalcTimeShell(int[] ints)
        {

            int[] arr = new int[ints.Length];
            Array.Copy(ints, arr, ints.Length);
            Sorter<int> sorter = new Sorter<int>(arr);
            Stopwatch s = Stopwatch.StartNew();
            sorter.ShellSort();
            return s.ElapsedMilliseconds;
        }
        public long CalcTimeSelect(int[] ints) {

            int[] arr = new int[ints.Length];
            Array.Copy(ints, arr, ints.Length);
            Sorter<int> sorter = new Sorter<int>(arr);
            Stopwatch s = Stopwatch.StartNew();
            sorter.SelectSort();
            return s.ElapsedMilliseconds;
        }

        public long CalcTimeBubble(int[] ints)
        {
            int[] arr = new int[ints.Length];
            Array.Copy(ints, arr, ints.Length);
            Sorter<int> sorter = new Sorter<int>(arr);
            Stopwatch s = Stopwatch.StartNew();
            sorter.BubbleSort();
            return s.ElapsedMilliseconds;
        }

        public long CalcTimeInsert(int[] ints)
        {
            int[] arr = new int[ints.Length];
            Array.Copy(ints, arr, ints.Length);
            Sorter<int> sorter = new Sorter<int>(arr);
            Stopwatch s = Stopwatch.StartNew();
            sorter.InsertSort();
            return s.ElapsedMilliseconds;
        }

        public long CalcTimeHeap(int[] ints)
        {
            int[] arr = new int[ints.Length];
            Array.Copy(ints, arr, ints.Length);
            Sorter<int> sorter = new Sorter<int>(arr);
            Stopwatch s = Stopwatch.StartNew();
            sorter.HeapSort();
            return s.ElapsedMilliseconds;
        }

        public long CalcTimeFast(int[] ints)
        {
            int[] arr = new int[ints.Length];
            Array.Copy(ints, arr, ints.Length);
            Sorter<int> sorter = new Sorter<int>(arr);
            Stopwatch s = Stopwatch.StartNew();
            sorter.FastSort();
            return s.ElapsedMilliseconds;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
            chart1.Series[4].Points.Clear();
            chart1.Series[5].Points.Clear();

            chart1.Series[0].ChartType = SeriesChartType.FastLine;
            chart1.Series[1].ChartType = SeriesChartType.FastLine;
            chart1.Series[2].ChartType = SeriesChartType.FastLine;
            chart1.Series[3].ChartType = SeriesChartType.FastLine;
            chart1.Series[4].ChartType = SeriesChartType.FastLine;
            chart1.Series[5].ChartType = SeriesChartType.FastLine;


            for (int i = 1; i < MAX_AMOUNT; i += step)
            {
                int[] ints = Sorter<int>.CreateRandom(-Mod, Mod, i);
                chart1.Series[2].Points.AddXY(i, CalcTimeHeap(ints));
                chart1.Series[3].Points.AddXY(i, CalcTimeFast(ints));
                chart1.Series[0].Points.AddXY(i, CalcTimeBubble(ints));
                chart1.Series[1].Points.AddXY(i, CalcTimeInsert(ints));
                chart1.Series[4].Points.AddXY(i, CalcTimeSelect(ints));
                chart1.Series[5].Points.AddXY(i, CalcTimeShell(ints));
            }
        }
    }
}
