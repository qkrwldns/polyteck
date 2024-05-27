using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Threading;

namespace SerialParsing
{
    public partial class Form1 : Form
    {
        // 콘솔 창 활성화를 위한 DLL 임포트
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();

        private SerialPort _serialPort;
        private int checksum = 0;
        private List<int> receivedAsciiList = new List<int>();

        public Form1()
        {
            InitializeComponent();
            AllocConsole(); // 콘솔 창 활성화
            LoadAvailablePorts();
            StartConsoleInputThread();
        }

        private void LoadAvailablePorts()
        {
            string[] ports = SerialPort.GetPortNames();
            comboBoxPorts.Items.AddRange(ports);
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (_serialPort == null)
            {
                if (comboBoxPorts.SelectedItem == null)
                {
                    MessageBox.Show("포트부터 선택해주세요.");
                    return;
                }

                _serialPort = new SerialPort(comboBoxPorts.SelectedItem.ToString(), 9600, Parity.None, 8, StopBits.One);
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                _serialPort.Open();
                buttonConnect.Text = "연결 해제";
            }
            else
            {
                _serialPort.Close();
                _serialPort = null;
                buttonConnect.Text = "연결";
            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            while (sp.BytesToRead > 0)
            {
                int receivedAscii = sp.ReadByte();

                // 줄 바꿈 문자를 체크 (CR + LF)
                if (receivedAscii == 10 || receivedAscii == 13)
                {
                    // 체크섬 계산: 상위 비트 제거 후 보수 처리
                    int checksumTotal = checksum & 0xFF; // 상위 비트 제거
                    int checksumValue = ~checksumTotal + 1; // 보수 처리

                    // CR 또는 LF를 수신하면 체크섬 출력
                    this.Invoke(new MethodInvoker(delegate
                    {
                        textBoxOutput.AppendText($"체크섬: {checksumValue}{Environment.NewLine}");
                        Console.WriteLine($"체크섬: {checksumValue}");
                    }));

                    checksum = 0; // 체크섬 초기화
                    receivedAsciiList.Clear(); // 리스트 초기화

                    // 만약 CR(13)을 수신했다면 LF(10)도 같이 수신될 수 있으므로 추가로 처리
                    if (receivedAscii == 13 && sp.BytesToRead > 0 && sp.ReadByte() == 10)
                    {
                        // LF(10) 처리, 별도의 작업 없음
                    }
                }
                else
                {
                    checksum += receivedAscii;
                    receivedAsciiList.Add(receivedAscii); // 리스트에 ASCII 값 저장

                    char receivedChar = (char)receivedAscii; // 현재 수신된 문자 저장
                    this.Invoke(new MethodInvoker(delegate
                    {
                        textBoxOutput.AppendText($"문자: {receivedChar}, ASCII: {receivedAscii}, 체크섬: {checksum}{Environment.NewLine}");
                        Console.WriteLine($"문자: {receivedChar}, ASCII: {receivedAscii}, 체크섬: {checksum}");
                    }));
                }
            }
        }




        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxOutput.Clear();
            checksum = 0;
            receivedAsciiList.Clear();
        }

        private void StartConsoleInputThread()
        {
            Thread consoleInputThread = new Thread(new ThreadStart(ConsoleInputHandler));
            consoleInputThread.IsBackground = true;
            consoleInputThread.Start();
        }

        private void ConsoleInputHandler()
        {
            while (true)
            {
                string command = Console.ReadLine();
                if (command.Equals("showchecksum", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Current Checksum: {checksum}");
                }
                else if (command.StartsWith("showchar ", StringComparison.OrdinalIgnoreCase))
                {
                    string charStr = command.Substring(9).Trim();
                    if (charStr.Length == 1)
                    {
                        char charToShow = charStr[0];
                        int asciiValue = charToShow;
                        if (receivedAsciiList.Contains(asciiValue))
                        {
                            Console.WriteLine($"Char: {charToShow}, ASCII: {asciiValue}");
                        }
                        else
                        {
                            Console.WriteLine($"Char '{charToShow}' not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a single character.");
                    }
                }
                else if (command.Equals("showallchars", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("All Received Characters:");
                    foreach (int asciiValue in receivedAsciiList)
                    {
                        char receivedChar = (char)asciiValue;
                        Console.WriteLine($"Char: {receivedChar}, ASCII: {asciiValue}");
                    }
                }
                else
                {
                    Console.WriteLine("Unknown command. Available commands: showchecksum, showchar <char>, showallchars");
                }
            }
        }
    }
}
