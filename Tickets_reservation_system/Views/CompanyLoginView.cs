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

namespace Tickets_reservation_system.Views
{
    public partial class CompanyLoginView : Form
    {
        public CompanyLoginView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "user") && (textBox2.Text == "pass"))
            {
                Form f = new ManageFlightView();
                f.ShowDialog();
            }
            else
                MessageBox.Show("Utilizator/Parola incorecte!");

        }
    }
}
