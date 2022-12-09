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

        public Form1()
        {
            client = new Client(new Action<ServerResponse>(UpdateUIWhenReceivingData), new Action<IPAddress>(OnDeviceDiscovered), new Action(onConnectionAccepted), new Action<List<IPAddress>>(OnDiscoveredFinished));
            InitializeComponent();
        }

        private void clientBtn_Click(object sender, EventArgs e)
        {
            IPAddress ip = (IPAddress?)lstHosts.SelectedItem;
            if (ip != null)
            {
                client.ConnectToServer(ip);
            }
        }

        private void serverBtn_Click(object sender, EventArgs e)
        {
            server = new Server();
            server.Setup();
            client.ConnectToServer(IPAddress.Loopback);
            lblTurnPlayer.Text = "In attesa di un giocatore...";
            dtg_Forza4.ColumnCount = 7;
            dtg_Forza4.RowCount = 6;
            dtg_Forza4.ColumnHeadersVisible = false;
            dtg_Forza4.RowHeadersVisible = false;
            dtg_Forza4.DefaultCellStyle.SelectionBackColor = Color.White;
            for (int i=0; i<6; i++)
            {
                DataGridViewRow row = dtg_Forza4.Rows[i];
                row.Height = 69;
            }
            btn_Server.Enabled = false;
            btn_Connect.Enabled = false;
            btn_Discover.Enabled = false;
        }

        private void UpdateUIWhenReceivingData(ServerResponse data)
        {
            if (data.GameStarted == true)
            {
                if (data.Player != null && data.TurnPlayer != null && data.TurnPlayer != -1)
                {
                    if (data.TurnPlayer == data.Player.Id)
                    {
                        lblTurnPlayer.Text = $"è il tuo turno {data.Player.Username}";
                    }
                    else
                    {
                        lblTurnPlayer.Text = "In attesa della mossa dell'altro giocatore";
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

        private void dtg_Forza4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}