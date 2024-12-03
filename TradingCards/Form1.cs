using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;

namespace TradingCards
{
    public partial class Form1 : Form
    {
        private List<Player> players;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializePlayerData();
            BindPlayersToListView();
        }

        private void InitializePlayerData()
        {
            players = new List<Player>
            {
                new Player
                {
                    Name = "LeBron James",
                    Team = "Los Angeles Lakers",
                    PhotoUrl = "https://cdn.nba.com/headshots/nba/latest/1040x760/2544.png",
                    Position = "SF",
                    PointsPerGame = 25.4,
                    AssistsPerGame = 6.8,
                    ReboundsPerGame = 8.1,
                    FieldGoalPercentage = 51.1
                },

                new Player
                {
                    Name = "James Harden",
                    Team = "Los Angeles Clippers",
                    PhotoUrl = "https://cdn.nba.com/headshots/nba/latest/1040x760/201935.png",
                    Position = "SG",
                    PointsPerGame = 22.6,
                    AssistsPerGame = 8.9,
                    ReboundsPerGame = 7.2,
                    FieldGoalPercentage = 38.5
                },
                new Player
                {
                    Name = "Stephen Curry",
                    Team = "Golden State Warriors",
                    PhotoUrl = "https://cdn.nba.com/headshots/nba/latest/1040x760/201939.png",
                    Position = "PG",
                    PointsPerGame = 29.2,
                    AssistsPerGame = 6.4,
                    ReboundsPerGame = 6.1,
                    FieldGoalPercentage = 48.3
                },
                new Player
                {
                    Name = "Steven Adams",
                    Team = "Houston Rockets",
                    PhotoUrl = "https://cdn.nba.com/headshots/nba/latest/1040x760/203500.png",
                    Position = "C",
                    PointsPerGame = 2.3,
                    AssistsPerGame = 1.1,
                    ReboundsPerGame = 2.6,
                    FieldGoalPercentage = 53.3
                },
                new Player
                {
                    Name = "LaMelo Ball",
                    Team = "Charlotte Hornets",
                    PhotoUrl = "https://cdn.nba.com/headshots/nba/latest/1040x760/1630163.png",
                    Position = "PG",
                    PointsPerGame = 31.1,
                    AssistsPerGame = 6.9,
                    ReboundsPerGame = 5.4,
                    FieldGoalPercentage = 43.0
                },
                new Player
                {
                    Name = "Anthony Davis",
                    Team = "Los Angeles Lakers",
                    PhotoUrl = "https://cdn.nba.com/headshots/nba/latest/1040x760/203076.png",
                    Position = "FC",
                    PointsPerGame = 28.6,
                    AssistsPerGame = 3.2,
                    ReboundsPerGame = 11.5,
                    FieldGoalPercentage = 55.2
                },
                new Player
                {
                    Name = "Lonzo Ball",
                    Team = "Chicago Bulls",
                    PhotoUrl = "https://cdn.nba.com/headshots/nba/latest/1040x760/1628366.png",
                    Position = "PG",
                    PointsPerGame = 4.4,
                    AssistsPerGame = 3.8,
                    ReboundsPerGame = 2.4,
                    FieldGoalPercentage = 38.1
                },
                new Player
                {
                    Name = "DeAndre Jordan",
                    Team = "Denver Nuggets",
                    PhotoUrl = "https://cdn.nba.com/headshots/nba/latest/1040x760/201599.png",
                    Position = "C",
                    PointsPerGame = 2.6,
                    AssistsPerGame = 0.5,
                    ReboundsPerGame = 3.3,
                    FieldGoalPercentage = 55.6
                },
                new Player
                {
                    Name = "Draymond Green",
                    Team = "Golden State Warriors",
                    PhotoUrl = "https://cdn.nba.com/headshots/nba/latest/1040x760/203110.png",
                    Position = "PG",
                    PointsPerGame = 31.1,
                    AssistsPerGame = 6.9,
                    ReboundsPerGame = 5.4,
                    FieldGoalPercentage = 43.0
                },

                new Player
                {
                    Name = "Kevin Durant",
                    Team = "Phoenix Suns",
                    PhotoUrl = "https://cdn.nba.com/headshots/nba/latest/1040x760/201142.png",
                    Position = "SF",
                    PointsPerGame = 8.8,
                    AssistsPerGame = 5.9,
                    ReboundsPerGame = 6.3,
                    FieldGoalPercentage = 43.3
                }
            }; 
        }

        private void BindPlayersToListView()
        {
            listViewPlayers.Items.Clear();

            foreach (var player in players)
            {
                var item = new ListViewItem(player.Name);
                item.SubItems.Add(player.Team);
                item.Tag = player; // Store the Player object for easy retrieval
                listViewPlayers.Items.Add(item);
            }
        }

        private void listViewPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPlayers.SelectedItems.Count > 0)
            {
                var selectedPlayer = (Player)listViewPlayers.SelectedItems[0].Tag;
                DisplayPlayerCard(selectedPlayer);
            }
        }

        private async void DisplayPlayerCard(Player player)
        {
            // Update labels with player details
            labelName.Text = $"Name: {player.Name}";
            labelTeam.Text = $"Team: {player.Team}";
            labelPosition.Text = $"Position: {player.Position}";
            labelPPG.Text = $"PPG: {player.PointsPerGame:F1}";
            labelAPG.Text = $"APG: {player.AssistsPerGame:F1}";
            labelRPG.Text = $"RPG: {player.ReboundsPerGame:F1}";
            labelFGP.Text = $"FG%: {player.FieldGoalPercentage:F1}";

            // Load image from URL
            if (!string.IsNullOrEmpty(player.PhotoUrl))
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        var imageBytes = await client.GetByteArrayAsync(player.PhotoUrl);
                        using (var ms = new System.IO.MemoryStream(imageBytes))
                        {
                            pictureBoxPlayer.Image = Image.FromStream(ms);
                        }
                    }
                }
                catch
                {
                    pictureBoxPlayer.Image = null;
                }
            }
            else
            {
                pictureBoxPlayer.Image = null;
            }

            // Change the background color of the PictureBox based on the team
            pictureBoxPlayer.BackColor = GetTeamColor(player.Team);

            // Highlight stats dynamically with border color
            HighlightStats(player);
        }

        private Color GetTeamColor(string team)
        {
            switch (team)
            {
                case "Los Angeles Lakers":
                    return Color.Yellow;
                case "Houston Rockets":
                    return Color.Red;
                case "Phoenix Suns":
                    return Color.Purple;
                case "Denver Nuggets":
                    return Color.Cyan;
                case "Charlotte Hornets":
                    return Color.Blue;
                case "Golden State Warriors":
                    return Color.White;
                case "Chicago Bulls":
                    return Color.Black;
                case "Los Angeles Clippers":
                    return Color.Maroon;
                default:
                    return Color.LightGray; // Default color
            }
        }


        private void HighlightStats(Player player)
        {
            // Create a pen for drawing borders
            Pen greenPen = new Pen(Color.Green, 2);
            Pen redPen = new Pen(Color.Red, 2);

            // PPG
            labelPPG.ForeColor = player.PointsPerGame > 20 ? Color.Green : Color.Red;
          
            // APG
            labelAPG.ForeColor = player.AssistsPerGame > 5 ? Color.Green : Color.Red;
      
            // RPG
            labelRPG.ForeColor = player.ReboundsPerGame > 7 ? Color.Green : Color.Red;

            // FG%
            labelFGP.ForeColor = player.FieldGoalPercentage > 50 ? Color.Green : Color.Red;
            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listViewPlayers.SelectedItems.Count > 0)
            {
                // Get the selected ListViewItem
                var selectedItem = listViewPlayers.SelectedItems[0];

                var selectedPlayer = (Player)selectedItem.Tag;

                // Confirm deletion
                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to delete {selectedPlayer.Name}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {            
                    listViewPlayers.Items.Remove(selectedItem);
                    players.Remove(selectedPlayer);
                    ClearPlayerCard();
                }
            }
            else
            {
                MessageBox.Show("Please select a player to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Clear the player card when no player is selected
        private void ClearPlayerCard()
        {
            labelName.Text = "Name:";
            labelTeam.Text = "Team:";
            labelPosition.Text = "Position:";
            labelPPG.Text = "PPG:";
            labelAPG.Text = "APG:";
            labelRPG.Text = "RPG:";
            labelFGP.Text = "FG%:";
            pictureBoxPlayer.Image = null;
            pictureBoxPlayer.BackColor = Color.LightGray;
        }
    }
}