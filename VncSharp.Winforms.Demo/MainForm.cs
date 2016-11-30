using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VncSharp.Winforms.Demo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            remoteDesktop.Connect(tbHost.Text,Convert.ToInt32(tbPort.Text));
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (remoteDesktop.IsConnected)
                remoteDesktop.Disconnect();
        }
    }
}
