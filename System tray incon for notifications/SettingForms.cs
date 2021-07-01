using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
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
			this.AutostartBox.Checked = Properties.Settings.Default.AutoStart;
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

		private void RegisterInStartup(bool isChecked)
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
					("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
			if (isChecked)
			{
				registryKey.SetValue("AstridAlert", Process.GetCurrentProcess().MainModule.FileName);
				Properties.Settings.Default.AutoStart = true;
				Properties.Settings.Default.Save();
			}
			else
			{
				registryKey.DeleteValue("AstridAlert");
				Properties.Settings.Default.AutoStart = false;
				Properties.Settings.Default.Save();
			}
		}


        private void AutostartBox_CheckedChanged(object sender, EventArgs e)
        {
			RegisterInStartup(((CheckBox)sender).Checked);
		}
	}
}
