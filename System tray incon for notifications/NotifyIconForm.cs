using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace System_tray_icon_for_notifications
{
    public partial class NotifyIconForm : Form
    {
        public NotifyIconForm()
        {
            InitializeComponent();
        }


        public void AstridIstDa_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
