﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tickets_reservation_system.Graphical_User_Interface
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SAVED SUCCESSFUL!");
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
