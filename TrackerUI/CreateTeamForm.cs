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
        private List<PersonModel> availableTeamMembers = new List<PersonModel>();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();

        public CreateTeamForm()
        {
            InitializeComponent();

            LoadListData();

            //CreateSamples();

            WireUpLists();
        }

        private void LoadListData()
        {
            availableTeamMembers = GlobalConfig.Connection.GetPerson_All();
        }

        private void CreateSamples()
        {
            availableTeamMembers.Add(new PersonModel { FirstName = "Tim", LastName = "Correy" });
            availableTeamMembers.Add(new PersonModel { FirstName = "Suzie", LastName = "Nowak" });

            selectedTeamMembers.Add(new PersonModel { FirstName = "Kasia", LastName = "Kowalska" });
            selectedTeamMembers.Add(new PersonModel { FirstName = "Jan", LastName = "Rapowanie" });
        }

        private void WireUpLists()
        {
            selectTeamMemberDropDown.DataSource = null;

            selectTeamMemberDropDown.DataSource = availableTeamMembers;
            selectTeamMemberDropDown.DisplayMember = "FullName";

            teamMembersListBox.DataSource = null;

            teamMembersListBox.DataSource = selectedTeamMembers;
            teamMembersListBox.DisplayMember = "FullName";
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

                p = GlobalConfig.Connection.CreatePerson(p);

                selectedTeamMembers.Add(p);

                WireUpLists();

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

        private void addMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)selectTeamMemberDropDown.SelectedItem;

            if (p != null)
            {
                availableTeamMembers.Remove(p);
                selectedTeamMembers.Add(p);

                WireUpLists(); 
            }
            //selectTeamMemberDropDown.Refresh();
            //teamMembersListBox.Refresh();
        }

        private void removeSelectedMember_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)teamMembersListBox.SelectedItem;

            if (p != null)
            {
                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);

                WireUpLists(); 
            }
        }

        private void createTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel t = new TeamModel();

            t.TeamName = teamNameValue.Text;
            t.TeamMembers = selectedTeamMembers;

            GlobalConfig.Connection.CreateTeam(t);

            // TODO - czyszczenie danych w tej formie 
        }
    }
}
