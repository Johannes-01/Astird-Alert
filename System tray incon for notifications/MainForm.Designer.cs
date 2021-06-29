
namespace AstridAlert
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.astridNotifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.shiftF3ToActivateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIconContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyIconContextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Notifications";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.NotifyIcon_Click);
            // 
            // notifyIconContextMenuStrip
            // 
            this.notifyIconContextMenuStrip.AccessibleName = "notifyIconContextMenuStrip";
            this.notifyIconContextMenuStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.notifyIconContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.notifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.astridNotifierToolStripMenuItem,
            this.toolStripSeparator1,
            this.shiftF3ToActivateToolStripMenuItem,
            this.toolStripMenuSettings,
            this.toolStripSeparator2,
            this.toolStripMenuItemExit});
            this.notifyIconContextMenuStrip.Name = "notifyIconContextMenuStrip";
            this.notifyIconContextMenuStrip.Size = new System.Drawing.Size(360, 136);
            // 
            // astridNotifierToolStripMenuItem
            // 
            this.astridNotifierToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("astridNotifierToolStripMenuItem.Image")));
            this.astridNotifierToolStripMenuItem.Name = "astridNotifierToolStripMenuItem";
            this.astridNotifierToolStripMenuItem.Size = new System.Drawing.Size(359, 30);
            this.astridNotifierToolStripMenuItem.Text = "Astrid Notifier";
            this.astridNotifierToolStripMenuItem.Click += new System.EventHandler(this.astridNotifierToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(356, 6);
            // 
            // shiftF3ToActivateToolStripMenuItem
            // 
            this.shiftF3ToActivateToolStripMenuItem.Name = "shiftF3ToActivateToolStripMenuItem";
            this.shiftF3ToActivateToolStripMenuItem.Size = new System.Drawing.Size(359, 30);
            this.shiftF3ToActivateToolStripMenuItem.Text = "Activate                                       Shift + F3";
            this.shiftF3ToActivateToolStripMenuItem.Click += new System.EventHandler(this.shiftF3ToActivateToolStripMenuItem_Click);
            // 
            // toolStripMenuSettings
            // 
            this.toolStripMenuSettings.Name = "toolStripMenuSettings";
            this.toolStripMenuSettings.Size = new System.Drawing.Size(359, 30);
            this.toolStripMenuSettings.Text = "Einstellungen";
            this.toolStripMenuSettings.Click += new System.EventHandler(this.astridNotifierSettings_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(356, 6);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.AccessibleName = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(359, 30);
            this.toolStripMenuItemExit.Text = "Exit";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 360);
            this.ControlBox = false;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.notifyIconContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyIconContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem astridNotifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shiftF3ToActivateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuSettings;
	}
}

