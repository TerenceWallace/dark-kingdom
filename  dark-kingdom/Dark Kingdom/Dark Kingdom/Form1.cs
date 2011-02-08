using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using csharpdrawing;

namespace Dark_Kingdom
{
    public partial class Form1 : Form
    {
        Bitmap b;
        long t = DateTime.Now.Ticks; // nahazet do naky tridy
        int fps = 0; // nahazet do naky tridy
        BitmapCanvas img = new BitmapCanvas(640, 480);
        Point oldPos;
        int frames = 0; // nahazet do naky tridy
        
        public Form1()
        {
            InitializeComponent();
            b = new Bitmap(640, 480);
            for (int x = 0; x < b.Width; x++)
                for (int y = 0; y < b.Height; y++)
                    b.SetPixel(x, y, Color.FromArgb(x % 256, y % 256, 0));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void draw(Graphics g)
        {
            fps++;
            frames++;
            img.Clear(0);

            if (DateTime.Now.Ticks - t >= 10000000)
            {
                Text = fps + " fps";
                fps = 0;
                t = DateTime.Now.Ticks;
            }

            g.DrawImageUnscaled(img.GetBitmap(), 0, 0, b.Width, b.Height);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            draw(e.Graphics);

            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (oldPos == null) oldPos = new Point(e.X, e.Y);

            oldPos = new Point(e.X, e.Y);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W: {  } break;
                case Keys.S: {  } break;
                case Keys.A: {  } break;
                case Keys.D: {  } break;
                case Keys.R: {  } break;
                case Keys.F: {  } break;
                case Keys.Escape: { Application.Exit(); } break;
            }
        }
    }
}
