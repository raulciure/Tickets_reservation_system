using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tickets_reservation_system.Graphical_User_Interface
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "user") && (textBox2.Text == "pass"))
            {
                Form f = new Form7();
                f.ShowDialog();
            }
            else
                MessageBox.Show("Utilizator/Parola incorecte!");

        }
    }
}
