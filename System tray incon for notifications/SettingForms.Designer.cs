
using System.Drawing;
using System.Windows.Forms;

namespace AstridAlert
{
	partial class SettingForms
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.btnSaveServerIP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSaveServerIP
            // 
            this.btnSaveServerIP.AccessibleName = "btnSaveServerIP";
            this.btnSaveServerIP.Location = new System.Drawing.Point(275, 13);
            this.btnSaveServerIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveServerIP.Name = "btnSaveServerIP";
            this.btnSaveServerIP.Size = new System.Drawing.Size(86, 31);
            this.btnSaveServerIP.TabIndex = 0;
            this.btnSaveServerIP.Text = "Speichern";
            this.btnSaveServerIP.UseVisualStyleBackColor = true;
            this.btnSaveServerIP.Click += new System.EventHandler(this.SaveSettings_Click);
            // 
            // label1
            // 
            this.label1.AccessibleName = "lblServerIP";
            this.label1.Location = new System.Drawing.Point(-2, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server IP:";
            // 
            // txtServerIP
            // 
            this.txtServerIP.AccessibleName = "txtServerIP";
            this.txtServerIP.Location = new System.Drawing.Point(83, 15);
            this.txtServerIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(185, 27);
            this.txtServerIP.TabIndex = 2;
            // 
            // SettingForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 56);
            this.Controls.Add(this.txtServerIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveServerIP);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SettingForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

		}


        #endregion

        private System.Windows.Forms.Button btnSaveServerIP;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtServerIP;
	}
}