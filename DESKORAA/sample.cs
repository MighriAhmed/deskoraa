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
    public partial class sample : Form
    {
        public sample()
        {
            InitializeComponent();
            guna2MessageDialog1.Parent=frmMain.Instance;
        }
    }
}
