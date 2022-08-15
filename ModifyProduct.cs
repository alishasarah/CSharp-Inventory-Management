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
    public partial class ModifyProduct : Form
    {
        public BindingSource partsBindingSource = new BindingSource();
        public BindingList<Part> associatedPartsBindingList = new BindingList<Part>();

        public ModifyProduct(Product selectedProduct)
        {
            InitializeComponent();
            ModifyProductScreenLoad(selectedProduct);

        }

        private bool allowSave()
        {
            int number;
            decimal price;
            return ((!string.IsNullOrEmpty(textModifyProductName.Text)) &&
                    (!string.IsNullOrEmpty(textModifyProductInventory.Text)) &&
                    (int.TryParse(textModifyProductInventory.Text, out number)) &&
                    (!string.IsNullOrEmpty(textModifyProductPrice.Text)) &&
                    (decimal.TryParse(textModifyProductPrice.Text, out price)) &&
                    (!string.IsNullOrEmpty(textModifyProductMin.Text)) &&
                    (int.TryParse(textModifyProductMin.Text, out number)) &&
                    (!string.IsNullOrEmpty(textModifyProductMax.Text)) &&
                    (int.TryParse(textModifyProductMax.Text, out number)));
        }
        public void ModifyProductScreenLoad(Product selectedProduct)
        {

            ModifyProductParts.DataSource = Inventory.AllParts;
            ModifyProductParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewModifyProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ModifyProductParts.RowHeadersVisible = false;
            dataGridViewModifyProduct.RowHeadersVisible = false;
            ModifyProductParts.AllowUserToAddRows = false;
            ModifyProductParts.ReadOnly = true;
            dataGridViewModifyProduct.ReadOnly = true;

            ModifyProductParts.Columns["PartsID"].HeaderText = "Part ID";
            ModifyProductParts.Columns["Name"].HeaderText = "Name";
            ModifyProductParts.Columns["Inventory"].HeaderText = "Inventory";
            ModifyProductParts.Columns["Price"].HeaderText = "Price";
            ModifyProductParts.Columns["Minimum"].HeaderText = "Minimum";
            ModifyProductParts.Columns["Maximum"].HeaderText = "Maximum";

            dataGridViewModifyProduct.DataSource = associatedPartsBindingList;
            dataGridViewModifyProduct.Columns["PartsID"].HeaderText = "Part ID";
            dataGridViewModifyProduct.Columns["Name"].HeaderText = "Name";
            dataGridViewModifyProduct.Columns["Inventory"].HeaderText = "Inventory";
            dataGridViewModifyProduct.Columns["Price"].HeaderText = "Price";
            dataGridViewModifyProduct.Columns["Minimum"].HeaderText = "Minimum";
            dataGridViewModifyProduct.Columns["Maximum"].HeaderText = "Maximum";

            textModifyProductID.ReadOnly = true;
            ModifyProductIDText = selectedProduct.ProductID;
            ModifyProductNameText = selectedProduct.Name;
            ModifyProductInventoryText = selectedProduct.Inventory;
            ModifyProductPriceText = decimal.Parse(selectedProduct.Price.ToString());
            ModifyProductMinText = selectedProduct.Minimum;
            ModifyProductMaxText = selectedProduct.Maximum;

            foreach (Part part in selectedProduct.AssociatedParts)
            {
                associatedPartsBindingList.Add(part);
            }
        }
        private void btnModifyProductCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainScreen mainScreen = new MainScreen();
            mainScreen.ShowDialog();
        }
        private void btnModifyProductDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewModifyProduct.SelectedRows)
            {
                Part currentPart = (Part)dataGridViewModifyProduct.CurrentRow.DataBoundItem;

                int lookupID = this.ModifyProductIDText;
                Product currentProduct = Inventory.LookupProduct(lookupID);

                string message = "Would you like to delete this part?";
                string caption = "";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.Yes)
                {
                    currentProduct.RemoveAssociatedPart(currentPart.PartsID);
                    dataGridViewModifyProduct.Rows.RemoveAt(row.Index);
                    MessageBox.Show("A part has been deleted from this product.");
                    return;
                }
                if (result == DialogResult.No)
                {
                    return;
                }
                
            }
        }
        private void btnAddModifyProduct_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = ModifyProductParts.SelectedRows[0];
            var idVal = selectedRow.Cells["PartsID"].Value;
            int partID = Convert.ToInt32(selectedRow.Cells["PartsID"].Value);
            Part part = Inventory.LookupPart(partID);
            
            associatedPartsBindingList.Add(part);
        }
        private void btnModifyProductSave_Click(object sender, EventArgs e)
        {
            if (ModifyProductInventoryText < ModifyProductMinText)
            {
                MessageBox.Show("The inventory value must be greater than the minimum.");
                return;
            }

            if (ModifyProductInventoryText > ModifyProductMaxText)
            {
                MessageBox.Show("The inventory value must be less than the maximum.");
                return;
            }

            if (ModifyProductMinText > ModifyProductMaxText)
            {
                MessageBox.Show("The minimum value must be less than the maximum.");
                return;
            }

            Product updatedProduct = new Product(ModifyProductIDText, ModifyProductNameText, ModifyProductInventoryText, (decimal)ModifyProductPriceText, ModifyProductMinText, ModifyProductMaxText);
            foreach (Part part in associatedPartsBindingList)
            {
                updatedProduct.AddAssociatedPart(part);
            }
            Inventory.UpdatedProduct(ModifyProductIDText, updatedProduct);
            this.Close();
            MainScreen mainScreen = new MainScreen();
            mainScreen.Show();
        }

        private void btnSearchModifyProduct_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in ModifyProductParts.Rows)
            {
                if (row.Cells["PartsID"].Value.ToString().Contains(textSearchModifyProduct.Text))
                {
                    row.Selected = true;
                    return;
                }

                ModifyProductParts.ClearSelection();
            }
            if (ModifyProductParts.SelectedRows.Count != 1)
            {
                MessageBox.Show("There is no part that matches that part ID.");
                textSearchModifyProduct.Text = "";
            }
        }

        private void textModifyProductName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textModifyProductName.Text))
            {
                textModifyProductName.BackColor = Color.Salmon;
            }
            else
            {
                textModifyProductName.BackColor = Color.White;
                btnModifyProductSave.Enabled = allowSave();
            }
        }

        private void textModifyProductInventory_TextChanged(object sender, EventArgs e)
        {
            int number;

            if (String.IsNullOrEmpty(textModifyProductInventory.Text))
            {
                textModifyProductInventory.BackColor = Color.Salmon;
                btnModifyProductSave.Enabled = false;
            }
            else if (!int.TryParse(textModifyProductInventory.Text, out number))
            {
                textModifyProductInventory.BackColor = Color.Salmon;
                MessageBox.Show("Inventory values can only contain numbers.");
                btnModifyProductSave.Enabled = false;
                return;
            }
            else
            {
                textModifyProductInventory.BackColor = Color.White;
            }
            btnModifyProductSave.Enabled = allowSave();
        }

        private void textModifyProductPrice_TextChanged(object sender, EventArgs e)
        {
            double price;
            if (String.IsNullOrEmpty(textModifyProductPrice.Text))
            {
                textModifyProductPrice.BackColor = Color.Salmon;
                btnModifyProductSave.Enabled = false;
            }
            else if (!double.TryParse(textModifyProductPrice.Text, out price))
            {
                textModifyProductPrice.BackColor = Color.Salmon;
                MessageBox.Show("Price values can only contain numbers.");
                btnModifyProductSave.Enabled = false;
                return;
            }
            else
            {
                textModifyProductPrice.BackColor = Color.White;
            }
            btnModifyProductSave.Enabled = allowSave();
        }

        private void textModifyProductMin_TextChanged(object sender, EventArgs e)
        {
            int number;
            if (String.IsNullOrEmpty(textModifyProductMin.Text))
            {
                textModifyProductMin.BackColor = Color.Salmon;
                btnModifyProductSave.Enabled = false;
            }
            else if (!int.TryParse(textModifyProductMin.Text, out number))
            {
                textModifyProductMin.BackColor = Color.Salmon;
                MessageBox.Show("Minimum values can only contain numbers.");
                btnModifyProductSave.Enabled = false;
                return;
            }
            else
            {
                textModifyProductMin.BackColor = Color.White;
            }
            btnModifyProductSave.Enabled = allowSave();
        }

        private void textModifyProductMax_TextChanged(object sender, EventArgs e)
        {
            int number;
            if (String.IsNullOrEmpty(textModifyProductMax.Text))
            {
                textModifyProductMax.BackColor = Color.Salmon;
                btnModifyProductSave.Enabled = false;
            }
            else if (!int.TryParse(textModifyProductMax.Text, out number))
            {
                textModifyProductMax.BackColor = Color.Salmon;
                MessageBox.Show("Maximum values can only contain numbers.");
                btnModifyProductSave.Enabled = false;
                return;
            }
            else
            {
                textModifyProductMax.BackColor = Color.White;
            }
            btnModifyProductSave.Enabled = allowSave();
        }
    }
}
