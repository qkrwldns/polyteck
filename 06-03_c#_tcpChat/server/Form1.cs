using ChatLib.Models;
using System.Net;
using System.Net.Sockets;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ChatServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private TcpListener _listener;
        private async void btnListen_Click(object sender, EventArgs e)
        {
            _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8000);
            // 스타트하게 되면 아래의 리스너는 위의 리스너의 ip와 포트로 실행하게 됨! 서버 실행.. 
            _listener.Start();
          
            while (true)
            {
                TcpClient client = await _listener.AcceptTcpClientAsync();
                _ = HandleClient(client);
            }
           
        }

        private async Task HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            // 클라이언트에서 처음에 넘어오는 버퍼의 크기가 4바이트라서 4로 해줌 (버퍼의 길이)
            byte[] sizqBuffer = new byte[4];
            int read;
            while (true)
            {
                read = await stream.ReadAsync(sizqBuffer, 0, sizqBuffer.Length);
                if (read == 0)
                {
                    break;
                }
                int size = BitConverter.ToInt32(sizqBuffer);
                byte[] buffer = new byte[size];
                read = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (read == 0)
                {
                    break;
                }
                
                string message = Encoding.UTF8.GetString(buffer, 0, read);
                var hub = Chathub.Parse(message);
                listBox1.Items.Add($"UserId : {hub.UserId}, RoomID : {hub.RoomId}," + $"UserName : {hub.UserName}, Message : {hub.Message}");
                // MessageBox.Show(message);
                var messageBuffer = Encoding.UTF8.GetBytes($"Server : {message}");

                stream.Write(messageBuffer);
            }
            
        }
    }
}

