using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_22
{
    public partial class Form1 : Form
    {
        Bitmap off;
        Bitmap b1;
        Bitmap b2;
        PointF tom = new PointF(100, 100);
        PointF jerry = new PointF(600, 500);
        PolarCircle circ = new PolarCircle(250, 250, 250);
        int xc;
        int yc;
        int xtom;
        int ytom;
        int flagcircle = 0;
        int flag = 0;
        int start = -45;
        int end = 45;
        int v = 90;
        Timer t;
        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            Paint += Form1_Paint;
            KeyDown += Form1_KeyDown;
            MouseDown += Form1_MouseDown;
            t = new Timer();
            t.Tick += T_Tick;
            t.Start();
            InitializeComponent();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                t.Stop();
            }
            if (start <= -v)
            {
                flagcircle = 1;
            }
            if (end >= v)
            {
                flagcircle = 0;
            }
            if (start >= -v && flagcircle == 0)
            {
                start -= 23;
                end -= 23;

            }
            if (end <= v && flagcircle == 1)
            {
                start += 23;
                end += 23;

            }
            if ((jerry.X <= circ.L1.xe && jerry.X >= circ.L1.xs || jerry.X + 5 <= circ.L2.xe && jerry.X >= circ.L1.xs) && jerry.Y + 30 <= circ.L1.ye && jerry.Y + 30 >= circ.L2.ye)
            {
                flag = 1;
            }

            DrawDubb(this.CreateGraphics());
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            xtom = e.X - 150;
            ytom = e.Y - 150;
            tom = new PointF(xtom, ytom);
            circ = new PolarCircle(xtom + 150, ytom + 150, 250);
            flagcircle = 1;


            DrawDubb(this.CreateGraphics());
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                jerry.Y -= 5;

            }
            if (e.KeyCode == Keys.Down)
            {
                jerry.Y += 5;

            }
            if (e.KeyCode == Keys.Left)
            {
                jerry.X -= 5;

            }
            if (e.KeyCode == Keys.Right)
            {
                jerry.X += 5;

            }
            if (e.KeyCode == Keys.Space)
            {
                v += 23;
                end += 23;

            }


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            b1 = new Bitmap("1.bmp");
            b2 = new Bitmap("2.bmp");
            b2.MakeTransparent(b2.GetPixel(1, 1));
            b1.MakeTransparent(b1.GetPixel(1, 1));


        }
        void DrawScene(Graphics g)
        {

            g.Clear(Color.White);
            circ.Drawcirc1(g, 1, start, end);
            if (flag == 1)
            {
                PolarCircle C = new PolarCircle(xtom + 150, ytom + 150, 400);
                C.Drawcirc2(g, 2, 0, 360);

            }


            g.DrawImage(b1, jerry);
            g.DrawImage(b2, tom);









        }



        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);

        }
    }
}
