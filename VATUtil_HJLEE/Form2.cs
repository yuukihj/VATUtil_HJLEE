using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VATUtil_HJLEE
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Text = "TOD CALCULATOR";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            decimal val1 = numericUpDown1.Value;
            decimal val2 = numericUpDown2.Value;
            decimal val3 = numericUpDown3.Value;
            decimal calc1 = (val1 - val2) * 3 / 10;
            decimal calc2 = val3 * 5;

            textBox4.Text = calc1.ToString() + "NM to descent";
            if (calc1 < 0)
            {
                MessageBox.Show("TOD can not be lower than 0");
                textBox5.Text = calc2.ToString() + "fpm required";
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            decimal val1 = numericUpDown1.Value;
            decimal val2 = numericUpDown2.Value;
            decimal val3 = numericUpDown3.Value;
            decimal calc1 = (val1 - val2) * 3/10;
            decimal calc2 = val3 * 5;

            textBox4.Text = calc1.ToString()+"NM to descent";
            textBox5.Text = calc2.ToString() + "fpm required";
            if (calc1 < 0)
            {
                MessageBox.Show("TOD can not be lower than 0");
            }

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            decimal val1 = numericUpDown1.Value;
            decimal val2 = numericUpDown2.Value;
            decimal val3 = numericUpDown3.Value;
            decimal calc1 = (val1 - val2) * 3 / 10;
            decimal calc2 = val3 * 5;

            textBox4.Text = calc1.ToString() + "NM to descent";
            textBox5.Text = calc2.ToString() + "fpm required";
            if (calc1 < 0)
            {
                MessageBox.Show("TOD can not be lower than 0");
            }

        }
    }

    
    }
