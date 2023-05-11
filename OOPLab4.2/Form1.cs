using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OOPLab4._2
{
    public partial class Form1 : Form
    {
        Model model;
        public Form1()
        {
            InitializeComponent();
            model = new Model();
            model.observers += new EventHandler(this.UpdateFromModel);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            model.setValA((int)numericUpDown1.Value);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            model.setValA(((int)trackBar1.Value));
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            model.setValB((int)numericUpDown2.Value);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            model.setValB(((int)trackBar2.Value));
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            model.setValC((int)numericUpDown3.Value);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            model.setValC(((int)trackBar3.Value));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText("SaveA.txt", model.A.ToString());
            File.WriteAllText("SaveC.txt", model.C.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string str;
            str = File.ReadAllText("SaveA.txt", Encoding.Default);
            model.A = int.Parse(str);
            str = File.ReadAllText("SaveC.txt", Encoding.Default);
            model.C = int.Parse(str);
            UpdateFromModel(sender, e);
        }

        private void UpdateFromModel(object sender, EventArgs e)
        {
            textBox1.Text = model.getValA().ToString();
            textBox2.Text = model.getValB().ToString();
            textBox3.Text = model.getValC().ToString();
            numericUpDown1.Value = model.getValA();
            numericUpDown2.Value = model.getValB();
            numericUpDown3.Value = model.getValC();
            trackBar1.Value = model.getValA();
            trackBar2.Value = model.getValB();
            trackBar3.Value = model.getValC();
        }

        private class Model
        {
            public int A, B, C;
            public System.EventHandler observers;
            public Model() { A = 0; B = 0; C = 0; }
            public void setValA(int a)
            {
                if (a < 101)
                {
                    this.A = a;
                    if (A >= C)
                    {
                        B = C;
                        A = C;
                    }
                    if (a > B)
                        B = A;
                }
                observers.Invoke(this, null);
            }
            public void setValB(int b)
            {
                if (b < 101)
                {
                    this.B = b;
                    if (B < A)
                    {
                        B = A;
                    }
                    if (B > C)
                    {
                        B = C;
                    }
                }
                observers.Invoke(this, null);
            }
            public void setValC(int c)
            {
                if (c < 101)
                {
                    this.C = c;
                    if (C <= A)
                    {
                        C = A;
                        B = A;
                    }
                    if (c < B)
                        B = C;
                }
                observers.Invoke(this, null);

            }

            public int getValA()
            {
                return this.A;
            }
            public int getValB()
            {
                return this.B;
            }
            public int getValC()
            {
                return this.C;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                model.setValB(int.Parse(textBox2.Text));
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                model.setValA(int.Parse(textBox1.Text));
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                model.setValC(int.Parse(textBox3.Text));
            }
        }
    }




}