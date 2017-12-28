using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cmd____
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        int x, y;

        Point newpoint = new Point();
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            x = Control.MousePosition.X - this.Location.X;
            y = Control.MousePosition.Y - this.Location.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                newpoint = Control.MousePosition;
                newpoint.X -= (x);

                newpoint.Y -= (y);
                this.Location = newpoint;
            }


        }

        private void Button2_MouseHover(object sender, EventArgs e)
        {
            Panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(60)))));
        }

        private void Button2_MouseLeave(object sender, EventArgs e)
        {
          Panel7.BackColor = Color.Transparent;
        }

        private void Button4_MouseHover(object sender, EventArgs e)
        {
            Panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        }

        private void Button4_MouseLeave(object sender, EventArgs e)
        {
            Panel8.BackColor = Color.Transparent;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Button1.Text == "↑")
            {
                if (Panel5.Size.Height == 50)
                {
                    timer1.Stop();
                    Button1.Text = "Existing Command";
                    Form2 a = new Form2();
                    
                }
                else
                {
                    
                    int a = Panel5.Size.Height - 10;
                    int b = Panel6.Size.Height + 10;
                    Panel5.Size = new System.Drawing.Size(Panel5.Size.Width, a);
                    Panel6.Size = new System.Drawing.Size(Panel6.Size.Width, b);

                    
                }
            }
            else
            {
                if (Panel5.Size.Height == 450)
                {
                    timer1.Stop();
                    Button1.Text = "↑";
                }
                else
                {

                    int a = Panel5.Size.Height + 10;
                    int b = Panel6.Size.Height - 10;
                    Panel5.Size = new System.Drawing.Size(Panel5.Size.Width, a);
                    Panel6.Size = new System.Drawing.Size(Panel6.Size.Width, b);
                }
            }
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Form2 a = new Form2();
            Panel formPAnel = a.panel1;
            timer1.Start();
            Panel6.Controls.Add(formPAnel);
        }
        
    }
}
