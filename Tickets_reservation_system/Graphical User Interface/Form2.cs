using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tickets_reservation_system.Graphical_User_Interface
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(textBox1.Text, "^[A-Z][a-zA-Z]*$").Success)
            {
                MessageBox.Show("ENTER A VALID NAME");
                textBox1.Focus();
                return;
            }
            else if((comboBox1.Text).Equals(""))
            {
                MessageBox.Show("PLEASE SELECT THE ADULTS NUMBER");
            }
            else if ((comboBox2.Text).Equals(""))
            {
                MessageBox.Show("PLEASE SELECT THE KIDS NUMBER");
            }
            else if ((textBox1.Text == "") || (textBox2.Text == ""))
                MessageBox.Show("COMPLETE EMPTY FIELDS");
            else if(dateTimePicker1.Value>dateTimePicker2.Value && checkBox1.Checked==true)
            {
                MessageBox.Show("DATE OF DEPARTURE CAN NOT BE LESS THAN DATE OF RETURN");
            }
            else
            {
                Form f = new Form3();
                f.ShowDialog();
            }
        }
    }
}
