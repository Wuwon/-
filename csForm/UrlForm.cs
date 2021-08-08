using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_Solution.csForm
{
    public partial class UrlForm : Form
    {

        public UrlForm()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            MainForm.loadUrl(URL_textBox.Text.ToString());
            this.Close();
        }

        private void URL_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.LoadBtn_Click(sender, e);
            }
        }

        private void UrlForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void UrlForm_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape)
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.F4)
            {
                this.Close();
            }
        }


    }
}
