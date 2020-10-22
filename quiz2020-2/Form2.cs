using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quiz2020_2
{
    public partial class Form2 : Form
    {
        public Form1 myparent = null;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush br = new SolidBrush(core.toolbox.get_color());
            if (myparent.isClick) g.DrawRectangle(Pens.Red, myparent.square.X - 1, myparent.square.Y - 1, myparent.square.Width + 2, myparent.square.Height + 2);
            else g.FillRectangle(br, myparent.square);
        }
    }
}
