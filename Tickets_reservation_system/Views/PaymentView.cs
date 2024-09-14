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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tickets_reservation_system.Views
{
    public partial class PaymentView : Form
    {
        internal PaymentView()
        {
            InitializeComponent();
            PopulateFields();
        }

        private void PopulateFields()
        {
            comboBox1.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });

            int currentYear = DateTime.Now.Date.Year;
            object[] yearsArray = new object[10];
            for(int i = 0; i < 10; ++i)
                yearsArray[i] = currentYear + i;

            comboBox2.Items.AddRange(yearsArray);
        }

        // Confirm button
        private void button2_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(textBox1.Text, "^[0-9]*$").Success)
            {
                MessageBox.Show("ADD A VALID CARD NUMBER");
                return;
            }
            if (!Regex.Match(textBox2.Text, "^[a-z A-Z]*$").Success)
            {
                MessageBox.Show("ADD A VALID NAME");
                textBox1.Focus();
                return;
            }
            if (!Regex.Match(textBox3.Text, "^[0-9]*$").Success && textBox3.Text.Length != 3)
            {
                MessageBox.Show("ADD A VALID CVV");
                return;
            }
            if ((textBox1.Text == "") || (textBox2.Text == "") || (comboBox1.Text == "") || (comboBox2.Text == "") || (textBox3.Text == ""))
            {
                MessageBox.Show("COMPLETE EMPTY FIELDS");
                return;
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Cancel button
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
