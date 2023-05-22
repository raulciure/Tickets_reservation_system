using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tickets_reservation_system.Views
{
    public partial class WelcomePageView : Form
    {
        public WelcomePageView()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new SearchFlightView();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new CompanyLoginView();
            f.ShowDialog();
        }

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}
	}
}
