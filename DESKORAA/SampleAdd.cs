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
    public partial class SampleAdd : Form
    {
        public SampleAdd()
        {
            InitializeComponent();
        }

        public virtual void btnadd_Click(object sender, EventArgs e)
        {
            // Close the form - if embedded, it will be removed from parent
            this.Close();
            // If we're in frmMain, go back to frmUserView
            if (frmMain.Instance != null)
            {
                frmUserView userView = new frmUserView();
                frmMain.Instance.AddControls(userView);
            }
        }

        public virtual void btnclose_Click(object sender, EventArgs e)
        {
            // Close the form - if embedded, it will be removed from parent
            this.Close();
            // If we're in frmMain, go back to frmUserView
            if (frmMain.Instance != null)
            {
                frmUserView userView = new frmUserView();
                frmMain.Instance.AddControls(userView);
            }
        }
    }
}
