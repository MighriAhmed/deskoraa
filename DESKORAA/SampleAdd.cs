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
            this.Close();
        }

        public virtual void btnclose_Click(object sender, EventArgs e)
        {

        }
    }
}
