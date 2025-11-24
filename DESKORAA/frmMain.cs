using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DESKORAA
{
    public partial class frmMain : Form
    {
        static frmMain _obj;
        public static frmMain Instance
        {
            get { if (_obj == null) { _obj = new frmMain(); } return _obj; }
        }
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _obj = this;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            
        }

        private void lbexit_Click(object sender, EventArgs e)
        {
            
        }
        public void AddControls(Form F)
        {
            this.CenterPanel.Controls.Clear();
            F.Dock = DockStyle.Fill;
            F.TopLevel = false;
            CenterPanel.Controls.Add(F);
            F.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
