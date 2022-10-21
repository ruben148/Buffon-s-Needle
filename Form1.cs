using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buffon_s_Needle
{
    public partial class Form1 : Form
    {
        private Random culoare = new Random();
        private Random rnd = new Random();
        private Random xrnd = new Random();
        private Random yrnd = new Random();
        double L, H;       
        double u;          
        double l;          
        long intersect = 0;  
        long total = 0;  
        Graphics desen; 

        public Form1()
        {
            InitializeComponent();
            desen = panel1.CreateGraphics(); 
            H = panel1.Height;
            L = panel1.Width;
        }

        void desen_linii() 
        {
            Pen p = new Pen(Color.Black, 2); 
            u = H / 3;  
            int x1, x2, y1, y2; 
            x1 = 0; 
            y1 = (int)u;
            x2 = (int)L;
            y2 = (int)u;
            desen.DrawLine(p, x1, y1, x2, y2);  
            x1 = 0;
            y1 = 2 * (int)u;
            x2 = (int)L;
            y2 = 2 * (int)u;
            desen.DrawLine(p, x1, y1, x2, y2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            u = H / 3;
            l = H / 6;  
            long i, n; 
            n = Convert.ToInt64(textBox1.Text); 
            double unghi, sin, cos; 
            double xc, yc, x1, x2, y1, y2; 
            Pen p1 = new Pen(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)), 2);
            Pen p2 = new Pen(Color.Red, 2);
            Pen p3 = new Pen(Color.Black, 2);
            for (i = 1; i <= n; i++, total++)
            {
                xc = rnd.NextDouble() * (L - 2 * l) + l;
                yc = rnd.NextDouble() * (H - 2 * l) + l;
                unghi = rnd.NextDouble() * 3.14159265359;
                cos = Math.Cos(unghi);
                sin = Math.Sin(unghi);
                x1 = xc + l * cos;
                y1 = yc + l * sin;
                x2 = xc + l * -cos;
                y2 = yc + l * -sin;
                if ((y2 <= u && y1 >= u) || (y2 <= 2 * u && y1 >= 2 * u))
                {
                    intersect++;
                    textBox2.Text = Convert.ToString(total);
                    textBox3.Text = Convert.ToString(intersect);
                    textBox4.Text = Convert.ToString(2.0 * total / intersect);
                    Application.DoEvents();
                    if (checkBox1.Checked == true)
                        if (checkBox2.Checked == true)
                        {
                            p1.Color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                            desen.DrawLine(p1, (int)x1, (int)y1, (int)x2, (int)y2);
                        }
                        else
                            desen.DrawLine(p3, (int)x1, (int)y1, (int)x2, (int)y2);
                }
                else 
                    if (checkBox1.Checked == true)
                        if (checkBox2.Checked == true)
                        {
                            p1.Color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                            desen.DrawLine(p1, (int)x1, (int)y1, (int)x2, (int)y2); 
                        }
                        else
                            desen.DrawLine(p2, (int)x1, (int)y1, (int)x2, (int)y2); 
            }
            textBox2.Text = Convert.ToString(total);
            textBox3.Text = Convert.ToString(intersect);
            textBox4.Text = Convert.ToString(2.0 * total / intersect);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            desen.Clear(Color.White);
            desen_linii();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            total = 0;
            intersect = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            desen.Clear(Color.White);
            desen_linii();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            u = H / 3;
            l = H / 6;
            long i, n;
            n = Convert.ToInt64(textBox1.Text);
            double unghi, sin, cos;
            double xc, yc, x1, x2, y1, y2;
            Pen p1 = new Pen(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)), 2);
            Pen p2 = new Pen(Color.Red, 2);
            Pen p3 = new Pen(Color.Black, 2);
            for (i = 1; i <= n; i++)
            {
                xc = rnd.NextDouble() * (L - 2 * l) + l;
                yc = rnd.NextDouble() * (H - 2 * l) + l;
                unghi = rnd.NextDouble() * 3.14159265359;
                cos = Math.Cos(unghi);
                sin = Math.Sin(unghi);
                x1 = xc + l * cos;
                y1 = yc + l * sin;
                x2 = xc + l * -cos;
                y2 = yc + l * -sin;
                if ((y2 <= u && y1 >= u) || (y2 <= 2 * u && y1 >= 2 * u))
                    intersect++;
            }
            total = total + n;
            textBox2.Text = Convert.ToString(total);
            textBox3.Text = Convert.ToString(intersect);
            textBox4.Text = Convert.ToString(2.0 * total / intersect);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            desen_linii();
        }
    }
}
