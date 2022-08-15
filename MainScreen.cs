using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlishaCrockfordC968
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }
        public void MainScreenFormLoad()
        {
            dataGridView1.DataSource = Inventory.AllParts;
            dataGridView2.DataSource = Inventory.Products;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
        }
        public void MainScreen_Load(object sender, EventArgs e)
        {
            MainScreenFormLoad();
        }

        //Exit Button
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Add Part button from Main Screen
        private void btnAddPart_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddPart addPart = new AddPart();
            addPart.ShowDialog();
        }

        //Modify Part button from Main Screen
        private void btnModifyPart_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.DataBoundItem.GetType() == typeof(AlishaCrockfordC968.InHouse))
            {
                InHouse selectedPart = (InHouse)dataGridView1.CurrentRow.DataBoundItem;
                this.Hide();
                ModifyPart modifyPart = new ModifyPart(selectedPart);
                modifyPart.Show();
            }
            else
            {
                Outsourced selectedOutPart = (Outsourced)dataGridView1.CurrentRow.DataBoundItem;
                this.Hide();
                ModifyPart modifyPart = new ModifyPart(selectedOutPart);
                modifyPart.Show();
            }

        }
        //Add Product button from Main Screen
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddProduct addProduct = new AddProduct();
            addProduct.ShowDialog();
        }

        //Modify Product button from Main Screen
        private void btnModifyProduct_Click(object sender, EventArgs e)
        {

            Product selectedProduct = (Product)dataGridView2.CurrentRow.DataBoundItem;
            this.Hide();
            ModifyProduct modifyProduct = new ModifyProduct(selectedProduct);
            modifyProduct.ShowDialog();

        }

        //Delete Part button from Main Screen
        private void btnDeletePart_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string message = "Would you like to delete this part?";
                string caption = "";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.Yes) 
                { 
                    dataGridView1.Rows.RemoveAt(row.Index);
                    MessageBox.Show("The selected part has been deleted.");
                }
                if (result == DialogResult.No)
                {
                    return;
                }
            }
        }

        //Delete Product button from Main Screen
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            Product product = (Product)dataGridView2.CurrentRow.DataBoundItem;
            if (product.AssociatedParts.Count > 0)
            {
                MessageBox.Show("A product with associated parts cannot be deleted.");
                return;
            }
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                string message = "Would you like to delete this product?";
                string caption = "";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.Yes)
                {
                    dataGridView2.Rows.RemoveAt(row.Index);
                    MessageBox.Show("A product has been deleted.");
                    return;
                }
                if (result == DialogResult.No)
                {
                    return;
                }
                
            }

        }

        //Search Part button from Main Screen
        private void btnSearchPart_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value.ToString().Contains(textSearchParts.Text))
                {
                    row.Selected = true;
                    return;
                }
                dataGridView1.ClearSelection();
            }
            if (dataGridView1.SelectedRows.Count == 0) 
            { 
                MessageBox.Show("There is no part that matches that part ID.");
                textSearchParts.Text = "";
            }
        }
        
        private void datagridview(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.ForestGreen;
        }

        private void datagridview2(object sender, EventArgs e)
        {
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.ForestGreen;
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[0].Value.ToString().Contains(textSearchProducts.Text))
                {
                    row.Selected = true;
                    return;
                }
                dataGridView2.ClearSelection();
            }
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("There is no product that matches that product ID.");
                textSearchProducts.Text = "";
            }
        }
    }
}
