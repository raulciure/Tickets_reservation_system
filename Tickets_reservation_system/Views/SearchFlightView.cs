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

namespace Tickets_reservation_system.Views
{
    public partial class SearchFlightView : Form
    {
        public SearchFlightView()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                label5.Visible = true;
                dateTimePicker2.Visible = true;
            }
            else
            {
                label5.Visible = false;
                dateTimePicker2.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(textBox1.Text, "^[A-Z][a-zA-Z]*$").Success)
            {
                MessageBox.Show("ENTER A VALID NAME");
                textBox1.Focus();
                return;
            }
            if ((comboBox1.Text).Equals(""))
            {
                MessageBox.Show("PLEASE SELECT THE ADULTS NUMBER");
                return;
            }
            if ((comboBox2.Text).Equals(""))
            {
                MessageBox.Show("PLEASE SELECT THE KIDS NUMBER");
                return;
            }
            if ((textBox1.Text == "") || (textBox2.Text == ""))
            {
                MessageBox.Show("COMPLETE EMPTY FIELDS");
                return;
            }
            if (dateTimePicker1.Value > dateTimePicker2.Value && checkBox1.Checked == true)
            {
                MessageBox.Show("DATE OF DEPARTURE CAN NOT BE LESS THAN DATE OF RETURN");
                return;
            }
           
            Form f = new SelectFlightView();
            f.ShowDialog();
        }
    }
}
