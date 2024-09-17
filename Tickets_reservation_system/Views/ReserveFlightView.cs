using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Tickets_reservation_system.Controllers;
using Tickets_reservation_system.Models;

namespace Tickets_reservation_system.Views
{
    public partial class ReserveFlightView : Form
    {
        private readonly Flight departureFlight;
        private readonly Flight returnFlight;
        private readonly bool returnFlag;
        private readonly int passengerNr;

        private bool cardPayment;


        internal ReserveFlightView(Flight departureFlight, Flight returnFlight, bool returnFlag, int passengerNr)
        {
            InitializeComponent();

            this.departureFlight = departureFlight;
            this.returnFlight = returnFlight;
            this.returnFlag = returnFlag;
            this.passengerNr = passengerNr;

            LoadData();
        }

        private void LoadData()
        {
            List<Flight> flights = new List<Flight>();
            flights.Add(departureFlight);
            if(returnFlag == true)
                flights.Add(returnFlight);

            dataGridView1.DataSource = flights;

            label12.Text = passengerNr.ToString();
        }

        private void BookFlight(Passanger passenger)
        {
            TicketController ticketController = new TicketController();

            Ticket newDepartureTicket = new Ticket()
            {
                FlightNumber = departureFlight.FlightNumber,
                Passenger = passenger,
                TicketId = Guid.NewGuid().ToString("N"),
                SeatNr = null // TEMPORARY, requires implementation of seat allocation function
            };
            ticketController.Add(newDepartureTicket);

            if(returnFlag == true)
            {
                Ticket newReturnTicket = new Ticket()
                {
                    FlightNumber = returnFlight.FlightNumber,
                    Passenger = passenger,
                    TicketId = Guid.NewGuid().ToString("N"),
                    SeatNr = null // TEMPORARY, requires implementation of seat allocation function
                };
                ticketController.Add(newReturnTicket);
            }

            // TODO: Send email here

            MessageBox.Show("BOOKING SUCCESSFUL!" + '\n' + "YOU WILL RECEIVE A RESERVATION E-MAIL WITH ALL THE NECESSARY DATA!" + '\n' + "THANK YOU!",
                            "Booking successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.cardPayment = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.cardPayment = true;
        }

        // Book button
        private void button1_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(textBox1.Text, "^[A-Z][a-zA-Z]*$").Success)
            {
                MessageBox.Show("ADD A VALID NAME");
                textBox1.Focus();
                return;
            }
            if (!Regex.Match(textBox2.Text, "^[A-Z][a-zA-Z]*$").Success)
            {
                MessageBox.Show("ADD A VALID NAME");
                textBox2.Focus();
                return;
            }
            if (!Regex.Match(textBox4.Text, "^[0-9]*$").Success)
            {
                MessageBox.Show("ADD A VALID NUMBER");
                return;
            }
            if (!Regex.Match(textBox5.Text, "^[1-9]*$").Success)
            {
                MessageBox.Show("ADD A VALID AGE");
                return;
            }
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox5.Text == "") || (textBox6.Text == ""))
            {
                MessageBox.Show("COMPLETE EMPTY FIELDS");
                return;
            }
            else if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("SELECT PAYMENT OPTION");
                return;
            }

            Passanger passenger = new Passanger()
            {
                FirstName = textBox1.Text,
                LastName = textBox2.Text,
                Email = textBox3.Text,
                PhoneNumber = textBox4.Text,
                Age = Int32.Parse(textBox5.Text),
                Id = textBox6.Text
            };

            if (cardPayment == true)
            {
                Form f = new PaymentView();
                var status = f.ShowDialog();
                if (status == DialogResult.OK)
                    BookFlight(passenger);
            }
            else
                BookFlight(passenger);

            this.Close();
        }

        // Cancel button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
