using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlishaCrockfordC968
{
    public partial class ModifyPart : Form
    {
        bool isInhouse;
        public ModifyPart(InHouse selectedPart)
        {
            InitializeComponent();

            textPartIDModify.ReadOnly = true;
            ModifyPartIDText = selectedPart.PartsID;
            ModifyPartNameText = selectedPart.Name;
            ModifyPartInventoryText = selectedPart.Inventory;
            ModifyPartPriceText = decimal.Parse(selectedPart.Price.ToString());
            ModifyPartMinText = selectedPart.Minimum;
            ModifyPartMaxText = selectedPart.Maximum;
            ModifyPartSourceText = selectedPart.MachineID.ToString();

            radioBtnInHouseModify.Checked = true;
        }

        public ModifyPart(Outsourced selectedOutPart)
        {
            InitializeComponent();

            textPartIDModify.ReadOnly = true;
            ModifyPartIDText = selectedOutPart.PartsID;
            ModifyPartNameText = selectedOutPart.Name;
            ModifyPartInventoryText = selectedOutPart.Inventory;
            ModifyPartPriceText = decimal.Parse(selectedOutPart.Price.ToString());
            ModifyPartMinText = selectedOutPart.Minimum;
            ModifyPartMaxText = selectedOutPart.Maximum;
            ModifyPartSourceText = selectedOutPart.CompanyName;

            radioBtnOutSourcedModify.Checked = true;
        }
        private bool allowSave()
        { 
            int number;
            double price;
            return ((!string.IsNullOrEmpty(textPartNameModify.Text)) &&
                    (!string.IsNullOrEmpty(textPartInventoryModify.Text)) &&
                    (int.TryParse(textPartInventoryModify.Text, out number)) &&
                    (!string.IsNullOrEmpty(textPartPriceModify.Text)) &&
                    (double.TryParse(textPartPriceModify.Text, out price)) &&
                    (!string.IsNullOrEmpty(textPartMinModify.Text)) &&
                    (int.TryParse(textPartMinModify.Text, out number)) &&
                    (!string.IsNullOrEmpty(textPartMaxModify.Text)) &&
                    (int.TryParse(textPartMaxModify.Text, out number)) &&
                    ((!isInhouse && !string.IsNullOrEmpty(textPartSourceModify.Text)) ||
                    (isInhouse && int.TryParse(textPartSourceModify.Text, out number)) &&
                    (isInhouse && !string.IsNullOrEmpty(textPartSourceModify.Text))));
        }

        private void checkOnRadioBtnSwitch()
        {
            int number;
            if (String.IsNullOrEmpty(textPartSourceModify.Text) || (isInhouse && !int.TryParse(textPartSourceModify.Text, out number)))
            {
                textPartSourceModify.BackColor = Color.Salmon;
            }
            else
            {
                textPartSourceModify.BackColor = Color.White;
            }
            btnModifyPartSave.Enabled = allowSave();
        }
        

        private void btnModifyPartCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainScreen mainScreen = new MainScreen();
            mainScreen.ShowDialog();
        }

        private void radioBtnInHouseModify_CheckedChanged(object sender, EventArgs e)
        {
            lblPartSourceModify.Text = "Machine ID";
            isInhouse = true;
            checkOnRadioBtnSwitch();
        }

        private void radioBtnOutSourcedModify_CheckedChanged(object sender, EventArgs e)
        {
            lblPartSourceModify.Text = "Company Name";
            isInhouse = false;
            checkOnRadioBtnSwitch();
        }

        private void textPartNameModify_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textPartNameModify.Text))
            {
                textPartNameModify.BackColor = Color.Salmon;
                btnModifyPartSave.Enabled = false;
            }
            else
            {
                textPartNameModify.BackColor = Color.White;
            }
            btnModifyPartSave.Enabled = allowSave();
        }

        private void textPartInventoryModify_TextChanged(object sender, EventArgs e)
        {
            int number;
            
            if (String.IsNullOrEmpty(textPartInventoryModify.Text))
            {
                textPartInventoryModify.BackColor = Color.Salmon;
                btnModifyPartSave.Enabled = false;
            }
            else if (!int.TryParse(textPartInventoryModify.Text, out number))
            {
                textPartInventoryModify.BackColor = Color.Salmon;
                MessageBox.Show("Inventory values can only contain numbers.");
                btnModifyPartSave.Enabled = false;
                return;
            }
            else
            {
                textPartInventoryModify.BackColor = Color.White;
            }
            btnModifyPartSave.Enabled = allowSave();
        }

        private void textPartPriceModify_TextChanged(object sender, EventArgs e)
        {
            double price;
            if (String.IsNullOrEmpty(textPartPriceModify.Text))
            {
                textPartPriceModify.BackColor = Color.Salmon;
                btnModifyPartSave.Enabled = false;
            }
            else if (!double.TryParse(textPartPriceModify.Text, out price))
            {
                textPartPriceModify.BackColor = Color.Salmon;
                MessageBox.Show("Price values can only contain numbers.");
                btnModifyPartSave.Enabled = false;
                return;
            }
            else
            {
                textPartPriceModify.BackColor = Color.White;
            }
            btnModifyPartSave.Enabled = allowSave();
        }

        private void textPartMinModify_TextChanged(object sender, EventArgs e)
        {
            int number;
            if (String.IsNullOrEmpty(textPartMinModify.Text))
            {
                textPartMinModify.BackColor = Color.Salmon;
                btnModifyPartSave.Enabled = false;
            }
            else if (!int.TryParse(textPartMinModify.Text, out number))
            {
                textPartMinModify.BackColor = Color.Salmon;
                MessageBox.Show("The minimum value must be a number.");
                btnModifyPartSave.Enabled = false;
                return;
            }
            else
            {
                textPartMinModify.BackColor = Color.White;
            }
            btnModifyPartSave.Enabled = allowSave();
        }

        private void textPartMaxModify_TextChanged(object sender, EventArgs e)
        {
            int number;
            if (String.IsNullOrEmpty(textPartMaxModify.Text))
            {
                textPartMaxModify.BackColor = Color.Salmon;
                btnModifyPartSave.Enabled = false;
            }
            else if (!int.TryParse(textPartMaxModify.Text, out number))
            {
                textPartMaxModify.BackColor = Color.Salmon;
                MessageBox.Show("The maximum value must be a number.");
                btnModifyPartSave.Enabled = false;
                return;
            }
            else
            {
                textPartMaxModify.BackColor = Color.White;
            }
            btnModifyPartSave.Enabled = allowSave();
        }

        private void textPartSourceModify_TextChanged(object sender, EventArgs e)
        {
            int number;
            if (string.IsNullOrEmpty(textPartSourceModify.Text))
            {
                textPartSourceModify.BackColor = Color.Salmon;
                btnModifyPartSave.Enabled = false;
            }
            else if (isInhouse && !int.TryParse(textPartSourceModify.Text, out number))
            {
                textPartSourceModify.BackColor = Color.Salmon;
                MessageBox.Show("The Machine ID must be a number.");
                btnModifyPartSave.Enabled = false;
                return;
            }
            else
            {
                textPartSourceModify.BackColor = Color.White;
            }
            checkOnRadioBtnSwitch();
        }

        private void btnModifyPartSave_Click(object sender, EventArgs e)
        {
            if (ModifyPartInventoryText < ModifyPartMinText)
            {
                MessageBox.Show("The inventory value must be greater than the minimum.");
                return;
            }

            if (ModifyPartInventoryText > ModifyPartMaxText)
            {
                MessageBox.Show("The inventory value must be less than the maximum.");
                return;
            }

            if (ModifyPartMinText > ModifyPartMaxText)
            {
                MessageBox.Show("The minimum value must be less than the maximum.");
                return;
            }

            if (radioBtnInHouseModify.Checked)
            {
                InHouse inhousePart = new InHouse
                   (ModifyPartIDText, ModifyPartNameText, ModifyPartInventoryText, (decimal)ModifyPartPriceText, ModifyPartMinText, ModifyPartMaxText, int.Parse(ModifyPartSourceText));
                Inventory.updatePart(ModifyPartIDText, inhousePart);
                radioBtnInHouseModify.Checked = true;
            }
            else
            {
                Outsourced outSourced = new Outsourced
                   (ModifyPartIDText, ModifyPartNameText, ModifyPartInventoryText, (decimal)ModifyPartPriceText, ModifyPartMinText, ModifyPartMaxText, ModifyPartSourceText);
                Inventory.updatePart(ModifyPartIDText, outSourced);
                radioBtnOutSourcedModify.Checked = true;
            }
            this.Hide();
            MainScreen mainScreen = new MainScreen();
            mainScreen.Show();
        }
    }
}
