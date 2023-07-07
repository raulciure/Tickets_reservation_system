using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tickets_reservation_system.Controllers;
using Tickets_reservation_system.Models;

namespace Tickets_reservation_system.Views
{
    public partial class UpdateFlightView : Form
    {
        private readonly ManageFlightsController manageFlightsController;

        private Flight toUpdateFlight;

        internal UpdateFlightView(Flight flight)
        {
            InitializeComponent();
            this.toUpdateFlight = flight;
            dataGridView1.DataSource = this.toUpdateFlight;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(companyNameTextBox.Text, "^[a-zA-Z]*$").Success)
            {
                MessageBox.Show("ADD A VALID COMPANY NAME");
                return;
            }
            if (!Regex.Match(seatsNrTextBox.Text, "^[0-9]*$").Success)
            {
                MessageBox.Show("ADD A VALID SEATS/CLASS NUMBER");
                companyNameTextBox.Focus();
                return;
            }
            if (!Regex.Match(economySeatsNrTextBox.Text, "^[0-9]*$").Success)
            {
                MessageBox.Show("ADD A VALID SEATS/CLASS NUMBER");
                companyNameTextBox.Focus();
                return;
            }
            if (!Regex.Match(bussinessSeatsNrTextBox.Text, "^[0-9]*$").Success)
            {
                MessageBox.Show("ADD A VALID SEATS/CLASS NUMBER");
                companyNameTextBox.Focus();
                return;
            }
            if (!Regex.Match(firstSeatsNrTextBox.Text, "^[0-9]*$").Success)
            {
                MessageBox.Show("ADD A VALID SEATS/CLASS NUMBER");
                companyNameTextBox.Focus();
                return;
            }
            if (!Regex.Match(rangeTextBox.Text, "^[1-9]*$").Success)
            {
                MessageBox.Show("ADD A VALID RANGE");
                companyNameTextBox.Focus();
                return;
            }
            if (!Regex.Match(departureTextBox.Text, "^[a-zA-Z]*$").Success)
            {
                MessageBox.Show("ADD A VALID AIRPORT NAME");
                companyNameTextBox.Focus();
                return;
            }
            if (!Regex.Match(arrivalTextBox.Text, "^[a-zA-Z]*$").Success)
            {
                MessageBox.Show("ADD A VALID AIRPORT NAME");
                companyNameTextBox.Focus();
                return;
            }
            if (!Regex.Match(priceTextBox.Text, "^[1-9]*$").Success)
            {
                MessageBox.Show("ADD A VALID PRICE");
                companyNameTextBox.Focus();
                return;
            }
            if (departureTimeDateTimePicker.Value > arrivalTimeDateTimePicker.Value)
            {
                MessageBox.Show("DATE OF DEPARTURE CAN NOT BE LESS THAN DATE OF RETURN");
                return;
            }
            if ((companyNameTextBox.Text == "") || (planeTailNumber.Text == "") || (seatsNrTextBox.Text == "") || (economySeatsNrTextBox.Text == "") || (bussinessSeatsNrTextBox.Text == "") || (firstSeatsNrTextBox.Text == "") || (rangeTextBox.Text == "") || (flightNumberTextBox.Text == "") || (departureTextBox.Text == "") || (arrivalTextBox.Text == "") || (priceTextBox.Text == ""))
            {
                MessageBox.Show("COMPLETE EMPTY FIELDS");
                return;
            }

            Company newCompany = new Company
            {
                Name = companyNameTextBox.Text,
                CountryOfRegistration = countryOfRegTextBox.Text
            };

            Plane newPlane = new Plane
            {
                CompanyName = newCompany.Name,
                TailNumber = planeTailNumber.Text,
                SeatsNr = Int32.Parse(seatsNrTextBox.Text),
                SeatingConfiguration = new Plane.Seating
                {
                    EconomySeats = Int32.Parse(economySeatsNrTextBox.Text),
                    BussinessSeats = Int32.Parse(bussinessSeatsNrTextBox.Text),
                    FirstSeats = Int32.Parse(firstSeatsNrTextBox.Text)
                },
                Range = Int32.Parse(rangeTextBox.Text)
            };

            Flight newFlight = new Flight
            {
                FlightNumber = flightNumberTextBox.Text,
                DepartureAirport = departureTextBox.Text,
                ArrivalAirport = arrivalTextBox.Text,
                DepartureTime = departureTimeDateTimePicker.Value,
                ArrivalTime = arrivalTimeDateTimePicker.Value,
                FlightTime = manageFlightsController.GetFlightTime(departureTimeDateTimePicker.Value, arrivalTimeDateTimePicker.Value),
                OperatingDays = manageFlightsController.GetOperatingDays(operatingDaysCheckedListBox.SelectedItems),
                Price = Int32.Parse(priceTextBox.Text),
                Company = newCompany,
                Plane = newPlane
            };

            MessageBox.Show("SAVED SUCCESSFUL!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
