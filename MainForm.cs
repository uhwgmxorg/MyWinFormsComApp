using Microsoft.AspNetCore.Components;
using System.Data;
using System.Diagnostics;
using System.IO.Ports;

namespace MyWinFormsComApp
{
    public partial class MainForm : Form
    {

        private SerialPort? serialPort;
        private string ReceiveString = string.Empty;

        private bool isRedLedOn = false;
        private bool isGreenLedOn = false;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            SetRedOff();
            SetGreenOff();

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;

            comboBox_Ports.SelectedIndexChanged += comboBox_Ports_SelectedIndexChanged;
            FillComboBoxPorts();
            toolStripStatusLabel1.Text = "Disconnected";
            // Adjust font: Connect bold, Disconnect normal
            button_Connect.Font = new Font(button_Connect.Font, FontStyle.Bold);
            button_Disconnect.Font = new Font(button_Disconnect.Font, FontStyle.Regular);
        }

        /******************************/
        /*       Button Events        */
        /******************************/
        #region Button Events

        /// <summary>
        /// button1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Button1 clicked");
            ToggleRedLed();
        }

        /// <summary>
        /// button2_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Button2 clicked");
            ToggleGreenLed();
        }

        /// <summary>
        /// button3_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Button3 clicked");
            SetRedOn();
        }

        /// <summary>
        /// button4_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Button4 clicked");
            SetRedOff();
        }

        /// <summary>
        /// button5_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Button5 clicked");
            SetGreenOn();
        }

        /// <summary>
        /// button6_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Button6 clicked");
            SetGreenOff();
        }

        /// <summary>
        /// button_Connect_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Connect_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Button_Connect_Click clicked");
            InitComInterface();
        }

        /// <summary>
        /// button_Disconnect_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Disconnect_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Button_Disconnect_Click clicked");
            DisconnectComInterface();
        }

        /// <summary>
        /// button_Clear_Received_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Clear_Received_Click(object sender, EventArgs e)
        {
            txtReceivedData.Text = string.Empty;
        }

        /// <summary>
        /// button_Clear_Send_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Clear_Send_Click(object sender, EventArgs e)
        {
            txtSendData.Text = string.Empty;
        }

        /// <summary>
        /// button_Clear_Send_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Send_Click(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                try
                {
                    string dataToSend = txtSendData.Text;

                    // Optional: Add a line ending if necessary
                    dataToSend += "\r\n";

                    serialPort.Write(dataToSend);

                    // Optional: Indicate that the data has been sent
                    //MessageBox.Show("Data sent successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending data:" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("The serial port is not open.");
            }
        }

        /// <summary>
        /// button_Close_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
        /******************************/
        /*      Menu Events           */
        /******************************/
        #region Menu Events


        #endregion
        /******************************/
        /*      Other Events          */
        /******************************/
        #region Other Events

        /// <summary>
        /// MainForm_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            Location = Properties.Settings.Default.LastWindowLocation;
            Size = Properties.Settings.Default.LastWindowSize;

            // Get the version string safely
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "Version not set";

            string mode = "";
#if DEBUG
            mode = "Debug";
#else
    mode = "Release";
#endif

            Text += $" - {mode} Version {version}";

            // Make the Panel round
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, panel_red.Width, panel_red.Height);
            panel_red.Region = new Region(gp);

            // Make the Panel round
            gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, panel_green.Width, panel_green.Height);
            panel_green.Region = new Region(gp);

            panel_red.Paint += PanelRedLed_Paint;
            panel_green.Paint += PanelGreenLed_Paint;
        }
        private void PanelRedLed_Paint(object? sender, PaintEventArgs e)
        {
            // Größe des Rands in Pixeln
            int borderWidth = 2;

            // Farbe des Rands (schwarz)
            Color borderColor = Color.Black;

            // Erzeuge einen Stift für den Rand
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                // Zeichne den Rand als Ellipse
                e.Graphics.DrawEllipse(pen, borderWidth / 2, borderWidth / 2, panel_red.Width - borderWidth, panel_red.Height - borderWidth);
            }
        }
        private void PanelGreenLed_Paint(object? sender, PaintEventArgs e)
        {
            // Größe des Rands in Pixeln
            int borderWidth = 2;

            // Farbe des Rands (schwarz)
            Color borderColor = Color.Black;

            // Erzeuge einen Stift für den Rand
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                // Zeichne den Rand als Ellipse
                e.Graphics.DrawEllipse(pen, borderWidth / 2, borderWidth / 2, panel_green.Width - borderWidth, panel_green.Height - borderWidth);
            }
        }

        /// <summary>
        /// comboBox_Ports_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_Ports_SelectedIndexChanged(object? sender, EventArgs? e)
        {
            var p = Properties.Settings.Default;
            if (comboBox_Ports.SelectedItem != null)
            {
                p.COMPort = comboBox_Ports.SelectedItem.ToString();
                p.Save();
            }
        }

        /// <summary>
        /// DataReceivedHandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<object, SerialDataReceivedEventArgs>(DataReceivedHandler), sender, e);
            }
            else
            {
                SerialPort sp = (SerialPort)sender;
                string inData = sp.ReadExisting();

                // Zeilenumbrüche entfernen und empfangene Daten hinzufügen
                txtReceivedData.Text += inData;
                ReceiveString += inData;

                Debug.WriteLine("Received: " + ReceiveString);

                // Verarbeite die Daten und prüfe auf spezifische Befehle
                if (ReceiveString.Contains("switch 01 pressed"))
                {
                    //SetRedOn();
                    SetGreenOn();

                    // Entferne den verarbeiteten Teil der Nachricht
                    ReceiveString = ReceiveString.Replace("switch 01 pressed", "");
                }
                if (ReceiveString.Contains("switch 01 released"))
                {
                    //SetRedOff();
                    SetGreenOff();

                    // Entferne den verarbeiteten Teil der Nachricht
                    ReceiveString = ReceiveString.Replace("switch 01 released", "");
                }
            }
        }

        /// <summary>
        /// MainForm_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save the current window location and size
            Properties.Settings.Default.LastWindowLocation = this.Location;
            Properties.Settings.Default.LastWindowSize = this.Size;
            Properties.Settings.Default.Save();
        }

        #endregion
        /******************************/
        /*      Other Functions       */
        /******************************/
        #region Other Functions

        /// <summary>
        /// FillComboBoxPorts
        /// </summary>
        private void FillComboBoxPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            Array.Reverse(ports); // Reverse the order of the ports
            comboBox_Ports.Items.AddRange(ports); // Add the ports to the ComboBox

            // Check if the saved COM port exists in the list
            var savedPort = Properties.Settings.Default.COMPort;
            if (!string.IsNullOrEmpty(savedPort) && comboBox_Ports.Items.Contains(savedPort))
            {
                comboBox_Ports.SelectedItem = savedPort; // Select the saved COM port
            }
            else if (ports.Length > 0)
            {
                // Select the first port if the saved port is not available
                comboBox_Ports.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// SetRedOn
        /// </summary>
        private void SetRedOn()
        {
            isRedLedOn = true;
            UpdateLeds();
        }

        /// <summary>
        /// SetRedOff
        /// </summary>
        private void SetRedOff()
        {
            isRedLedOn = false;
            UpdateLeds();
        }

        /// <summary>
        /// SetGreenOn
        /// </summary>
        private void SetGreenOn()
        {
            isGreenLedOn = true;
            UpdateLeds();
        }

        /// <summary>
        /// SetGreenOff
        /// </summary>
        private void SetGreenOff()
        {
            isGreenLedOn = false;
            UpdateLeds();
        }

        /// <summary>
        /// ToggleRedLed
        /// </summary>
        private void ToggleRedLed()
        {
            isRedLedOn = !isRedLedOn; // Umschalten zwischen an und aus
            UpdateLeds();
        }

        /// <summary>
        /// ToggleGreenLed
        /// </summary>
        private void ToggleGreenLed()
        {
            isGreenLedOn = !isGreenLedOn; // Umschalten zwischen an und aus
            UpdateLeds();
        }

        /// <summary>
        /// UpdateLeds
        /// </summary>
        private void UpdateLeds()
        {
            if (isRedLedOn)
                panel_red.BackColor = Color.Red;
            else
                panel_red.BackColor = Color.DarkRed;

            if (isGreenLedOn)
                panel_green.BackColor = Color.Lime;
            else
                panel_green.BackColor = Color.DarkGreen;

            // Redraw the panel to update the border
            panel_red.Invalidate();
            panel_green.Invalidate();
        }

        /// <summary>
        /// InitComInterface
        /// Connect
        /// </summary>
        private void InitComInterface()
        {
            var p = Properties.Settings.Default;
            try
            {
                serialPort = new SerialPort(p.COMPort);
                serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                serialPort.BaudRate = 9600;
                serialPort.Parity = Parity.None;
                serialPort.StopBits = StopBits.One;
                serialPort.DataBits = 8;
                serialPort.Handshake = Handshake.None;
                serialPort.Open();

                // Set the status in the status bar
                toolStripStatusLabel1.Text = $"Connected to {p.COMPort}";

                // Adjust font: Disconnect bold, Connect normal
                button_Disconnect.Font = new Font(button_Disconnect.Font, FontStyle.Bold);
                button_Connect.Font = new Font(button_Connect.Font, FontStyle.Regular);
            }
            catch (Exception e)
            {
                MessageBox.Show("The specified COM port (" + p.COMPort + ") is not available. Please take a different!\n");
                MessageBox.Show(e.ToString());

                // Set the status in the status bar to Error
                toolStripStatusLabel1.Text = "Connection failed";
            }
        }

        /// <summary>
        /// DisconnectComInterface
        /// Disconnect
        /// </summary>
        private void DisconnectComInterface()
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                try
                {
                    serialPort.Close();
                    toolStripStatusLabel1.Text = "Disconnected";

                    // Adjust font: Connect bold, Disconnect normal
                    button_Connect.Font = new Font(button_Connect.Font, FontStyle.Bold);
                    button_Disconnect.Font = new Font(button_Disconnect.Font, FontStyle.Regular);
                }
                catch (Exception e)
                {
                    MessageBox.Show("An error occurred while disconnecting the COM port.\n" + e.ToString());
                }
            }
            else
            {
                MessageBox.Show("No COM port is currently connected.");
            }
        }

        #endregion
    }
}
