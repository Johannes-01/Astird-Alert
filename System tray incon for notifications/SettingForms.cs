using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace System_tray_incon_for_notifications
{
	public partial class SettingForms : Form
	{
		public SettingForms()
		{
			InitializeComponent();
			this.textBox1.Text = Properties.Settings.Default.IP;
			this.StartPosition = FormStartPosition.Manual;
			this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.IP = textBox1.Text;
			Properties.Settings.Default.Save();
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
