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

        // Booking
        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new SearchFlightView();
            f.ShowDialog();
        }

        // Company portal
        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new CompanyLoginView();
            f.ShowDialog();
        }
	}
}
