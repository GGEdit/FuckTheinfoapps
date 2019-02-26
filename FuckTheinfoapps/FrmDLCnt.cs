using System;
using System.Windows.Forms;

namespace FuckTheinfoapps
{
    public partial class FrmDLCnt : Form
    {
        public FrmDLCnt()
        {
            InitializeComponent();
        }

        private void postButton_Click(object sender, EventArgs e)
        {
            Theinfoapps theinfoapps = new Theinfoapps(cookie.Text, idfa.Text);
            if (incRadioButton.Checked)
            {
                theinfoapps.SyncDLCount(item_id.Text, optime.Text, "1", value.Text);
            }
            if (decRadioButton.Checked)
            {
                theinfoapps.SyncDLCount(item_id.Text, optime.Text, "2", value.Text);
            }
        }
    }
}