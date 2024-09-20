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
using Tickets_reservation_system.Models;

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
            Tuple<Company, CompanyUser> combinedTuple = controller.LoginValidation(textBox1.Text, textBox2.Text);

            Models.Company company = combinedTuple.Item1;
            Models.CompanyUser user = combinedTuple.Item2;

            if (company != null)
            {
                Form f = new ManageFlightsView(company, user);
                f.ShowDialog();
            }
            else
                MessageBox.Show("Utilizator/Parola incorecte!");
        }
    }
}
