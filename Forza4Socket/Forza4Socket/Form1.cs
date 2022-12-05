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
            InitializeComponent();
            client = new Client(new Action<ServerResponse>(UpdateUIWhenReceivingData), new Action<IPAddress>(OnDeviceDiscovered));
        }

        private void clientBtn_Click(object sender, EventArgs e)
        {
            client.ConnectToServer(IPAddress.Loopback);
        }

        private void sendDataBtn_Click(object sender, EventArgs e)
        {
            Cell selectedCell = new Cell() { Row = 4, Column = 3 };
            client.SendDataToServer(new ClientRequest() { SelectedCell = selectedCell });
        }

        private void serverBtn_Click(object sender, EventArgs e)
        {
            if (server == null)
            {
                server = new Server();
            }
            server.Setup();
            client.ConnectToServer(IPAddress.Loopback);
        }

        private void UpdateUIWhenReceivingData(ServerResponse data)
        {
            label1.Text = "Turn player " + data.TurnPlayer.ToString();
        }

        private void OnNetworkDiscovering()
        {
            Console.WriteLine("discovering");
        }

        private void OnDeviceDiscovered(IPAddress address)
        {
            Console.WriteLine("Network Discovery: Available Host: " + address.ToString());
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

        private void button1_Click(object sender, EventArgs e)
        {
            client.SearchAvailableHosts();
        }
    }
}