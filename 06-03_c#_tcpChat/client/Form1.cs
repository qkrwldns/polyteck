using ChatLib.Models;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChatClient1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private TcpClient _client;

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            _client = new TcpClient();
            await _client.ConnectAsync(IPAddress.Parse("127.0.0.1"), 8000);
            _ = HandleClient(_client);
        }
        private async Task HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int read;
            while ((read = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {

                string message = Encoding.UTF8.GetString(buffer, 0, read);

                listBox1.Items.Add(message);
                // MessageBox.Show(message);

            }

        }
        private async void btnSend_Click(object sender, EventArgs e)
        {
            NetworkStream stream = _client.GetStream();

            string text = textBox1.Text;
            Chathub hub = new Chathub 
            { 
                UserId = 1,
                RoomId = 2,
                UserName = "테스트 글",
                Message = text,
            };
            var messageBuffer = Encoding.UTF8.GetBytes(hub.ToJsonString());
            var messageLengthBuffer = BitConverter.GetBytes(messageBuffer.Length);
     

                stream.Write(messageLengthBuffer, 0, messageLengthBuffer.Length);
                stream.Write(messageBuffer, 0, messageBuffer.Length);

      

        }
    }
}
