﻿using System;
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

        internal AddFlightView(Company company)
        {
            InitializeComponent();
            operatingDaysCheckedListBox.DataSource = Enum.GetValues(typeof(Flight.Days));

            logedInCompany = company;
            LoadData();
        }

        private void LoadData()
        {
            companyNameTextBox.Text = logedInCompany.Name;
            countryOfRegTextBox.Text = logedInCompany.CountryOfRegistration;

            List<string> tailNumbers = logedInCompany.Fleet.Select(x => x.TailNumber).ToList();

            planeTailNumberComboBox.DataSource = tailNumbers;
        }

        private void planeTailNumberComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Plane selectedPlane = logedInCompany.Fleet.Find(x => x.TailNumber.Equals(planeTailNumberComboBox.SelectedItem));

            seatsNrTextBox.Text = selectedPlane.SeatsNr.ToString();
            economySeatsNr.Text = selectedPlane.SeatingConfiguration.EconomySeats.ToString();
            bussinessSeatsNr.Text = selectedPlane.SeatingConfiguration.BussinessSeats.ToString();
            firstSeatsNr.Text = selectedPlane.SeatingConfiguration.FirstSeats.ToString();
            rangeTextBox.Text = selectedPlane.Range.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(seatsNrTextBox.Text, "^[0-9]*$").Success)
            {
                MessageBox.Show("ADD A VALID SEATS/CLASS NUMBER");
                companyNameTextBox.Focus();
                return;
            }
            if (!Regex.Match(economySeatsNr.Text, "^[0-9]*$").Success)
            {
                MessageBox.Show("ADD A VALID SEATS/CLASS NUMBER");
                companyNameTextBox.Focus();
                return;
            }
            if (!Regex.Match(bussinessSeatsNr.Text, "^[0-9]*$").Success)
            {
                MessageBox.Show("ADD A VALID SEATS/CLASS NUMBER");
                companyNameTextBox.Focus();
                return;
            }
            if (!Regex.Match(firstSeatsNr.Text, "^[0-9]*$").Success)
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
            if (!Regex.Match(departureAirportTextBox.Text, "^[a-zA-Z]*$").Success)
            {
                MessageBox.Show("ADD A VALID AIRPORT NAME");
                companyNameTextBox.Focus();
                return;
            }
            if (!Regex.Match(arrivalAirportTextBox.Text, "^[a-zA-Z]*$").Success)
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
            if(departureTimeDateTimePicker.Value > arrivalTimeDateTimePicker.Value)
            {
                MessageBox.Show("DATE OF DEPARTURE CAN NOT BE LESS THAN DATE OF RETURN");
                return;
            }
            if ((flightNumberTextBox.Text == "") || (departureAirportTextBox.Text == "") || (arrivalAirportTextBox.Text == "") || (priceTextBox.Text == ""))
            {
                MessageBox.Show("COMPLETE EMPTY FIELDS");
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
            Plane plane = logedInCompany.Fleet.Find(x => x.TailNumber.Equals(planeTailNumberComboBox.SelectedItem));

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
                Company = company,
                Plane = plane
            };

            manageFlightController.Add(newFlight);
            
            MessageBox.Show("SAVED SUCCESSFUL!");
        }
    }
}
