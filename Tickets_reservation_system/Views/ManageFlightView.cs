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
using Tickets_reservation_system.Controllers;


namespace Tickets_reservation_system.Views
{
    public partial class ManageFlightsView : Form
    {
        private readonly ManageFlightsController controller = new ManageFlightsController();
        private readonly Company logedInCompany;
        private readonly CompanyUser loggedInUser;

        internal ManageFlightsView(Company company, CompanyUser user)
        {
            InitializeComponent();
            LoadData();

            logedInCompany = company;
            loggedInUser = user;
            companyNameLabel.Text = logedInCompany.Name;
            userNameLabel.Text = "User: " + loggedInUser.Username;
        }

        private void LoadData()
        {
            BindingSource bindingSource = new BindingSource();

            var flightsList = controller.GetFlights();

            var flightsDataSource = flightsList.Select(x => new
            {
                x.DepartureAirport,
                x.ArrivalAirport,
                x.DepartureTime,
                x.ArrivalTime,
                x.FlightTime,
                OperatingDays = String.Join(",", x.OperatingDays),  // Convert operating days into comma separated string
                x.FlightNumber,
                x.Price,
                x.PlaneTailNumber,
                x.CompanyName

            }).ToList();

            dataGridView1.DataSource = flightsDataSource;
        }

        // Add button
        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new AddFlightView(logedInCompany);
            
            var status = f.ShowDialog();
            if(status == DialogResult.OK) LoadData();
        }

        // Update button
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null) // if a row is selected
            {
                Flight selectedFlight = (Flight)dataGridView1.CurrentRow.DataBoundItem;

                if (selectedFlight != null)
                {
                    Form f = new UpdateFlightView(selectedFlight, logedInCompany);

                    var status = f.ShowDialog();
                    if (status == DialogResult.OK) LoadData();
                }
                else
                {
                    MessageBox.Show("No item selected!", "Selection error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Delete button
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null) // if a row is selected
            {
                Flight removeFlight = (Flight)dataGridView1.CurrentRow.DataBoundItem;

                controller.Remove(removeFlight);

                MessageBox.Show("FLIGHT REMOVED SUCCESSFUL!");
                
                LoadData();
            }
        }
    }
}
