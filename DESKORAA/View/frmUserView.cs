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

            // Set header colors - Nom is blue, others are purple
            // This will be done after all columns are added

            // Add action buttons
            AddActionButtons();
            
            // Set header colors - Nom is blue, others are purple
            foreach (DataGridViewColumn col in guna2DataGridView1.Columns)
            {
                if (col.Name == "Nom")
                {
                    col.HeaderCell.Style.BackColor = Color.FromArgb(59, 130, 246); // Blue
                    col.HeaderCell.Style.ForeColor = Color.White;
                }
                else
                {
                    col.HeaderCell.Style.BackColor = Color.FromArgb(139, 92, 246); // Purple
                    col.HeaderCell.Style.ForeColor = Color.White;
                }
            }
            
            // Add sample data for testing
            AddSampleData();
        }
        
        private void AddSampleData()
        {
            // Sample products
            AddProduct("Floral Dream Body Lotion", "Soins du corps", "Lotion parfumée aux extraits de fleurs blanches pour une sensation ...", 38.00m, 15);
            AddProduct("Tropical Mango Scrub", "Gommages", "Gommage fruité aux extraits de mangue, lisse et parfume la peau in...", 32.00m, 30);
            AddProduct("Golden Argan Oil", "Huiles", "Huile d'argan pure nourrissante pour peau et cheveux.", 40.00m, 20);
            AddProduct("Fresh Berry Shower Gel", "Nettoyants", "Gel douche parfumé aux fruits rouges, moussant et rafraîchissant.", 28.00m, 26);
            
            UpdateFooter();
        }
        
        private void AddProduct(string nom, string categorie, string description, decimal prix, int stock)
        {
            string rupture = stock < 10 ? "Yes" : "No";
            int rowIndex = guna2DataGridView1.Rows.Add(nom, categorie, description, prix.ToString("F2") + " dt", stock.ToString() + " unités", rupture);
        }
        
        private void UpdateFooter()
        {
            int totalProducts = guna2DataGridView1.Rows.Count;
            decimal totalValue = 0;
            
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.Cells["Prix"].Value != null)
                {
                    string prixStr = row.Cells["Prix"].Value.ToString().Replace(" dt", "").Trim();
                    decimal prix;
                    if (decimal.TryParse(prixStr, out prix))
                    {
                        totalValue += prix;
                    }
                }
            }
            
            // Update footer labels
            if (lblTotalProducts != null)
            {
                lblTotalProducts.Text = "Total: " + totalProducts + " produits";
            }
            
            if (lblTotalValue != null)
            {
                lblTotalValue.Text = "Valeur totale: " + totalValue.ToString("F2") + " dt";
            }
        }

        public virtual void btnAdd_Click(object sender, EventArgs e)
        {
            // Open SampleAdd form in the same page (within frmMain panel)
            SampleAdd sampleAdd = new SampleAdd();
            frmMain.Instance.AddControls(sampleAdd);
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
            if (e.RowIndex < 0) return;
            
            // Format Rupture column
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
            
            // Format Stock column - check if stock < 10 and update Rupture automatically
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Stock")
            {
                if (e.Value != null)
                {
                    string stockStr = e.Value.ToString().Replace(" unités", "").Trim();
                    int stock;
                    if (int.TryParse(stockStr, out stock))
                    {
                        // Update Rupture column based on stock
                        if (guna2DataGridView1.Columns["Rupture"] != null)
                        {
                            int ruptureColIndex = guna2DataGridView1.Columns["Rupture"].Index;
                            string ruptureValue = stock < 10 ? "Yes" : "No";
                            guna2DataGridView1.Rows[e.RowIndex].Cells[ruptureColIndex].Value = ruptureValue;
                        }
                    }
                }
                
                // Format Stock column with pill-shaped background
                e.CellStyle.BackColor = Color.FromArgb(240, 230, 255);
                e.CellStyle.ForeColor = Color.FromArgb(139, 92, 246);
                e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            }
            
            // Format Catégorie column with pill-shaped background
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Categorie")
            {
                e.CellStyle.BackColor = Color.FromArgb(240, 230, 255);
                e.CellStyle.ForeColor = Color.FromArgb(139, 92, 246);
                e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
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
