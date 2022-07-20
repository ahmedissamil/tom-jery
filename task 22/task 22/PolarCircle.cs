using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace task_22
{
    public class PolarCircle
    {
        public float XC;
        public float YC;
        public int R;
        public DDALine L1;
        public DDALine L2;
        public DDALine L3;
        public float x=0;
        public float y=0;
        public int flag = 0;
        public bool flagstop = false;
        public PointF move;
        public PointF move2;
        public PolarCircle(int xcent,int ycent, int rad)
        {
            XC = xcent;
            YC = ycent;
            R = rad;
        }
        public void Drawcirc1( Graphics g , int gap, int sangle,int v)
        {
            float angle = sangle;
            move = new PointF(XC, YC);
            while (angle < v)
            {
                float thRadian = (float)(angle * Math.PI / 180);
                 x = (float)(R * Math.Cos(thRadian)) + XC;
                 y = (float)(R * Math.Sin(thRadian)) + YC;
              
                  L1 = new DDALine(XC, YC, (int)x, (int)y);
                if(flag==0)
                {
                    L2 = new DDALine(XC, YC, (int)x, (int)y);
                    flag = 1;
                }
                   
            
                g.DrawLine(Pens.Red,L1.xs,L1.ys, L1.xe, L1.ye);
                angle += gap;
                
            }
          //  L2 = new DDALine(XC, YC, (int)x, (int)y);
           //.FillEllipse(Brushes.Yellow, XC, YC, 5, 5);
        }
        public void Drawcirc2(Graphics g, int gap, int sangle, int v)
        {
            float angle = sangle;
            move = new PointF(XC, YC);
            while (angle < v)
            {
                float thRadian = (float)(angle * Math.PI / 180);
                x = (float)(R * Math.Cos(thRadian)) + XC;
                y = (float)(R * Math.Sin(thRadian)) + YC;

                L1 = new DDALine(XC, YC, (int)x, (int)y);



                g.FillEllipse(Brushes.Yellow, x,y, 5, 5);
                angle += gap;

            }
            L2 = new DDALine(XC, YC, (int)x, (int)y);
            //.FillEllipse(Brushes.Yellow, XC, YC, 5, 5);
        }
        public PointF getnextpoint(float angle)
        {
            float thRadian = (float)(angle * Math.PI / 180);
            float x = (float)(R * Math.Cos(thRadian)) + XC;
            float y = (float)(R * Math.Sin(thRadian)) + YC;
            PointF pnn = new PointF(x, y);
            return pnn;
        }
        public PointF getnextpointcircle(float cx, float cy)
        {
            float dx = move2.X - XC;
            float dy = move2.Y - YC;
            float m = dy / dx;
            int speed = 25;
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                if (XC < move2.X)
                {
                    cx += speed;
                    cy += m * speed;
                    if (cx >= move2.X)
                    {
                        //if (flagd == 1)
                        //    flagd = 0;
                        //else
                        //    flagd = 1;
                        flagstop = true;
                    }
                }
                else
                {
                    cx -= speed;
                    cy -= m * speed;
                    if (cx <= move2.X)
                    {
                        flagstop = true;
                    }
                }

            }
            else
            {
                if (YC < move2.Y)
                {
                    cy += speed;
                    cx += (1 / m) * speed;
                    if (cy >= move2.Y)
                    {
                        flagstop = true;
                    }
                }
                else
                {
                    cy -= speed;
                    cx -= (1 / m) * speed;
                    if (cy <= move2.Y)
                    {
                        flagstop = true;
                    }
                }

            }
            PointF pnn = new PointF(cx, cy);
            return pnn;
        }
    }

}
