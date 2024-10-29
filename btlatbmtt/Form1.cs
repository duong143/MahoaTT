using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;

namespace btlatbmtt
{
    public partial class Form_giaodien : Form
    {
        private Home homeControl;
        private Lichsumahoa lichsumahoaControl;
        private Mahoapanel mahoaControl;

        public Form_giaodien()
        {
            InitializeComponent();
            UC_Dashboard uC_ = new UC_Dashboard();
            addUserControl(uC_);
            lichsumahoaControl = new Lichsumahoa();
            mahoaControl = new Mahoapanel();
            homeControl = new Home();
            addUserControl(homeControl);
            guna2Button1.Checked = true;
        }
        private void moveImageBox(object sender)
        {
            Guna2Button b = (Guna2Button)sender;
            img.Location = new Point(b.Location.X + 24, b.Location.Y - 25);
            img.SendToBack();
        }
        private void guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);

        }

      

        private void addUserControl(UserControl uc)
        {
            homepanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            homepanel.Controls.Add(uc);
         
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UC_Dashboard uC_ = new UC_Dashboard();
            addUserControl(uC_);
            addUserControl(homeControl);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            addUserControl(mahoaControl);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            addUserControl(lichsumahoaControl);
        }

        private void homepanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
