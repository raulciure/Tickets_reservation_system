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
using Tickets_reservation_system.Models;

namespace Tickets_reservation_system.Views
{
    public partial class UpdateFlightView : Form
    {
        private Flight flight;

        internal UpdateFlightView(Flight flight)
        {
            InitializeComponent();
            this.flight = flight;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(textBox1.Text, "^[a-zA-Z]*$").Success)
            {
                MessageBox.Show("ADD A VALID COMPANY NAME");
                return;
            }
            if (!Regex.Match(textBox3.Text, "^[0-9]*$").Success)
            {
                MessageBox.Show("ADD A VALID SEATS/CLASS NUMBER");
                textBox1.Focus();
                return;
            }
            if (!Regex.Match(textBox4.Text, "^[0-9]*$").Success)
            {
                MessageBox.Show("ADD A VALID SEATS/CLASS NUMBER");
                textBox1.Focus();
                return;
            }
            if (!Regex.Match(textBox5.Text, "^[0-9]*$").Success)
            {
                MessageBox.Show("ADD A VALID SEATS/CLASS NUMBER");
                textBox1.Focus();
                return;
            }
            if (!Regex.Match(textBox6.Text, "^[0-9]*$").Success)
            {
                MessageBox.Show("ADD A VALID SEATS/CLASS NUMBER");
                textBox1.Focus();
                return;
            }
            if (!Regex.Match(textBox7.Text, "^[1-9]*$").Success)
            {
                MessageBox.Show("ADD A VALID RANGE");
                textBox1.Focus();
                return;
            }
            if (!Regex.Match(textBox9.Text, "^[a-zA-Z]*$").Success)
            {
                MessageBox.Show("ADD A VALID AIRPORT NAME");
                textBox1.Focus();
                return;
            }
            if (!Regex.Match(textBox10.Text, "^[a-zA-Z]*$").Success)
            {
                MessageBox.Show("ADD A VALID AIRPORT NAME");
                textBox1.Focus();
                return;
            }
            if (!Regex.Match(textBox11.Text, "^[1-9]*$").Success)
            {
                MessageBox.Show("ADD A VALID TIME");
                textBox1.Focus();
                return;
            }
            if (!Regex.Match(textBox12.Text, "^[1-9]*$").Success)
            {
                MessageBox.Show("ADD A VALID PRICE");
                textBox1.Focus();
                return;
            }
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("DATE OF DEPARTURE CAN NOT BE LESS THAN DATE OF RETURN");
                return;
            }
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox5.Text == "") || (textBox6.Text == "") || (textBox7.Text == "") || (textBox8.Text == "") || (textBox9.Text == "") || (textBox10.Text == "") || (textBox11.Text == "") || (textBox12.Text == "") || (comboBox1.Text == ""))
            {
                MessageBox.Show("COMPLETE EMPTY FIELDS");
                return;
            }
            else
            {
                MessageBox.Show("SAVED SUCCESSFUL!");

                //Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
