﻿using System;
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
    public partial class ManageFlightView : Form
    {
        public ManageFlightView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new AddFlightView();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Flight selectedFlight = (Flight) dataGridView1.CurrentRow.DataBoundItem;

            if (selectedFlight != null)
            {
                Form f = new UpdateFlightView(selectedFlight);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("No item selected!", "Selection error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("FLIGHT REMOVED SUCCESSFUL!");
            Application.Exit();
        }
    }
}
