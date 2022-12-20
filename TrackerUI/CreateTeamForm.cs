using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {
        public CreateTeamForm()
        {
            InitializeComponent();
        }

        private void firstNameValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void createNewMemberButton_Click(object sender, EventArgs e)
        {
            //TODO create function
            if (ValidateForm())
            {
                //const string file = "PersonFIle";
                PersonModel p = new PersonModel();

                p.FirstName = firstNameValue.Text;
                p.LastName = lastNameValue.Text;
                p.EmailAddress = emailValue.Text;
                p.CellphoneNumber = cellphoneValue.Text;

                GlobalConfig.Connection.CreatePerson(p);

                firstNameValue.Text = "";
                lastNameValue.Text = "";
                emailValue.Text = "";
                cellphoneValue.Text = "";
            }
            else
            {
                MessageBox.Show("Invalid data please check your information!");
            }
        }

        private bool ValidateForm()
        {
            if (firstNameValue.Text == "")
            {
                return false;
            }
            if (lastNameValue.Text == "")
            {
                return false;
            }
            if (cellphoneValue.Text == "")
            {
                return false;
            }
            if (emailValue.Text == "")
            {
                return false;
            }
            return true;
        }
    }
}
