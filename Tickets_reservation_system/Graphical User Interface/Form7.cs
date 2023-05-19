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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new Form8();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new Form9();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("FLIGHT REMOVED SUCCESSFUL!");
            Application.Exit();
        }
    }
}
