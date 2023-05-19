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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(textBox1.Text, "^[0-9]*$").Success)
            {
                MessageBox.Show("ADD A VALID CARD NUMBER");
                return;
            }
            if (!Regex.Match(textBox2.Text, "^[a-zA-Z]*$").Success)
            {
                MessageBox.Show("ADD A VALID NAME");
                textBox1.Focus();
                return;
            }
            if (!Regex.Match(textBox3.Text, "^[0-9]*$").Success)
            {
                MessageBox.Show("ADD A VALID CVV");
                return;
            }
            if ((textBox1.Text == "") || (textBox2.Text == "") || (comboBox1.Text == "") || (comboBox2.Text == "") || (textBox3.Text == ""))
                MessageBox.Show("COMPLETE EMPTY FIELDS");
            else
            {
                MessageBox.Show("BOOKING SUCCESSFUL!" + '\n' + "YOU WILL RECEIVE A RESERVATION E-MAIL WITH ALL THE NECESSARY DATA!" + '\n' + "THANK YOU!");
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
