using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 단진자_프로그램_20519_임지훈
{
    public partial class Form1 : Form
    {

        const int len = 200;

        private double x;
        private double y;
        private double angle = 1;
        private double aAcc;
        private double aVel;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tmrPendulum.Start();
        }

        private void tmrPendulum_Tick(object sender, EventArgs e)
        {
            x = (this.Width - 50) / 2 + len * Math.Sin(angle);
            y = len * Math.Cos(angle);

            aAcc = -0.001 * Math.Sin(angle);

            angle += aVel;
            aVel += aAcc;

            aVel *= 0.99;

            if (aAcc > 0)
            {
                lblAcc.Text = "가속도 : " + aAcc.ToString().Remove(7);
            }
            else if (aAcc < 0)
            {
                lblAcc.Text = "가속도 : " + aAcc.ToString().Remove(8);
            }

            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            g = e.Graphics;
            g.DrawLine(Pens.White, this.Width / 2, 0, (int)x + 25, (int)y + 25);
            g.DrawEllipse(Pens.White, new Rectangle((int)x, (int)y, 50, 50));
        }
    }
}
