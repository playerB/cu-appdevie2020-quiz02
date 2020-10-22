using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quiz2020_2
{
    public partial class Form1 : Form
    {
        Form2 frm2 = new Form2();
        public Form1()
        {
            InitializeComponent();
            frm2.Show();
            button2.Enabled = false;
        }
        Random rd = new Random();
        public Rectangle square = new Rectangle(300, 300, 20, 20);
        double timeCount = 0;
        public bool isClick = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (openPicture.ShowDialog() != DialogResult.OK) return;
            Bitmap bm = new Bitmap(openPicture.FileName);
            pictureBox1.Image = new Bitmap(bm, pictureBox1.Size);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeCount += 1;
            label1.Text = (timeCount / 10).ToString() + " second";
            if (timeCount >= 50)
            {
                timer1.Stop();
                MessageBox.Show("หมดเวลา");
                return;
            }
            if (timeCount % 5 == 0)
            {
                square.X = rd.Next(pictureBox1.Width - square.Width);
                square.Y = rd.Next(pictureBox1.Height - square.Height);
                Refresh();
                frm2.Refresh();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isClick = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isClick = false;
            timer1.Start();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClick)
            {
                square.X = e.X;
                square.Y = e.Y;
                Refresh();
                frm2.Refresh();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush br = new SolidBrush(core.toolbox.get_color());
            if (isClick) g.DrawRectangle(Pens.Red, square.X - 1, square.Y - 1, square.Width + 2,  square.Height + 2);
            else g.FillRectangle(br, square);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm2.Show();
            button2.Enabled = false;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm2.Hide();
            button2.Enabled = true;
            button3.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            frm2.myparent = this;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
            sw.WriteLine(square.Width.ToString() + ',' + square.Height.ToString());
            sw.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            StreamReader sr = new StreamReader(openFileDialog1.FileName);
            string n = sr.ReadToEnd();
            string[] size = n.Split(',');
            square.Width = Convert.ToInt32(size[0]);
            square.Height = Convert.ToInt32(size[1]);
            Refresh();
            frm2.Refresh();
        }
    }
}
