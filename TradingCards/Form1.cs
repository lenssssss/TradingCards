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
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to load image: {ex.Message}");
                    pictureBoxPlayer.Image = null;
                }
            }
            else
            {
                pictureBoxPlayer.Image = null;
            }
        }
    }
}
