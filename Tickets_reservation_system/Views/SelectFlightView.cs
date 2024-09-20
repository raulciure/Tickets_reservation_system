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
        private readonly List<Flight> departureFlights;
        private readonly List<Flight> returnFlights;
        private readonly bool returnFlag;
        private readonly int seatsNr;

        internal SelectFlightView(List<Flight> departureResultFlights, List<Flight> returnResultFlights, bool returnFlag, int seatsNr)
        {
            InitializeComponent();

            this.departureFlights = departureResultFlights;
            this.returnFlights = returnResultFlights;
            this.returnFlag = returnFlag;
            this.seatsNr = seatsNr;

            LoadData();
        }

        private void LoadData()
        {
            departureDataGridView.DataSource = departureFlights;
            if (returnFlag == true)
                returnDataGridView.DataSource = returnFlights;
        }

        // Book button
        private void button1_Click(object sender, EventArgs e)
        {
            Flight selectedDepartureFlight = (Flight) departureDataGridView.CurrentRow.DataBoundItem;
            Flight selectedReturnFlight = null;

            if(returnFlag == true)
                selectedReturnFlight = (Flight) returnDataGridView.CurrentRow.DataBoundItem;

            if (selectedDepartureFlight != null)
            {
                for (int index = 1; index <= this.seatsNr; index++)
                {
                    Form f = new ReserveFlightView(selectedDepartureFlight, selectedReturnFlight, this.returnFlag, index);
                    f.ShowDialog();
                }
            }
            else
                MessageBox.Show("No item selected!", "Selection error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Cancel button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
