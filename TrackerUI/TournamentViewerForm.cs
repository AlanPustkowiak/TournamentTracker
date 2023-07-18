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
    public partial class TournamentViewerForm : Form
    {
        private TournamentModel tournament;
        BindingList<int> rounds = new BindingList<int>();
        BindingList<MatchupModel> selectedMatchups = new BindingList<MatchupModel>();
        public TournamentViewerForm(TournamentModel tournamentModel)
        {
            InitializeComponent();

            tournament = tournamentModel;

            WireUpLists();

            LoadFormData();

            LoadRounds();
        }

        private void LoadFormData()
        {
            tournamentName.Text = tournament.TournamentName;
        }

        private void WireUpLists()
        {
            roundDropDow.DataSource = rounds;
            matchupListBox.DataSource = selectedMatchups;
            matchupListBox.DisplayMember = "DisplayName";
        }
        private void LoadRounds()
        {
            rounds.Clear();

            rounds.Add(1);
            int currRound = 1;

            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound > currRound)
                {
                    currRound = matchups.First().MatchupRound;
                    rounds.Add(currRound);
                }
            }

            LoadMatchups(1);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void roundDropDow_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)roundDropDow.SelectedItem);
        }

        private void LoadMatchups(int round)
        {
            foreach (List<MatchupModel> matchups in tournament.Rounds) // TODO zająć się round bo nie wykrywa ich tak jak powinno, nie dodaje dwóch teamów do rywalizacji tylko bierze pierwszy z brzegu
            {
                if (matchups.First().MatchupRound == round) //raczej probelm z fuknkcją wyżej odnośnie tworzenia tournamentu.rounds
                {
                    selectedMatchups.Clear();
                    foreach (MatchupModel m in matchups)
                    {
                        if (m.Winner == null || !unplayedOnlyChechbox.Checked)
                        {
                            selectedMatchups.Add(m); 
                        }
                    }
                    //selectedMatchups = new BindingList<MatchupModel>(matchups);
                }
            }
            //matchupsBinding.ResetBindings(false);
            //WireMatchupsLists();

            if (selectedMatchups.Count > 0)
            {
                LoadMatchup(selectedMatchups.First()); 
            }

            DisplayMatchupInfo();
        }

        private void DisplayMatchupInfo()
        {
            bool isVisible = (selectedMatchups.Count > 0);

            teamOneName.Visible = isVisible;
            teamOneScoreLabel.Visible = isVisible;
            teamOneScoreValue.Visible = isVisible;

            teamTwoName.Visible = isVisible;
            teamTwoScoreLabel.Visible = isVisible;
            teamTwoScoreValue.Visible = isVisible;

            versusLabel.Visible = isVisible;
            scoreButton.Visible = isVisible;
        }

        private void matchupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchup((MatchupModel)matchupListBox.SelectedItem);
        }

        private void LoadMatchup(MatchupModel m)
        {
            for (int i = 0; i < m.Entries.Count; i++) //TODO
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        teamOneName.Text = m.Entries[0].TeamCompeting.TeamName;
                        teamOneScoreValue.Text = m.Entries[0].Score.ToString();

                        teamTwoName.Text = "<bye>";
                        teamTwoScoreValue.Text = "0";
                    }
                    else
                    {
                        teamOneName.Text = "Not Yet Set";
                        teamOneScoreValue.Text = "";
                    }
                }
                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        teamTwoName.Text = m.Entries[1].TeamCompeting.TeamName;
                        teamTwoScoreValue.Text = m.Entries[1].Score.ToString();
                    }
                    else
                    {
                        teamTwoName.Text = "Not Yet Set";
                        teamTwoScoreValue.Text = "";
                    }
                }
            }
        }

        private void unplayedOnlyChechbox_CheckedChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)roundDropDow.SelectedItem);
        }

        private string IsValidData()
        {
            string output = "";
            double teamOneScore = 0, teamTwoScore = 0;

            bool scoreValid1 = double.TryParse(teamOneScoreValue.Text, out teamOneScore);
            bool scoreValid2 = double.TryParse(teamTwoScoreValue.Text, out teamTwoScore);

            if (!scoreValid1)
            {
                output = "The score one is not a valid number.";
            }
            else if (!scoreValid2)
            {
                output = "The score one is not a valid number.";
            }
            else if (teamOneScore == 0 && teamTwoScore == 0)
            {
                output = "You did not enter a score for either team.";
            }
            else if (teamOneScore == teamTwoScore)
            {
                output = "We do not allow ties in this app.";
            }

            return output;
        }

        private void scoreButton_Click(object sender, EventArgs e)
        {
            string errMess = IsValidData();
            if (errMess.Length > 0)
            {
                MessageBox.Show($"Input error:{ errMess }");
            }

            MatchupModel m = (MatchupModel)matchupListBox.SelectedItem;
            double teamOneScore = 0, teamTwoScore = 0;


            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        bool scoreValid = double.TryParse(teamOneScoreValue.Text, out teamOneScore);
                        if (scoreValid)
                        {
                            m.Entries[0].Score = teamOneScore; 
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for team 1");
                        }
                    }
                }
                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        bool scoreValid = double.TryParse(teamTwoScoreValue.Text, out teamTwoScore);
                        if (scoreValid)
                        {
                            m.Entries[1].Score = teamTwoScore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for team 2");
                            return;
                        }
                    }
                }
            }
            try
            {
                TournamentLogic.UpdateTournamentResult(tournament);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The app had the following error: { ex.Message }");
                return;
            }


            LoadMatchups((int)roundDropDow.SelectedItem);

        }
    }
}
