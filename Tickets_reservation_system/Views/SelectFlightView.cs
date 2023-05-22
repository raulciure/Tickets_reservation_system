using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tickets_reservation_system.Models;

namespace Tickets_reservation_system.Views
{
    public partial class SelectFlightView : Form
    {
        public SelectFlightView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Flight selectedFlight = (Flight) dataGridView1.CurrentRow.DataBoundItem;

            if (selectedFlight != null)
            {
                Form f = new ReserveFlightView(selectedFlight);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("No item selected!", "Selection error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
