using Forza4Socket.ClientSide;
using Forza4Socket.ServerSide;
using Forza4Socket.Game;
using Forza4Socket.Network;
using System.Net;
using System.ComponentModel;
using System.Windows.Forms;

namespace Forza4Socket
{
    public partial class Form1 : Form
    {
        Client client;
        Server server;
        bool isGridEnabled = false;

        public Form1()
        {
            client = new Client(new Action<ServerResponse>(UpdateUIWhenReceivingData), new Action<IPAddress>(OnDeviceDiscovered), new Action(onConnectionAccepted), new Action<List<IPAddress>>(OnDiscoveredFinished));
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisablePlayAgain();
        }

        private void clientBtn_Click(object sender, EventArgs e)
        {
            IPAddress ip = (IPAddress?)lstHosts.SelectedItem;
            if (ip != null)
            {
                client.ConnectToServer(ip);
            }
            DisableConnectCommands();
            ShowGrid();
            DisableGridInteraction();
        }

        private void serverBtn_Click(object sender, EventArgs e)
        {
            server = new Server();
            server.Setup();
            client.ConnectToServer(IPAddress.Loopback);
            lblTurnPlayer.Text = "In attesa di un giocatore...";
            DisableConnectCommands();
            ShowGrid();
            DisableGridInteraction();
        }

        private void ShowGrid()
        {
            dtg_Forza4.ColumnCount = 7;
            dtg_Forza4.RowCount = 6;
            dtg_Forza4.ColumnHeadersVisible = false;
            dtg_Forza4.RowHeadersVisible = false;
            dtg_Forza4.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            for (int i = 0; i < 6; i++)
            {
                DataGridViewRow row = dtg_Forza4.Rows[i];
                row.Height = 69;
            }
        }

        private void DisableConnectCommands()
        {
            btn_Server.Enabled = false;
            btn_Connect.Enabled = false;
            btn_Discover.Enabled = false;
        }

        private void UpdateUIWhenReceivingData(ServerResponse data)
        {
            Player? currentPlayer = null;
            if (data.Player != null)
            {
                currentPlayer = data.Player;
                lblUser.Text = $"Il tuo username: {currentPlayer.Username}";
            }

            if (data.WinningPlayerId != null && data.IsGameOver == true)
            {
                if (data.WinningPlayerId == currentPlayer?.Id)
                {
                    lblTurnPlayer.Text = "Hai vinto!!!";
                }
                else
                {
                    Player winningPlayer = data.Players!.Find(p => p.Id == data.WinningPlayerId!)!;
                    lblTurnPlayer.Text = $"Ha vinto {winningPlayer.Username}";
                }

                DisableGridInteraction();
                if (currentPlayer != null && currentPlayer.GameMode != GameMode.Spectator)
                {
                    EnablePlayAgain();
                }
            }
            else if (data.GameStarted == true)
            {
                if (currentPlayer != null && data.TurnPlayerId != null && data.TurnPlayerId != -1)
                {
                    if (data.TurnPlayerId == data.Player!.Id)
                    {
                        lblTurnPlayer.Text = $"è il tuo turno {data.Player.Username}";
                        EnableGridInteraction();

                        if (data.IsCellSelectedInvalid == true)
                        {
                            lblTurnPlayer.Text = $"Mossa non valida {data.Player.Username}";
                        }
                    }
                    else
                    {
                        Player enemyPlayer = data.Players!.Find(p => p.Id == data.TurnPlayerId!)!;
                        lblTurnPlayer.Text = $"In attesa della mossa di {enemyPlayer.Username}";
                        DisableGridInteraction();

                        if (data.IsCellSelectedInvalid == true)
                        {
                            lblTurnPlayer.Text = $"In attesa che {data.Player.Username} faccia una mossa valida";
                        }
                    }
                }
            }
            else
            {
                if (server != null)
                {
                    lblTurnPlayer.Text = "In attesa di un giocatore...";
                }
                else
                {
                    lblTurnPlayer.Text = "In attesa dell'host...";
                }
            }

            if (data.Grid != null && currentPlayer != null && data.Players != null)
            {
                int playerId = currentPlayer.Id;
                if (currentPlayer.GameMode == GameMode.Player)
                {
                    UpdateGridUI(data.Grid, playerId);
                }
                else
                {
                    List<int> activePlayersId = data.Players.Where(p => p.GameMode == GameMode.Player).Select((p) => p.Id).ToList();
                    UpdateSpectatorModeGridUI(data.Grid, activePlayersId);
                }
            }
        }

        private void UpdateGridUI(List<List<int>> grid, int yourPawn)
        {
            for (int i = 0; i < grid.Count; i++)
            {
                for (int j = 0; j < grid[i].Count; j++)
                {
                    DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();

                    if (grid[i][j] == yourPawn)
                    {
                        cellStyle.BackColor = Color.Yellow;
                    }
                    else if (grid[i][j] != -1)
                    {
                        cellStyle.BackColor = Color.Red;
                    }

                    dtg_Forza4[j, i].Style = cellStyle;
                }
            }
        }

        private void UpdateSpectatorModeGridUI(List<List<int>> grid, List<int> playersId)
        {
            List<Color> colors = new List<Color>() { Color.Yellow, Color.Red };

            for (int i = 0; i < grid.Count; i++)
            {
                for (int j = 0; j < grid[i].Count; j++)
                {
                    if (grid[i][j] != -1)
                    {
                        int id = playersId.FindIndex(id => id == grid[i][j]);
                        if (id == -1)
                        {
                            playersId.Add(grid[i][j]);
                            dtg_Forza4[j, i].Style.BackColor = colors[playersId.Count - 1];
                        }
                        else
                        {
                            dtg_Forza4[j, i].Style.BackColor = colors[id];
                        }
                    }
                }
            }
        }

        private void DisableGridInteraction()
        {
            isGridEnabled = false;
        }

        private void EnableGridInteraction()
        {
            isGridEnabled = true;
        }

        private void EnablePlayAgain()
        {
            playAgainBtn.Enabled = true;
        }

        private void DisablePlayAgain()
        {
            playAgainBtn.Enabled = false;
        }

        private void onConnectionAccepted()
        {
            ClientRequest userData = new ClientRequest()
            {
                Username = usernameTextBox.Text,
                CanPlayGame = true,
            };

            client.SendDataToServer(userData);
        }

        private void OnDeviceDiscovered(IPAddress address)
        {
            /* Console.WriteLine("Network Discovery: Available Host: " + address.ToString());
            lstHosts.Items.Add(address); */
        }

        private void OnDiscoveredFinished(List<IPAddress> addresses)
        {
            lstHosts.Items.Clear();
            foreach (IPAddress address in addresses)
            {
                lstHosts.Items.Add(address);
            }
            searchingLbl.Text = "";
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (client != null)
            {
                client.CloseConnection();
            }
            if (server != null)
            {
                server.CloseAllConnections();
            }
        }

        private void on_DiscoverButtonClick(object sender, EventArgs e)
        {
            searchingLbl.Text = "Searching...";
            lstHosts.Items.Clear();
            client.SearchAvailableHosts();
        }

        private void on_GridCellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtg_Forza4.CurrentCell.Selected = false;
            if (!isGridEnabled) return;

            int row = e.RowIndex;
            int col = e.ColumnIndex;

            if (client.IsConnected())
            {
                ClientRequest request = new ClientRequest()
                {
                    SelectedCell = new Cell()
                    {
                        Row = row,
                        Column = col,
                    }
                };
                client.SendDataToServer(request);
            }
        }

        private void playAgainBtn_Click(object sender, EventArgs e)
        {
            if (client.IsConnected())
            {
                ClientRequest request = new ClientRequest()
                {
                    PlayAgain = true,
                };
                client.SendDataToServer(request);
            }
        }

        private void on_localAddressChange(object sender, EventArgs e)
        {
            client.ChangeLocalNetworkAddress(localAddressTextBox.Text);
        }
    }
}