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
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Mainclass.IsValidAdmins(nomutilis.Text, motpasse.Text) == false)
            {
                guna2MessageDialog1.Show("nom d'utilisateur ou mot de passe incorrect");
                return;
            }
            else
            {
                this.Hide();
                frmMain frm = new frmMain();
                frm.Show();
            }
        }
    }
}
