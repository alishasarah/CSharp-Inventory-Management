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
    public partial class AddProduct : Form
    {
        public BindingSource partsBindingSource = new BindingSource();
        public BindingList<Part> associatedPartsBindingList = new BindingList<Part>();
        public AddProduct()
        {
            InitializeComponent();
        }
        private bool allowSave()
        {
            int number;
            double price;
            return ((!string.IsNullOrEmpty(textAddProductName.Text)) &&
                    (!string.IsNullOrEmpty(textAddProductInventory.Text)) &&
                    (int.TryParse(textAddProductInventory.Text, out number)) &&
                    (!string.IsNullOrEmpty(textAddProductPrice.Text)) &&
                    (double.TryParse(textAddProductPrice.Text, out price)) &&
                    (!string.IsNullOrEmpty(textAddProductMin.Text)) &&
                    (int.TryParse(textAddProductMin.Text, out number)) &&
                    (!string.IsNullOrEmpty(textAddProductMax.Text)) &&
                    (int.TryParse(textAddProductMax.Text, out number)));
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            AddProductParts.DataSource = Inventory.AllParts;
            AddProductParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAddProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AddProductParts.RowHeadersVisible = false;
            dataGridViewAddProduct.RowHeadersVisible = false;
            AddProductParts.AllowUserToAddRows = false;
            AddProductParts.ReadOnly = true;
            dataGridViewAddProduct.ReadOnly = true;
            btnAddProductSave.Enabled = false;

            AddProductParts.Columns["PartsID"].HeaderText = "Part ID";
            AddProductParts.Columns["Name"].HeaderText = "Name";
            AddProductParts.Columns["Inventory"].HeaderText = "Inventory";
            AddProductParts.Columns["Price"].HeaderText = "Price";
            AddProductParts.Columns["Minimum"].HeaderText = "Minimum";
            AddProductParts.Columns["Maximum"].HeaderText = "Maximum";

            dataGridViewAddProduct.DataSource = associatedPartsBindingList;
            dataGridViewAddProduct.Columns["PartsID"].HeaderText = "Part ID";
            dataGridViewAddProduct.Columns["Name"].HeaderText = "Name";
            dataGridViewAddProduct.Columns["Inventory"].HeaderText = "Inventory";
            dataGridViewAddProduct.Columns["Price"].HeaderText = "Price";
            dataGridViewAddProduct.Columns["Minimum"].HeaderText = "Minimum";
            dataGridViewAddProduct.Columns["Maximum"].HeaderText = "Maximum";

            textAddProductID.ReadOnly = true;
            textAddProductID.Text = (Inventory.Products.Count + 4).ToString();
        }
        //cancel click
        private void btnAddProductCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainScreen mainScreen = new MainScreen();
            mainScreen.ShowDialog();
        }
        //delete click
        private void btnAddProductDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewAddProduct.SelectedRows)
            {
                string message = "Would you like to delete this part?";
                string caption = "";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.Yes)
                {
                    dataGridViewAddProduct.Rows.RemoveAt(row.Index);
                    MessageBox.Show("The selected part has been deleted.");
                }
                if (result == DialogResult.No)
                {
                    return;
                }
            }
        }

        private void btnAddAddProduct_Click(object sender, EventArgs e)
        {

            DataGridViewRow selectedRow = AddProductParts.SelectedRows[0];
            //var idValue = selectedRow.Cells["PartsID"].Value;

            int partID = Convert.ToInt32(selectedRow.Cells["PartsID"].Value);
            Part part = Inventory.LookupPart(partID);

            associatedPartsBindingList.Add(part);

        }

        private void btnAddProductSave_Click(object sender, EventArgs e)
        {
            if (AddProductInventoryText < AddProductMinText)
            {
                MessageBox.Show("The inventory value must be greater than the minimum.");
                return;
            }

            if (AddProductInventoryText > AddProductMaxText)
            {
                MessageBox.Show("The inventory value must be less than the maximum.");
                return;
            }

            if (AddProductMinText > AddProductMaxText)
            {
                MessageBox.Show("The minimum value must be less than the maximum.");
                return;
            }
            Product addProduct = new Product((Inventory.Products.Count + 4), AddProductNameText, AddProductInventoryText, (decimal)AddProductPriceText, AddProductMinText, AddProductMaxText);
            foreach (Part part in associatedPartsBindingList)
            {
                addProduct.AddAssociatedPart(part);
            }
            Inventory.Products.Add(addProduct);

            this.Hide();
            MainScreen mainScreen = new MainScreen();
            mainScreen.ShowDialog();
        }

        private void btnSearchAddProduct_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in AddProductParts.Rows)
            {
                if (row.Cells["PartsID"].Value.ToString().Contains(textSearchAddProduct.Text))
                {
                    row.Selected = true;
                    return;
                }

                AddProductParts.ClearSelection();
            }
                if (AddProductParts.SelectedRows.Count != 1)
                {
                    MessageBox.Show("There is no part that matches that part ID.");
                    textSearchAddProduct.Text = "";
                }
        }

        private void textAddProductName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textAddProductName.Text))
            {
                textAddProductName.BackColor = Color.Salmon;
                btnAddProductSave.Enabled = false;
            }
            else
            {
                textAddProductName.BackColor = Color.White;
            }
            btnAddProductSave.Enabled = allowSave();
        }

        private void textAddProductInventory_TextChanged(object sender, EventArgs e)
        {
            int number;

            if (String.IsNullOrEmpty(textAddProductInventory.Text))
            {
                textAddProductInventory.BackColor = Color.Salmon;
                btnAddProductSave.Enabled = false;
            }
            else if (!int.TryParse(textAddProductInventory.Text, out number))
            {
                textAddProductInventory.BackColor = Color.Salmon;
                MessageBox.Show("Inventory values can only contain numbers.");
                btnAddProductSave.Enabled = false;
                return;
            }
            else
            {
                textAddProductInventory.BackColor = Color.White;
            }
            btnAddProductSave.Enabled = allowSave();
        }

        private void textAddProductPrice_TextChanged(object sender, EventArgs e)
        {
            double price;
            if (String.IsNullOrEmpty(textAddProductPrice.Text))
            {
                textAddProductPrice.BackColor = Color.Salmon;
                btnAddProductSave.Enabled = false;
            }
            else if (!double.TryParse(textAddProductPrice.Text, out price))
            {
                textAddProductPrice.BackColor = Color.Salmon;
                MessageBox.Show("Price values can only contain numbers.");
                btnAddProductSave.Enabled = false;
                return;
            }
            else
            {
                textAddProductPrice.BackColor = Color.White;
            }
            btnAddProductSave.Enabled = allowSave();
        }

        private void textAddProductMin_TextChanged(object sender, EventArgs e)
        {
            int number;
            if (String.IsNullOrEmpty(textAddProductMin.Text))
            {
                textAddProductMin.BackColor = Color.Salmon;
                btnAddProductSave.Enabled = false;
            }
            else if (!int.TryParse(textAddProductMin.Text, out number))
            {
                textAddProductMin.BackColor = Color.Salmon;
                MessageBox.Show("Minimum values can only contain numbers.");
                btnAddProductSave.Enabled = false;
                return;
            }
            else
            {
                textAddProductMin.BackColor = Color.White;
            }
            btnAddProductSave.Enabled = allowSave();
        }

        private void textAddProductMax_TextChanged(object sender, EventArgs e)
        {
            int number;
            if (String.IsNullOrEmpty(textAddProductMax.Text))
            {
                textAddProductMax.BackColor = Color.Salmon;
                btnAddProductSave.Enabled = false;
            }
            else if (!int.TryParse(textAddProductMax.Text, out number))
            {
                textAddProductMax.BackColor = Color.Salmon;
                MessageBox.Show("Maximum values can only contain numbers.");
                btnAddProductSave.Enabled = false;
                return;
            }
            else
            {
                textAddProductMax.BackColor = Color.White;
            }
            btnAddProductSave.Enabled = allowSave();
        }
    }
}
        

