using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphsADT__L10to12_;
namespace Visualisation
{
    public partial class Form2 : Form
    {
        public Form2(string header, string text)
        {
            InitializeComponent();
            pictureBox1.Visible = false;
            Header.Text = header;
            TextB.Text = text;
        }
        public Form2(GraphWithEvents graph)
        {
            InitializeComponent();
            TextB.Visible = true;
            Graphics g = pictureBox1.CreateGraphics();
            GraphDrawyer graphDrawyer = new GraphDrawyer(graph);
            g.Clear(Color.White);
            graphDrawyer.Draw(g, Form1.pen, Form1.prn, Form1.font, Form1.brush);
        }
    }
}
