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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tickets_reservation_system.Views
{
    public partial class SearchFlightView : Form
    {
        private readonly SearchFlightController searchFlightController = new SearchFlightController();

        internal SearchFlightView()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            adultsComboBox.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            kidsComboBox.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(returnCheckBox.Checked)
            {
                label5.Visible = true;
                returnDateTimePicker.Visible = true;
            }
            else
            {
                label5.Visible = false;
                returnDateTimePicker.Visible = false;
            }
        }

        // Search button
        private void button1_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(departureTextBox.Text, "^[A-Z][a-zA-Z]*$").Success)
            {
                MessageBox.Show("ENTER A VALID NAME");
                departureTextBox.Focus();
                return;
            }
            if ((adultsComboBox.Text).Equals(""))
            {
                MessageBox.Show("PLEASE SELECT THE ADULTS NUMBER");
                return;
            }
            if ((kidsComboBox.Text).Equals(""))
            {
                MessageBox.Show("PLEASE SELECT THE KIDS NUMBER");
                return;
            }
            if ((departureTextBox.Text == "") || (arrivalTextBox.Text == ""))
            {
                MessageBox.Show("COMPLETE EMPTY FIELDS");
                return;
            }
            if (departureDateTimePicker.Value > returnDateTimePicker.Value && returnCheckBox.Checked == true)
            {
                MessageBox.Show("DATE OF DEPARTURE CAN NOT BE LESS THAN DATE OF RETURN");
                return;
            }

            string departureAirport = departureTextBox.Text;
            string arrivalAirport = arrivalTextBox.Text;
            DateTime departureDate = departureDateTimePicker.Value.Date;
            int seatsNr = Int32.Parse(adultsComboBox.SelectedItem.ToString()) + Int32.Parse(kidsComboBox.SelectedItem.ToString());

            List<Flight> departureResult = searchFlightController.GetFlights(departureAirport, arrivalAirport, departureDate, seatsNr);
            List<Flight> returnResult = null;

            if (returnCheckBox.Checked == true)
            {
                DateTime returnDate = returnDateTimePicker.Value.Date;
                returnResult = searchFlightController.GetFlights(arrivalAirport, departureAirport, returnDate, seatsNr);
            }

            if (departureResult.Count > 0)
            {
                Form f = new SelectFlightView(departureResult, returnResult, returnCheckBox.Checked);
                f.ShowDialog();
            }
            else
                MessageBox.Show("No available flights with the given parameters!", "Search result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
