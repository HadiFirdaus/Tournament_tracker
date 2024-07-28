using System;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;
using System.Collections.Generic;

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {
        private List<PersonModel> availaleTeamMembers = new List<PersonModel>();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();
        public CreateTeamForm()
        {
            InitializeComponent();
            //CreateSampleData();
            WireUpLists();
        }
        private void CreateSampleData()
        {
            availaleTeamMembers.Add(new PersonModel { FirstName = "Tim", LastName = "Corey" });
            availaleTeamMembers.Add(new PersonModel { FirstName = "Sue", LastName = "Storm" });

            selectedTeamMembers.Add(new PersonModel { FirstName = "Jane", LastName = "Smih" });
            selectedTeamMembers.Add(new PersonModel { FirstName = "Koko", LastName = "Crunch" });
        }
        private void WireUpLists()
        {
            selectTeamDropDownLabel.DataSource = availaleTeamMembers;
            selectTeamDropDownLabel.DisplayMember = "FullName";

            teamMemberListBox.DataSource = selectedTeamMembers;
            teamMemberListBox.DisplayMember = "FullName";
        }

        private void teamNameValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void firstNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void createTeamButton_Click(object sender, EventArgs e)
        {

        }
        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel p = new PersonModel();

                p.FirstName = firstNameValue.Text;
                p.LastName = lastNameValue.Text;
                p.EmailAddress = emailValue.Text;
                p.CellPhoneNumber = cellPhoneValue.Text;

                GlobalConfig.Connections.CreatePerson(p);

                firstNameValue.Text = "";
                lastNameValue.Text = "";
                emailValue.Text = "";
                cellPhoneValue.Text = "";
            }
            else
            {
                MessageBox.Show("You need to fill in all the fields");
            }
        }
        private bool ValidateForm()
        {
            //TODO - Add Validation to the form
            if(firstNameValue.Text.Length == 0)
            {
                return false;
            }
            if (lastNameValue.Text.Length == 0)
            {
                return false;
            }
            if (emailValue.Text.Length == 0)
            {
                return false;
            }
            if (cellPhoneValue.Text.Length == 0)
            {
                return false;
            }
            return true;
        }

        private void CreateTeamForm_Load(object sender, EventArgs e)
        {

        }
    }
}
