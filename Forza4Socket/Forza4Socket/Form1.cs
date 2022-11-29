using Forza4Socket.ClientSide;
using Forza4Socket.ServerSide;
using Forza4Socket.Grid;
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
        }

        private void clientBtn_Click(object sender, EventArgs e)
        {
            if (client == null)
            {
                client = new Client(new Action<ServerResponse>(UpdateUIWhenReceivingData));
            }
            client.ConnectToServer();
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
            if (client == null)
            {
                client = new Client(new Action<ServerResponse>(UpdateUIWhenReceivingData));
            }
            server.Setup();
            client.ConnectToServer();
        }

        private void UpdateUIWhenReceivingData(ServerResponse data)
        {
            label1.Text = "Turn player " + data.TurnPlayer.ToString();
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
    }
}