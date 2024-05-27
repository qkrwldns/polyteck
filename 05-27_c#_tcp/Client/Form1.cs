using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtHost_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        SimpleTcpClient client;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try              
            {
                client.Connect(txtHost.Text, Convert.ToInt32(txtPort.Text)); // 호스트와 포트로 연결
                btnConnect.Enabled = false; // 연결 후 버튼 비활성화
            }
            catch (Exception ex)
            {
                MessageBox.Show("연결 실패: " + ex.Message);
                btnConnect.Enabled = true; // 연결 실패 시 버튼을 다시 활성화
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            client = new SimpleTcpClient(); 
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += Client_DataReceived;
        }

        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            txtStatus.Invoke((MethodInvoker)delegate ()
            {
                txtStatus.Text += e.MessageString;
                
            });
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            client.WriteLineAndGetReply(txtMessage.Text, TimeSpan.FromSeconds(3));
        }
    }
}
