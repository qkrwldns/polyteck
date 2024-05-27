using SimpleTCP;
using System.Text;

namespace TCPIPdemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpServer server;

        private void Form1_Load(object sender, EventArgs e)
        {
            server = new SimpleTcpServer();
            server.Delimiter = 0x13;// enter
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += Server_DataReceived;
        }

        private void Server_DataReceived(object? sender, SimpleTCP.Message e)
        {
            /* txtStatus.Invoke((MethodInvoker)delegate ()
            {
                txtStatus.Text += e.MessageString;
                e.ReplyLine(string.Format("You said: {0}", e.MessageString));
            }); */

            txtStatus.Invoke((MethodInvoker)delegate ()
            {
                string receivedMsg = e.MessageString.TrimEnd((char)server.Delimiter); // Delimiter 제거 (위에처럼하니까 !! 문자가 붙어서 감)
                txtStatus.Text += receivedMsg;
                e.ReplyLine(string.Format("You said: {0}", receivedMsg));
            });
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
   
            try
            {
                System.Net.IPAddress ip = System.Net.IPAddress.Parse(txtHost.Text);
                server.Start(ip, Convert.ToInt32(txtPort.Text));
                txtStatus.Text += "Server started successfully.\n";
            }
            catch (Exception ex)
            {
                txtStatus.Text += "Error starting server: " + ex.Message + "\n";
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (server.IsStarted)
            {
                server.Stop();
            }
        }
    }
}
