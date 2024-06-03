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
            // ��ŸƮ�ϰ� �Ǹ� �Ʒ��� �����ʴ� ���� �������� ip�� ��Ʈ�� �����ϰ� ��! ���� ����.. 
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
            // Ŭ���̾�Ʈ���� ó���� �Ѿ���� ������ ũ�Ⱑ 4����Ʈ�� 4�� ���� (������ ����)
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

