using Forza4Socket.ClientSide;
using Forza4Socket.ServerSide;
using Forza4Socket.Grid;

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
            if(client == null)
            {
                client = new Client();
            }
            client.ConnectToServer();
        }

        private void sendDataBtn_Click(object sender, EventArgs e)
        {
            Cell selectedCell = new Cell() { Row = 4, Column = 3};
            client.SendDataToServer(new ClientRequest() { SelectedCell = selectedCell});
        }

        private void serverBtn_Click(object sender, EventArgs e)
        {
            if(server == null)
            {
                server = new Server();
            }
            if (client == null)
            {
                client = new Client();
            }
            server.Setup();
            client.ConnectToServer();
        }
    }
}