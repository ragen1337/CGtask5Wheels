using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CGtask5Wheels
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics g;
        Graphics fG;
        Bitmap btm;

        bool drawing = false;

        public void Draw(float rad)
        {
            float angle = 0.0f;
            PointF org;

            Pen pen = new Pen(Brushes.Black, 4.0f);
            RectangleF area;

            PointF loc1 = PointF.Empty;
            PointF loc2 = PointF.Empty;
            PointF img = new PointF(370, 500);

            int k = 0;
            while (drawing && k < 1000)4
            {
                g.Clear(Color.FromArgb(104,161,126));

                for(int j = 0; j < 4; j++)
                {
                    org = new PointF(rad + j * rad *2, rad);
                    area = new RectangleF(0 + j*rad*2, 0, rad * 2, rad * 2);
                    g.DrawEllipse(pen, area);

                    for (int i = 0; i <= 10; i++)
                    {
                        loc1 = CirclePoint(rad, angle + 30 * i, org);

                        loc2 = CirclePoint(rad, angle + 30 * i + 180, org);

                        g.DrawLine(pen, loc1, loc2);
                    }
                }
               
                fG.DrawImage(btm, img);

                if (angle < 360)
                {
                    angle += 0.5f;
                }
                else
                {
                    angle = 0;
                }

                k++;
            }
        }

        public PointF CirclePoint(float radius, float angleInDegrees, PointF origin)
        {
            float x = (float)(radius * Math.Cos(angleInDegrees * Math.PI / 180F)) + origin.X;
            float y = (float)(radius * Math.Sin(angleInDegrees * Math.PI / 180F)) + origin.Y;

            return new PointF(x, y);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            float rad = 76;
            btm = new Bitmap((int)rad*8, (int)rad*2);

            g = Graphics.FromImage(btm);
            fG = CreateGraphics();

            drawing = !drawing;

            Draw(rad);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            float rad = 76;
            btm = new Bitmap((int)rad * 8, (int)rad * 2);

            g = Graphics.FromImage(btm);
            fG = CreateGraphics();

            drawing = !drawing;

            Draw(rad);
        }
    }
}
