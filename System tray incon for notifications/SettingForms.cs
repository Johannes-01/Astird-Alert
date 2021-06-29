using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AstridAlert
{
	public partial class SettingForms : Form
	{    
        public SettingForms()
		{
			InitializeComponent();
			this.txtServerIP.Text = Properties.Settings.Default.IP;
			this.StartPosition = FormStartPosition.Manual;
			this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
		}

		private void SaveSettings_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.IP = txtServerIP.Text;
			Properties.Settings.Default.Save();
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		
	}
}
