using Guna.UI2.WinForms;
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
    public partial class frmUserView : Form
    {
        public frmUserView()
        {
            InitializeComponent();
        }

        private void frmUserView_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            // Clear existing columns and rows
            guna2DataGridView1.Columns.Clear();
            guna2DataGridView1.Rows.Clear();

            // Add columns
            guna2DataGridView1.Columns.Add("Nom", "Nom");
            guna2DataGridView1.Columns.Add("Categorie", "Catégorie");
            guna2DataGridView1.Columns.Add("Description", "Description");
            guna2DataGridView1.Columns.Add("Prix", "Prix");
            guna2DataGridView1.Columns.Add("Stock", "Stock");
            guna2DataGridView1.Columns.Add("Rupture", "Rupture");

            // Add action buttons
            AddActionButtons();
        }

        public virtual void btnAdd_Click(object sender, EventArgs e)
        {
            // Add product functionality
        }

        public virtual void txtsearch_TextChanged(object sender, EventArgs e)
        {
            // Search functionality
        }

        private void AddActionButtons()
        {
            // MODIFIER button column
            var btnEdit = new DataGridViewButtonColumn();
            btnEdit.HeaderText = "Modifier";
            btnEdit.Text = "Modifier";
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.DefaultCellStyle.BackColor = Color.FromArgb(230, 220, 255);
            btnEdit.DefaultCellStyle.ForeColor = Color.FromArgb(60, 40, 120);
            btnEdit.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            guna2DataGridView1.Columns.Add(btnEdit);

            // SUPPRIMER button column
            var btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "Supprimer";
            btnDelete.Text = "Supprimer";
            btnDelete.UseColumnTextForButtonValue = true;
            btnDelete.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
            btnDelete.DefaultCellStyle.ForeColor = Color.Red;
            btnDelete.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            guna2DataGridView1.Columns.Add(btnDelete);
        }

        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Rupture")
            {
                if (e.Value != null && e.Value.ToString().ToUpper() == "YES")
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 200, 200);
                    e.CellStyle.ForeColor = Color.DarkRed;
                    e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(220, 255, 220);
                    e.CellStyle.ForeColor = Color.DarkGreen;
                    e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Handle button clicks
        }

        private void guna2DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            // Handle double-click
        }
    }
}
