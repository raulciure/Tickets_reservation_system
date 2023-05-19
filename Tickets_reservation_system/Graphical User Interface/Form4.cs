using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tickets_reservation_system.Graphical_User_Interface
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton2.Checked == true)
            {
                Form f = new Form5();
                f.ShowDialog();
            }
            else if(radioButton1.Checked == true)
            {
                MessageBox.Show("BOOKING SUCCESSFUL!" + '\n'+ "YOU WILL RECEIVE A RESERVATION E-MAIL WITH ALL THE NECESSARY DATA!"+'\n'+"THANK YOU!");
                Application.Exit();            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
