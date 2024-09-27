namespace MyWinFormsComApp
{
    partial class MainForm
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
            button_Close = new Button();
            label1 = new Label();
            txtReceivedData = new TextBox();
            txtSendData = new TextBox();
            label2 = new Label();
            label3 = new Label();
            button_Send = new Button();
            button_Clear_Received = new Button();
            button_Clear_Send = new Button();
            panel_red = new Panel();
            panel_green = new Panel();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button_Connect = new Button();
            comboBox_Ports = new ComboBox();
            label4 = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            button_Disconnect = new Button();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button_Close
            // 
            button_Close.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_Close.Location = new Point(689, 418);
            button_Close.Name = "button_Close";
            button_Close.Size = new Size(99, 23);
            button_Close.TabIndex = 14;
            button_Close.Text = "Close";
            button_Close.UseVisualStyleBackColor = true;
            button_Close.Click += button_Close_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 14F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(217, 25);
            label1.TabIndex = 1;
            label1.Text = "MyWinFormsComApp";
            // 
            // txtReceivedData
            // 
            txtReceivedData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtReceivedData.Location = new Point(12, 73);
            txtReceivedData.Multiline = true;
            txtReceivedData.Name = "txtReceivedData";
            txtReceivedData.ScrollBars = ScrollBars.Vertical;
            txtReceivedData.Size = new Size(671, 300);
            txtReceivedData.TabIndex = 1;
            // 
            // txtSendData
            // 
            txtSendData.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSendData.Location = new Point(12, 399);
            txtSendData.Multiline = true;
            txtSendData.Name = "txtSendData";
            txtSendData.ScrollBars = ScrollBars.Vertical;
            txtSendData.Size = new Size(671, 43);
            txtSendData.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 50);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 4;
            label2.Text = "Received Data:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(12, 376);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 5;
            label3.Text = "Send Data:";
            // 
            // button_Send
            // 
            button_Send.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_Send.Location = new Point(689, 389);
            button_Send.Name = "button_Send";
            button_Send.Size = new Size(99, 23);
            button_Send.TabIndex = 13;
            button_Send.Text = "Send";
            button_Send.UseVisualStyleBackColor = true;
            button_Send.Click += button_Send_Click;
            // 
            // button_Clear_Received
            // 
            button_Clear_Received.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_Clear_Received.Location = new Point(689, 331);
            button_Clear_Received.Name = "button_Clear_Received";
            button_Clear_Received.Size = new Size(99, 23);
            button_Clear_Received.TabIndex = 11;
            button_Clear_Received.Text = "Clear Received";
            button_Clear_Received.UseVisualStyleBackColor = true;
            button_Clear_Received.Click += button_Clear_Received_Click;
            // 
            // button_Clear_Send
            // 
            button_Clear_Send.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_Clear_Send.Location = new Point(689, 360);
            button_Clear_Send.Name = "button_Clear_Send";
            button_Clear_Send.Size = new Size(99, 23);
            button_Clear_Send.TabIndex = 12;
            button_Clear_Send.Text = "Clear Send";
            button_Clear_Send.UseVisualStyleBackColor = true;
            button_Clear_Send.Click += button_Clear_Send_Click;
            // 
            // panel_red
            // 
            panel_red.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel_red.BackColor = Color.Red;
            panel_red.ForeColor = SystemColors.ControlText;
            panel_red.Location = new Point(716, 38);
            panel_red.Name = "panel_red";
            panel_red.Size = new Size(20, 20);
            panel_red.TabIndex = 9;
            // 
            // panel_green
            // 
            panel_green.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel_green.BackColor = Color.Lime;
            panel_green.ForeColor = SystemColors.ControlText;
            panel_green.Location = new Point(742, 38);
            panel_green.Name = "panel_green";
            panel_green.Size = new Size(20, 20);
            panel_green.TabIndex = 10;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(689, 99);
            button1.Name = "button1";
            button1.Size = new Size(99, 23);
            button1.TabIndex = 3;
            button1.Text = "#1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(689, 128);
            button2.Name = "button2";
            button2.Size = new Size(99, 23);
            button2.TabIndex = 4;
            button2.Text = "#2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.Location = new Point(689, 157);
            button3.Name = "button3";
            button3.Size = new Size(99, 23);
            button3.TabIndex = 5;
            button3.Text = "#3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button4.Location = new Point(689, 186);
            button4.Name = "button4";
            button4.Size = new Size(99, 23);
            button4.TabIndex = 6;
            button4.Text = "#4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button5.Location = new Point(689, 215);
            button5.Name = "button5";
            button5.Size = new Size(99, 23);
            button5.TabIndex = 7;
            button5.Text = "#5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button6.Location = new Point(689, 244);
            button6.Name = "button6";
            button6.Size = new Size(99, 23);
            button6.TabIndex = 8;
            button6.Text = "#6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button_Connect
            // 
            button_Connect.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_Connect.Location = new Point(689, 273);
            button_Connect.Name = "button_Connect";
            button_Connect.Size = new Size(99, 23);
            button_Connect.TabIndex = 9;
            button_Connect.Text = "Connect";
            button_Connect.UseVisualStyleBackColor = true;
            button_Connect.Click += button_Connect_Click;
            // 
            // comboBox_Ports
            // 
            comboBox_Ports.FormattingEnabled = true;
            comboBox_Ports.Location = new Point(378, 44);
            comboBox_Ports.Name = "comboBox_Ports";
            comboBox_Ports.Size = new Size(121, 23);
            comboBox_Ports.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(340, 50);
            label4.Name = "label4";
            label4.Size = new Size(32, 15);
            label4.TabIndex = 15;
            label4.Text = "Port:";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 458);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 16;
            statusStrip1.Text = "statusStripc";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 17);
            // 
            // button_Disconnect
            // 
            button_Disconnect.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_Disconnect.Location = new Point(689, 302);
            button_Disconnect.Name = "button_Disconnect";
            button_Disconnect.Size = new Size(99, 23);
            button_Disconnect.TabIndex = 10;
            button_Disconnect.Text = "Disconnect";
            button_Disconnect.UseVisualStyleBackColor = true;
            button_Disconnect.Click += button_Disconnect_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 480);
            Controls.Add(button_Disconnect);
            Controls.Add(statusStrip1);
            Controls.Add(label4);
            Controls.Add(comboBox_Ports);
            Controls.Add(button_Connect);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel_green);
            Controls.Add(panel_red);
            Controls.Add(button_Clear_Send);
            Controls.Add(button_Clear_Received);
            Controls.Add(button_Send);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtSendData);
            Controls.Add(txtReceivedData);
            Controls.Add(label1);
            Controls.Add(button_Close);
            Name = "MainForm";
            Text = "MyMainFormComApp";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_Close;
        private Label label1;
        private TextBox txtReceivedData;
        private TextBox txtSendData;
        private Label label2;
        private Label label3;
        private Button button_Send;
        private Button button_Clear_Received;
        private Button button_Clear_Send;
        private Panel panel_red;
        private Panel panel_green;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button_Connect;
        private ComboBox comboBox_Ports;
        private Label label4;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Button button_Disconnect;
    }
}
