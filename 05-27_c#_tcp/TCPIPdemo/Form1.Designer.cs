namespace TCPIPdemo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnStart = new Button();
            label1 = new Label();
            txtHost = new TextBox();
            txtPort = new TextBox();
            label2 = new Label();
            btnStop = new Button();
            txtStatus = new TextBox();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(464, 38);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(117, 38);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(89, 48);
            label1.Name = "label1";
            label1.Size = new Size(50, 25);
            label1.TabIndex = 1;
            label1.Text = "Host";
            // 
            // txtHost
            // 
            txtHost.Location = new Point(155, 45);
            txtHost.Name = "txtHost";
            txtHost.ScrollBars = ScrollBars.Vertical;
            txtHost.Size = new Size(158, 31);
            txtHost.TabIndex = 2;
            txtHost.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(387, 42);
            txtPort.Name = "txtPort";
            txtPort.ScrollBars = ScrollBars.Vertical;
            txtPort.Size = new Size(71, 31);
            txtPort.TabIndex = 4;
            txtPort.Text = "8910";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(336, 45);
            label2.Name = "label2";
            label2.Size = new Size(45, 25);
            label2.TabIndex = 3;
            label2.Text = "Port";
            // 
            // btnStop
            // 
            btnStop.Location = new Point(587, 38);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(117, 38);
            btnStop.TabIndex = 5;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(155, 99);
            txtStatus.Multiline = true;
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(549, 169);
            txtStatus.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(735, 300);
            Controls.Add(txtStatus);
            Controls.Add(btnStop);
            Controls.Add(txtPort);
            Controls.Add(label2);
            Controls.Add(txtHost);
            Controls.Add(label1);
            Controls.Add(btnStart);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Server";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Label label1;
        private TextBox txtHost;
        private TextBox txtPort;
        private Label label2;
        private Button btnStop;
        private TextBox txtStatus;
    }
}
