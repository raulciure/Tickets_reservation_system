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
using Tickets_reservation_system.Models;

namespace Tickets_reservation_system.Views
{
    public partial class ReserveFlightView : Form
    {
        private readonly Flight departureFlight;
        private readonly Flight returnFlight;
        private readonly bool returnFlag;


        internal ReserveFlightView(Flight departureFlight, Flight returnFlight, bool returnFlag)
        {
            InitializeComponent();

            this.departureFlight = departureFlight;
            this.returnFlight = returnFlight;
            this.returnFlag = returnFlag;

            LoadData();
        }

        private void LoadData()
        {
            List<Flight> flights = new List<Flight>();
            flights.Add(departureFlight);
            if(returnFlag == true)
                flights.Add(returnFlight);

            dataGridView1.DataSource = flights;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        // Book button
        private void button1_Click(object sender, EventArgs e)
        {
            if(!Regex.Match(textBox1.Text, "^[A-Z][a-zA-Z]*$").Success)
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
                MessageBox.Show("COMPLETE EMPTY FIELDS");
            else if(radioButton1.Checked == false && radioButton2.Checked == false)
                MessageBox.Show("SELECT PAYMENT OPTION");
            else if (radioButton2.Checked == true)
            {
                Form f = new PaymentView();
                f.ShowDialog();
            }
            else if(radioButton1.Checked == true)
            {
                MessageBox.Show("BOOKING SUCCESSFUL!" + '\n'+ "YOU WILL RECEIVE A RESERVATION E-MAIL WITH ALL THE NECESSARY DATA!"+'\n'+"THANK YOU!");
                //Application.Exit();
            }
        }

        // Cancel button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
