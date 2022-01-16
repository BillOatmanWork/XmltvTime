using System;
using System.Globalization;
using System.Windows.Forms;

namespace XmltvTime
{
    public partial class XmltvTime : Form
    {
        public XmltvTime()
        {
            InitializeComponent();

            btnDown.Text = char.ConvertFromUtf32(0x21D3);
            btnUp.Text = char.ConvertFromUtf32(0x21D1);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Human readable to XMLTV format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dtDate.Value;
            DateTime selectedTime = dtTime.Value;

            DateTime selected = selectedDate.Date + selectedTime.TimeOfDay;

            txtXmltv.Text = selected.ToUniversalTime().ToString("yyyyMMddHHmm00 +0000");
        }

        /// <summary>
        /// XMLTV format to human readable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime selected = DateTime.ParseExact(txtXmltv.Text, "yyyyMMddHHmmss K", CultureInfo.InvariantCulture);
                dtDate.Value = selected.ToLocalTime();
                dtTime.Value = selected.ToLocalTime();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtXmltv.Text);
        }
    }
}
