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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Tickets_reservation_system.Views
{
    public partial class AddFlightView : Form
    {
        private readonly ManageFlightsController manageFlightController = new ManageFlightsController();
        private readonly Company logedInCompany;
        private List<Plane> companyFleet;

        internal AddFlightView(Company company)
        {
            logedInCompany = company;
            LoadCompanyFleet();

            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            operatingDaysCheckedListBox.DataSource = Enum.GetValues(typeof(Days));
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
            //string selectedPlaneTailNumber = planeTailNumberComboBox.SelectedItem.ToString();
            Plane selectedPlane = companyFleet.Find(x => x.TailNumber.Equals(planeTailNumberComboBox.SelectedItem));

            planeNameTextBox.Text = selectedPlane.Name;
            seatsNrTextBox.Text = selectedPlane.SeatsNr.ToString();
            economySeatsNr.Text = selectedPlane.SeatingConfiguration.EconomySeats.ToString();
            bussinessSeatsNr.Text = selectedPlane.SeatingConfiguration.BussinessSeats.ToString();
            firstSeatsNr.Text = selectedPlane.SeatingConfiguration.FirstSeats.ToString();
            rangeTextBox.Text = selectedPlane.Range.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (departureAirportTextBox.Text == "")
            {
                MessageBox.Show("ADD A VALID AIRPORT NAME", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                companyNameTextBox.Focus();
                return;
            }
            if (arrivalAirportTextBox.Text == "")
            {
                MessageBox.Show("ADD A VALID AIRPORT NAME", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                companyNameTextBox.Focus();
                return;
            }
            if (!Regex.Match(priceTextBox.Text, "^[1-9]([0-9]*)$").Success)
            {
                MessageBox.Show("ADD A VALID PRICE", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                companyNameTextBox.Focus();
                return;
            }
            if(DateTime.Compare(departureTimeDateTimePicker.Value, arrivalTimeDateTimePicker.Value) >= 0)
            {
                MessageBox.Show("DATE/TIME OF DEPARTURE CAN NOT BE LESS/EQUAL THAN DATE OF ARRIVAL", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((flightNumberTextBox.Text == "") || (departureAirportTextBox.Text == "") || (arrivalAirportTextBox.Text == "") || (priceTextBox.Text == ""))
            {
                MessageBox.Show("COMPLETE EMPTY FIELDS", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(operatingDaysCheckedListBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("SELECT OPERATING DAYS", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Company company = new Company
            //{
            //    Name = companyNameTextBox.Text,
            //    CountryOfRegistration = countryOfRegTextBox.Text
            //};

            //Plane plane = new Plane
            //{
            //    CompanyName = company.Name,
            //    TailNumber = planeTailNumberTextBox.Text,
            //    SeatsNr = Int32.Parse(seatsNrTextBox.Text),
            //    SeatingConfiguration = new Plane.Seating
            //    {
            //        EconomySeats = Int32.Parse(economySeatsNr.Text),
            //        BussinessSeats = Int32.Parse (bussinessSeatsNr.Text),
            //        FirstSeats = Int32.Parse(firstSeatsNr.Text),
            //    },
            //    Range = Int32.Parse(rangeTextBox.Text)
            //};

            Company company = logedInCompany;
            Plane plane = companyFleet.Find(x => x.TailNumber.Equals(planeTailNumberComboBox.SelectedItem));

            Flight newFlight = new Flight
            {
                FlightNumber = flightNumberTextBox.Text,
                DepartureAirport = departureAirportTextBox.Text,
                ArrivalAirport = arrivalAirportTextBox.Text,
                DepartureTime = departureTimeDateTimePicker.Value,
                ArrivalTime = arrivalTimeDateTimePicker.Value,
                FlightTime = manageFlightController.GetFlightTime(departureTimeDateTimePicker.Value, arrivalTimeDateTimePicker.Value),
                OperatingDays = manageFlightController.GetOperatingDays(operatingDaysCheckedListBox.SelectedItems),
                Price = Int32.Parse(priceTextBox.Text),
                CompanyName = company.Name,
                PlaneTailNumber = plane.TailNumber
            };

            manageFlightController.Add(newFlight);
            
            MessageBox.Show("SAVED SUCCESSFUL!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
