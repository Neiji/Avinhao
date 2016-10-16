using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avinhao
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Pen p;
        Graphics g;

        Timer timer = new Timer();

        int WIDTH = 300, HEIGHT = 300, HAND = 150;
        int u;
        int cx, cy;
        int x, y;

        int tx, ty, lim = 20;

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtX.Enabled = true;
            txtY.Enabled = true;

            txtA.Enabled = false;
            txtR.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtX.Enabled = false;
            txtY.Enabled = false;

            txtA.Enabled = true;
            txtR.Enabled = true;
        }

        private void ADD_Click(object sender, EventArgs e)
        {
            //Adicionamos na coordenada cartesiana
            if (radioButton1.Checked)
            {
                var imagem = Image.FromFile(Environment.CurrentDirectory + "/Resource/avinhao.bmp");
                var xImage = Convert.ToInt32(txtX.Text);
                var yImage = Convert.ToInt32(txtY.Text);
                g.DrawImage(imagem, xImage, yImage);
            }
            //Coordenada Polar
            else
            {

            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(WIDTH + 1, HEIGHT + 1);

            //this.BackColor = Color.Black;

            cx = WIDTH / 2;
            cy = HEIGHT / 2;


            u = 0;


            timer.Interval = 5;
            timer.Tick += new EventHandler(this.t_Tick);
            timer.Start();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            p = new Pen(Color.Green, 1f);

            g = Graphics.FromImage(bmp);


            int tu = (u - lim) % 360;

            if (u <= 0 && u <= 180)
            {
                x = cx + (int)(HAND * Math.Sin(Math.PI * u / 180));
                y = cy - (int)(HAND * Math.Cos(Math.PI * u / 180));
            }
            else
            {
                x = cx - (int)(HAND * -Math.Sin(Math.PI * u / 180));
                y = cy - (int)(HAND * Math.Cos(Math.PI * u / 180));
            }

            if (tu <= 0 && tu <= 180)
            {
                tx = cx + (int)(HAND * Math.Sin(Math.PI * tu / 180));
                ty = cy - (int)(HAND * Math.Cos(Math.PI * tu / 180));
            }
            else
            {
                tx = cx - (int)(HAND * -Math.Sin(Math.PI * tu / 180));
                ty = cy - (int)(HAND * Math.Cos(Math.PI * tu / 180));
            }

            g.DrawRectangle(p, 0, 0, WIDTH, HEIGHT);
            //g.DrawRectangle(p, 80, 80, WIDTH - 160, HEIGHT - 160);

            //Linha perpendicular
            g.DrawLine(p, new Point(cx, 0), new Point(cx, HEIGHT));
            g.DrawLine(p, new Point(0, cy), new Point(WIDTH, cy));

            //HAND
            //g.DrawLine(new Pen(Color.Black, 1f), new Point(cx, cy), new Point(tx, ty));
            //g.DrawLine(p, new Point(cx, cy), new Point(x, y));

            //load bitmap
            pictureBox1.Image = bmp;

            p.Dispose();
            g.Dispose();

            u++;
            if (u == 360)
            {
                u = 0;
            }



        }
    }
}
