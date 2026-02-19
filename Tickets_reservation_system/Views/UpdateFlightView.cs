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
        private readonly ManageFlightsController manageFlightsController = new ManageFlightsController();

        private readonly Flight toUpdateFlight;
        private readonly Company logedInCompany;
        private List<Plane> companyFleet;

        internal UpdateFlightView(Flight flight, Company company)
        {
            logedInCompany = company;
            LoadCompanyFleet();

            InitializeComponent();

            this.toUpdateFlight = flight;
            
            LoadData();
        }

        private void ShowToUpdateFlightData()
        {
            richTextBox1.AppendText("Departure aiport: " + toUpdateFlight.DepartureAirport + "\n\n");
            richTextBox1.AppendText("Arrival aiport: " + toUpdateFlight.ArrivalAirport + "\n\n");
            richTextBox1.AppendText("Departure time: " + toUpdateFlight.DepartureTime + "\n\n");
            richTextBox1.AppendText("Arrival time: " + toUpdateFlight.ArrivalTime + "\n\n");
            richTextBox1.AppendText("Flight time: " + toUpdateFlight.FlightTime + "\n\n");
            richTextBox1.AppendText("Operating days: " + String.Join(",", toUpdateFlight.OperatingDays) + "\n\n");
            richTextBox1.AppendText("Flight number: " + toUpdateFlight.FlightNumber + "\n\n");
            richTextBox1.AppendText("Price: " + toUpdateFlight.Price + "\n\n");
            richTextBox1.AppendText("Plane tail number: " + toUpdateFlight.PlaneTailNumber + "\n\n");
            richTextBox1.AppendText("Company name: " + toUpdateFlight.CompanyName + "\n\n");
        }

        private void LoadData()
        {
            ShowToUpdateFlightData();

            operatingDaysCheckedListBox.DataSource = Enum.GetValues(typeof(Flight.Days));
            
            foreach (int index in toUpdateFlight.OperatingDays.Select(v => (int)v))
            {
                operatingDaysCheckedListBox.SetItemChecked(index, true);
            }

            companyNameTextBox.Text = logedInCompany.Name;
            countryOfRegTextBox.Text = logedInCompany.CountryOfRegistration;

            List<string> tailNumbers = logedInCompany.Fleet;
            
            planeTailNumberComboBox.DataSource = tailNumbers;
        }

        private void LoadCompanyFleet()
        {
            PlaneController planeController = new PlaneController();

            companyFleet = planeController.GetPlanesByCompany(logedInCompany);
        }

        private void planeTailNumberComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Plane selectedPlane = companyFleet.Find(x => x.TailNumber.Equals(planeTailNumberComboBox.SelectedItem));

            planeNameTextBox.Text = selectedPlane.Name;
            seatsNrTextBox.Text = selectedPlane.SeatsNr.ToString();
            economySeatsNrTextBox.Text = selectedPlane.SeatingConfiguration.EconomySeats.ToString();
            bussinessSeatsNrTextBox.Text = selectedPlane.SeatingConfiguration.BussinessSeats.ToString();
            firstSeatsNrTextBox.Text = selectedPlane.SeatingConfiguration.FirstSeats.ToString();
            rangeTextBox.Text = selectedPlane.Range.ToString();
        }

        // Save button
        private void button1_Click(object sender, EventArgs e)
        {
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
            if (!Regex.Match(priceTextBox.Text, "^[1-9]([0-9]*)$").Success)
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
            if ((flightNumberTextBox.Text == "") || (departureTextBox.Text == "") || (arrivalTextBox.Text == "") || (priceTextBox.Text == ""))
            {
                MessageBox.Show("COMPLETE EMPTY FIELDS");
                return;
            }

            Company newCompany = logedInCompany;
            Plane newPlane = companyFleet.Find(x => x.TailNumber.Equals(planeTailNumberComboBox.SelectedItem));

            Flight newFlight = new Flight
            {
                FlightNumber = flightNumberTextBox.Text,
                DepartureAirport = departureTextBox.Text,
                ArrivalAirport = arrivalTextBox.Text,
                DepartureTime = departureTimeDateTimePicker.Value,
                ArrivalTime = arrivalTimeDateTimePicker.Value,
                FlightTime = manageFlightsController.GetFlightTime(departureTimeDateTimePicker.Value, arrivalTimeDateTimePicker.Value),
                OperatingDays = manageFlightsController.GetOperatingDays(operatingDaysCheckedListBox.CheckedItems),
                Price = Int32.Parse(priceTextBox.Text),
                CompanyName = newCompany.Name,
                PlaneTailNumber = newPlane.TailNumber
            };

            bool status = manageFlightsController.Update(toUpdateFlight, newFlight);

            if (status)
                MessageBox.Show("SAVED SUCCESSFUL!");
            else
                MessageBox.Show("Error while saving!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
