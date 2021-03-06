using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AstridAlert
{
	public partial class MainForm : Form
	{
		private KeyHandler ghk;
		public NotifyIconForm frm2;
		public SettingForms frm;
		public bool formIsOpen;
		public bool settingsFormIsOpen;
		private NetworkStream serverStream;
		private TcpClient client;
		private Thread thread;
   
		public MainForm()
		{
			InitializeComponent();
			frm2 = new NotifyIconForm();
			frm2.TopMost = true;
			frm = new SettingForms();
			frm.TopMost = true;
			formIsOpen = false;
			settingsFormIsOpen = false;
			ghk = new KeyHandler(Keys.F3, this);
			ghk.Register();
			serverStream = OpenClientConn();

			while(serverStream == null)
			{
				var frm = new SettingForms();
				settingsFormIsOpen = true;
				if (frm.ShowDialog() == DialogResult.OK)
				{
					serverStream = OpenClientConn();
					settingsFormIsOpen = false;
				}
				else
				{
					Environment.Exit(0);
				}
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
			notifyIcon.BalloonTipText = "Shift + F3 to activate";
			notifyIcon.BalloonTipTitle = "Astrid Notifier";
			notifyIcon.ShowBalloonTip(2000);
		}

		public void IsFormOpen()
		{
			if (!formIsOpen)
			{
				formIsOpen = true;
				frm2.FormProgress();
				var dialogResult = frm2.ShowDialog();
				BringToFront();
				if (dialogResult == DialogResult.OK)
				{
					SendMessage(GetLocalIPAddress()+":Astrid ist da!");
					formIsOpen = false;
				}
				else
				{
					formIsOpen = false;
				}

			}
			else
			{
				formIsOpen = false;
				frm2.Close();

			}
		}

		private void astridNotifierSettings_Click(object sender, EventArgs e)
		{
            if (formIsOpen)
            {
				formIsOpen = false;
				frm2.Close();
			}

			if (!settingsFormIsOpen)
            {
				settingsFormIsOpen = true;
				frm = new SettingForms();
				frm2.TopMost = false;
				Invoke((MethodInvoker)delegate () {
					BringToFront();
				});
				
				if (frm.ShowDialog() == DialogResult.OK)
				{
                    string oldIP = CreateIPEndPoint(client.Client.RemoteEndPoint);

                    if (oldIP == Properties.Settings.Default.IP)
                    {
						MessageBox.Show("Die Verbindung besteht bereits.", "Server connection successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
						settingsFormIsOpen = false;

					}
                    else
                    {
						//worker.Abort();
						serverStream = OpenClientConn();
					}

                while (serverStream == null)
					{
						var frm3 = new SettingForms();
						if (frm3.ShowDialog() == DialogResult.OK)
						{
							serverStream = OpenClientConn();
						}
						else
						{
							Environment.Exit(0);
						}
					}
					settingsFormIsOpen = false;
				}
                else
                {
					settingsFormIsOpen = false;
                }
			
			}
            else
            {
				settingsFormIsOpen = false;
				Invoke((MethodInvoker)delegate () {
					frm.Close();
				});
			}
		}

		private void NotifyIcon_Click(object sender, EventArgs e)
		{
			var eventArgs = e as MouseEventArgs;
			switch (eventArgs.Button)
			{
				// Left click to reactivate
				case MouseButtons.Left:
					IsFormOpen();
					break;
				//case MouseButtons.Right:
				//    break;
			}
		}


		private void toolStripMenuItemExit_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Wollen Sie die Applikation beenden?", "Menu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == System.Windows.Forms.DialogResult.Yes)
			{
				notifyIcon.Visible = false;
				SendMessage(GetLocalIPAddress() + " disconnected!");
				client.Client.Shutdown(SocketShutdown.Send);
				thread.Join();
				serverStream.Close();
				client.Close();
				Environment.Exit(0);
			}
		}


		private void astridNotifierToolStripMenuItem_Click(object sender, EventArgs e)
		{
			IsFormOpen();
		}

		private void shiftF3ToActivateToolStripMenuItem_Click(object sender, EventArgs e)
		{

			SendMessage(GetLocalIPAddress() + " Astrid ist da!");

		}

		#region HOTKEY

		private void HandleHotkey()
		{
			SendMessage(GetLocalIPAddress() + " Astrid ist da!");
		}

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
				HandleHotkey();
			base.WndProc(ref m);
		}
		#endregion

		#region TCPConnection

		private NetworkStream OpenClientConn()
		{
			try
			{
				//MessageBox.Show(Properties.Settings.Default["IP"].ToString());
				IPAddress ip = IPAddress.Parse(Properties.Settings.Default["IP"].ToString());
				int port = 5000;
				client = new TcpClient();
				client.Connect(ip, port);
				Console.WriteLine("client connected!!");
				NetworkStream ns = client.GetStream();
				thread = new Thread(o => ReceiveData((TcpClient)o));

				thread.Start(client);
				return ns;
			}
			catch
			{
				Invoke((MethodInvoker)delegate () {
					MessageBox.Show(this, "Verbindung zum Server nicht möglich! ", "No Server Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
				});
				return null;
			}
			
		}

		private void openSettingsWhenConnectionLost()
		{
			if (formIsOpen)
			{
				formIsOpen = false;
				Invoke((MethodInvoker)delegate () {
					frm2.Close();
				});
			}

			if (!settingsFormIsOpen)
			{
				settingsFormIsOpen = true;
				frm = new SettingForms();
				frm2.TopMost = false;
				Invoke((MethodInvoker)delegate () {
					BringToFront();
				});
				if (frm.ShowDialog() == DialogResult.OK)
				{
					serverStream = OpenClientConn();

					while (serverStream == null)
					{
						var frm3 = new SettingForms();
						if (frm3.ShowDialog() == DialogResult.OK)
						{
							serverStream = OpenClientConn();
						}
						else
						{
							Environment.Exit(0);
						}
					}
					settingsFormIsOpen = false;
				}
				else
				{
					settingsFormIsOpen = false;
					openSettingsWhenConnectionLost();
				}

			}
			else
			{
				settingsFormIsOpen = false;
				Invoke((MethodInvoker)delegate () {
					frm.Close();
				});
			}
		}
		private void ReceiveData(TcpClient client)
		{
			NetworkStream ns = client.GetStream();
			byte[] receivedBytes = new byte[1024];
			int byte_count;
            try
            {
				while ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
				{
					var message = Encoding.UTF8.GetString(receivedBytes, 0, byte_count);
					if (!message.StartsWith(GetLocalIPAddress()))
					{
						notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
						notifyIcon.BalloonTipText = "Astrid ist da!";
						notifyIcon.BalloonTipTitle = "Astrid Notifier";
						notifyIcon.ShowBalloonTip(20000);
					}
				}
			}
            catch
            {
				Invoke((MethodInvoker)delegate () {
					MessageBox.Show(this, "Die Verbindung zum Server wurde getrennt. ", "No Server Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
				});
				openSettingsWhenConnectionLost();

			}

		}

		private void SendMessage(string s)
		{
            try
            {
				byte[] buffer = Encoding.UTF8.GetBytes(s);
				serverStream.Write(buffer, 0, buffer.Length);
			}
            catch
            {
				openSettingsWhenConnectionLost();
            }
		}

		#endregion

		#region HELPERS

		public string CreateIPEndPoint(EndPoint endPoint)
		{
			string stringEndpoint = ((IPEndPoint)endPoint).Address.ToString();
			string[] ep = stringEndpoint.Split(':');

			IPAddress ip;
			if (!IPAddress.TryParse(ep.Last(), out ip))
			{
				//MessageBox.Show("Keine IpAdresse!");
				throw new FormatException("Invalid ip-adress");


			}
			return ip.ToString();
		}
		public static string GetLocalIPAddress()

		{
			var host = Dns.GetHostEntry(Dns.GetHostName());
			foreach (var ip in host.AddressList)
			{
				if (ip.AddressFamily == AddressFamily.InterNetwork)
				{
					if (ip.ToString().StartsWith("192.168.")) //192.168. //Here it is ok, if there are only two places after the dot.
						return ip.ToString();
				}
			}
			throw new Exception("No network adapters with an IPv4 address in the system!");
		}

        #endregion

    }
}
