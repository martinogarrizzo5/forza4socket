using Forza4Socket.ClientSide;
using Forza4Socket.ServerSide;
using Forza4Socket.Game;
using Forza4Socket.Network;
using System.Net;
using System.ComponentModel;

namespace Forza4Socket
{
    public partial class Form1 : Form
    {
        Client client;
        Server server;

        public Form1()
        {
            client = new Client(new Action<ServerResponse>(UpdateUIWhenReceivingData), new Action<IPAddress>(OnDeviceDiscovered), new Action(onConnectionAccepted));
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
        }

        private void UpdateUIWhenReceivingData(ServerResponse data)
        {
            if (data.GameStarted == true)
            {

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
            Console.WriteLine("Network Discovery: Available Host: " + address.ToString());
            lstHosts.Items.Add(address);
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

        private void discoverDevicesBtn(object sender, EventArgs e)
        {
            lstHosts.Items.Clear();
            client.SearchAvailableHosts();
        }
    }
}