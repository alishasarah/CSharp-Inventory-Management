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
    public partial class AddPart : Form
    {
        bool isInhouse;
        public AddPart()
        {
            InitializeComponent();
            textPartID.ReadOnly = true;
            textPartID.Text = (Inventory.AllParts.Count + 7).ToString();
        }
        private bool allowSave()
        {
            int number;
            decimal price;
            return ((!string.IsNullOrEmpty(textPartName.Text)) &&
                    (!string.IsNullOrEmpty(textPartInventory.Text)) &&
                    (int.TryParse(textPartInventory.Text, out number)) &&
                    (!string.IsNullOrEmpty(textPartPrice.Text)) &&
                    (decimal.TryParse(textPartPrice.Text, out price)) &&
                    (!string.IsNullOrEmpty(textPartMin.Text)) &&
                    (int.TryParse(textPartMin.Text, out number)) &&
                    (!string.IsNullOrEmpty(textPartMax.Text)) &&
                    (int.TryParse(textPartMax.Text, out number)) &&
                    ((!string.IsNullOrEmpty(textPartSource.Text)) ||
                    (isInhouse && int.TryParse(textPartSource.Text, out number))));
        }

        private void checkOnRadioBtnSwitch()
        {
            int number;
            if (string.IsNullOrEmpty(textPartSource.Text) || (isInhouse && !int.TryParse(textPartSource.Text, out number)))
            {
                textPartSource.BackColor = Color.Salmon;
            }
            else
            {
                textPartSource.BackColor = Color.White;
            }
            btnAddPartSave.Enabled = allowSave();
        }
        private void btnAddPartCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainScreen mainScreen = new MainScreen();
            mainScreen.ShowDialog();
        }
        private void radioBtnInHouse_CheckedChanged(object sender, EventArgs e)
        {
            lblPartSource.Text = "Machine ID";
            isInhouse = true;
            checkOnRadioBtnSwitch();
        }
        private void radioBtnOutSourced_CheckedChanged(object sender, EventArgs e)
        {
            lblPartSource.Text = "Company Name";
            isInhouse = false;
            checkOnRadioBtnSwitch();
        }
        private void btnAddPartSave_Click(object sender, EventArgs e)
        {
            if (AddPartInventoryText < AddPartMinText)
            {
                MessageBox.Show("The inventory value must be greater than the minimum.");
                return;
            }

            if (AddPartInventoryText > AddPartMaxText)
            {
                MessageBox.Show("The inventory value must be less than the maximum.");
                return;
            }

            if (AddPartMinText > AddPartMaxText)
            {
                MessageBox.Show("The minimum value must be less than the maximum.");
                return;
            }
            if (radioBtnInHouse.Checked) 
            {
                InHouse inHouse = new InHouse((Inventory.AllParts.Count + 7), AddPartNameText, AddPartInventoryText, (decimal)AddPartPriceText, AddPartMinText, AddPartMaxText, int.Parse(AddPartSourceText));
                Inventory.AllParts.Add(inHouse);
                radioBtnInHouse.Checked = true;
            }
            else
            {
                Outsourced outSourced = new Outsourced((Inventory.AllParts.Count + 7), AddPartNameText, AddPartInventoryText, (decimal)AddPartPriceText, AddPartMinText, AddPartMaxText, AddPartSourceText);
                Inventory.AllParts.Add(outSourced);
                radioBtnOutSourced.Checked = true;
            }
            this.Hide();
            MainScreen mainScreen = new MainScreen();
            mainScreen.Show();
        }

        private void textPartName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textPartName.Text))
            {
                textPartName.BackColor = Color.Salmon;
                btnAddPartSave.Enabled = false;
            }
            else
            {
                textPartName.BackColor = Color.White;
            }
            btnAddPartSave.Enabled = allowSave();
        }

        private void textPartInventory_TextChanged(object sender, EventArgs e)
        {
            int number;

            if (String.IsNullOrEmpty(textPartInventory.Text))
            {
                textPartInventory.BackColor = Color.Salmon;
                btnAddPartSave.Enabled = false;
            }
            else if (!int.TryParse(textPartInventory.Text, out number))
            {
                textPartInventory.BackColor = Color.Salmon;
                MessageBox.Show("Inventory values can only contain numbers.");
                btnAddPartSave.Enabled = false;
                return;
            }
            else
            {
                textPartInventory.BackColor = Color.White;
            }
            btnAddPartSave.Enabled = allowSave();
        }

        private void textPartPrice_TextChanged(object sender, EventArgs e)
        {
            double price;
            if (String.IsNullOrEmpty(textPartPrice.Text))
            {
                textPartPrice.BackColor = Color.Salmon;
                btnAddPartSave.Enabled = false;
            }
            else if (!double.TryParse(textPartPrice.Text, out price))
            {
                textPartPrice.BackColor = Color.Salmon;
                MessageBox.Show("Price values can only contain numbers.");
                btnAddPartSave.Enabled = false;
                return;
            }
            else
            {
                textPartPrice.BackColor = Color.White;
            }
            btnAddPartSave.Enabled = allowSave();
        }

        private void textPartMin_TextChanged(object sender, EventArgs e)
        {
            int number;
            if (String.IsNullOrEmpty(textPartMin.Text))
            {
                textPartMin.BackColor = Color.Salmon;
                btnAddPartSave.Enabled = false;
            }
            else if (!int.TryParse(textPartMin.Text, out number))
            {
                textPartMin.BackColor = Color.Salmon;
                MessageBox.Show("Minimum values can only contain numbers.");
                btnAddPartSave.Enabled = false;
                return;
            }
            else
            {
                textPartMin.BackColor = Color.White;
            }
            btnAddPartSave.Enabled = allowSave();
        }

        private void textPartMax_TextChanged(object sender, EventArgs e)
        {
            int number;
            if (String.IsNullOrEmpty(textPartMax.Text))
            {
                textPartMax.BackColor = Color.Salmon;
                btnAddPartSave.Enabled = false;
            }
            else if (!int.TryParse(textPartMax.Text, out number))
            {
                textPartMax.BackColor = Color.Salmon;
                MessageBox.Show("Maximum values can only contain numbers.");
                btnAddPartSave.Enabled = false;
                return;
            }
            else
            {
                textPartMax.BackColor = Color.White;
            }
            btnAddPartSave.Enabled = allowSave();
        }

        private void textPartSource_TextChanged(object sender, EventArgs e)
        {
            int number;
            if (string.IsNullOrEmpty(textPartSource.Text)) 
            {
                textPartSource.BackColor = Color.Salmon;
                btnAddPartSave.Enabled = false;
            }
            else if (isInhouse && !int.TryParse(textPartSource.Text, out number))
            {
                textPartSource.BackColor = Color.Salmon;
                MessageBox.Show("Machine ID values can only contain numbers.");
                btnAddPartSave.Enabled = false;
                return;
            }
            else
            {
                textPartSource.BackColor = Color.White;
            }
            checkOnRadioBtnSwitch();
        }
    }
}
