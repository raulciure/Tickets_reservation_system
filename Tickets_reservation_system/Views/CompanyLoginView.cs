using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Tickets_reservation_system.Controllers;

namespace Tickets_reservation_system.Views
{
    public partial class CompanyLoginView : Form
    {
        private readonly CompanyLoginController controller = new CompanyLoginController();

        public CompanyLoginView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Models.Company company;
            if ((company = controller.LoginValidation(textBox1.Text, textBox2.Text)) != null)
            {
                Form f = new ManageFlightsView(company);
                f.ShowDialog();
            }
            else
                MessageBox.Show("Utilizator/Parola incorecte!");
        }
    }
}
