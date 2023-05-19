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
            MessageBox.Show("BOOKING SUCCESSFUL!" + '\n' + "YOU WILL RECEIVE A RESERVATION E-MAIL WITH ALL THE NECESSARY DATA!" + '\n' + "THANK YOU!");
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
