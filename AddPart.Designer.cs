
namespace AlishaCrockfordC968
{
    partial class AddPart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAddPart = new System.Windows.Forms.Label();
            this.radioBtnInHouse = new System.Windows.Forms.RadioButton();
            this.radioBtnOutSourced = new System.Windows.Forms.RadioButton();
            this.lblPartID = new System.Windows.Forms.Label();
            this.lblPartName = new System.Windows.Forms.Label();
            this.lblPartInventory = new System.Windows.Forms.Label();
            this.lblPartPrice = new System.Windows.Forms.Label();
            this.lblPartMinimum = new System.Windows.Forms.Label();
            this.lblPartMaximum = new System.Windows.Forms.Label();
            this.lblPartSource = new System.Windows.Forms.Label();
            this.textPartID = new System.Windows.Forms.TextBox();
            this.textPartMax = new System.Windows.Forms.TextBox();
            this.textPartSource = new System.Windows.Forms.TextBox();
            this.textPartMin = new System.Windows.Forms.TextBox();
            this.textPartPrice = new System.Windows.Forms.TextBox();
            this.textPartInventory = new System.Windows.Forms.TextBox();
            this.textPartName = new System.Windows.Forms.TextBox();
            this.btnAddPartSave = new System.Windows.Forms.Button();
            this.btnAddPartCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAddPart
            // 
            this.lblAddPart.AutoSize = true;
            this.lblAddPart.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddPart.Location = new System.Drawing.Point(11, 12);
            this.lblAddPart.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddPart.Name = "lblAddPart";
            this.lblAddPart.Size = new System.Drawing.Size(93, 26);
            this.lblAddPart.TabIndex = 0;
            this.lblAddPart.Text = "Add Part";
            // 
            // radioBtnInHouse
            // 
            this.radioBtnInHouse.AutoSize = true;
            this.radioBtnInHouse.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnInHouse.Location = new System.Drawing.Point(190, 12);
            this.radioBtnInHouse.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radioBtnInHouse.Name = "radioBtnInHouse";
            this.radioBtnInHouse.Size = new System.Drawing.Size(91, 25);
            this.radioBtnInHouse.TabIndex = 1;
            this.radioBtnInHouse.TabStop = true;
            this.radioBtnInHouse.Text = "In-House";
            this.radioBtnInHouse.UseVisualStyleBackColor = true;
            this.radioBtnInHouse.CheckedChanged += new System.EventHandler(this.radioBtnInHouse_CheckedChanged);
            // 
            // radioBtnOutSourced
            // 
            this.radioBtnOutSourced.AutoSize = true;
            this.radioBtnOutSourced.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnOutSourced.Location = new System.Drawing.Point(342, 12);
            this.radioBtnOutSourced.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radioBtnOutSourced.Name = "radioBtnOutSourced";
            this.radioBtnOutSourced.Size = new System.Drawing.Size(109, 25);
            this.radioBtnOutSourced.TabIndex = 2;
            this.radioBtnOutSourced.TabStop = true;
            this.radioBtnOutSourced.Text = "Outsourced";
            this.radioBtnOutSourced.UseVisualStyleBackColor = true;
            this.radioBtnOutSourced.CheckedChanged += new System.EventHandler(this.radioBtnOutSourced_CheckedChanged);
            // 
            // lblPartID
            // 
            this.lblPartID.AutoSize = true;
            this.lblPartID.Location = new System.Drawing.Point(79, 66);
            this.lblPartID.Name = "lblPartID";
            this.lblPartID.Size = new System.Drawing.Size(25, 21);
            this.lblPartID.TabIndex = 3;
            this.lblPartID.Text = "ID";
            this.lblPartID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPartName
            // 
            this.lblPartName.AutoSize = true;
            this.lblPartName.Location = new System.Drawing.Point(79, 113);
            this.lblPartName.Name = "lblPartName";
            this.lblPartName.Size = new System.Drawing.Size(52, 21);
            this.lblPartName.TabIndex = 4;
            this.lblPartName.Text = "Name";
            this.lblPartName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPartInventory
            // 
            this.lblPartInventory.AutoSize = true;
            this.lblPartInventory.Location = new System.Drawing.Point(79, 164);
            this.lblPartInventory.Name = "lblPartInventory";
            this.lblPartInventory.Size = new System.Drawing.Size(76, 21);
            this.lblPartInventory.TabIndex = 5;
            this.lblPartInventory.Text = "Inventory";
            this.lblPartInventory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPartPrice
            // 
            this.lblPartPrice.AutoSize = true;
            this.lblPartPrice.Location = new System.Drawing.Point(79, 211);
            this.lblPartPrice.Name = "lblPartPrice";
            this.lblPartPrice.Size = new System.Drawing.Size(81, 21);
            this.lblPartPrice.TabIndex = 6;
            this.lblPartPrice.Text = "Price/Cost";
            this.lblPartPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPartMinimum
            // 
            this.lblPartMinimum.AutoSize = true;
            this.lblPartMinimum.Location = new System.Drawing.Point(79, 261);
            this.lblPartMinimum.Name = "lblPartMinimum";
            this.lblPartMinimum.Size = new System.Drawing.Size(78, 21);
            this.lblPartMinimum.TabIndex = 7;
            this.lblPartMinimum.Text = "Minimum";
            this.lblPartMinimum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPartMaximum
            // 
            this.lblPartMaximum.AutoSize = true;
            this.lblPartMaximum.Location = new System.Drawing.Point(338, 261);
            this.lblPartMaximum.Name = "lblPartMaximum";
            this.lblPartMaximum.Size = new System.Drawing.Size(80, 21);
            this.lblPartMaximum.TabIndex = 8;
            this.lblPartMaximum.Text = "Maximum";
            this.lblPartMaximum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPartSource
            // 
            this.lblPartSource.AutoSize = true;
            this.lblPartSource.Location = new System.Drawing.Point(79, 306);
            this.lblPartSource.Name = "lblPartSource";
            this.lblPartSource.Size = new System.Drawing.Size(88, 21);
            this.lblPartSource.TabIndex = 9;
            this.lblPartSource.Text = "Machine ID";
            this.lblPartSource.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textPartID
            // 
            this.textPartID.Location = new System.Drawing.Point(226, 66);
            this.textPartID.Name = "textPartID";
            this.textPartID.Size = new System.Drawing.Size(100, 28);
            this.textPartID.TabIndex = 10;
            // 
            // textPartMax
            // 
            this.textPartMax.Location = new System.Drawing.Point(424, 254);
            this.textPartMax.Name = "textPartMax";
            this.textPartMax.Size = new System.Drawing.Size(100, 28);
            this.textPartMax.TabIndex = 12;
            this.textPartMax.TextChanged += new System.EventHandler(this.textPartMax_TextChanged);
            // 
            // textPartSource
            // 
            this.textPartSource.Location = new System.Drawing.Point(226, 299);
            this.textPartSource.Name = "textPartSource";
            this.textPartSource.Size = new System.Drawing.Size(100, 28);
            this.textPartSource.TabIndex = 13;
            this.textPartSource.TextChanged += new System.EventHandler(this.textPartSource_TextChanged);
            // 
            // textPartMin
            // 
            this.textPartMin.Location = new System.Drawing.Point(226, 254);
            this.textPartMin.Name = "textPartMin";
            this.textPartMin.Size = new System.Drawing.Size(100, 28);
            this.textPartMin.TabIndex = 14;
            this.textPartMin.TextChanged += new System.EventHandler(this.textPartMin_TextChanged);
            // 
            // textPartPrice
            // 
            this.textPartPrice.Location = new System.Drawing.Point(226, 208);
            this.textPartPrice.Name = "textPartPrice";
            this.textPartPrice.Size = new System.Drawing.Size(100, 28);
            this.textPartPrice.TabIndex = 15;
            this.textPartPrice.TextChanged += new System.EventHandler(this.textPartPrice_TextChanged);
            // 
            // textPartInventory
            // 
            this.textPartInventory.Location = new System.Drawing.Point(226, 161);
            this.textPartInventory.Name = "textPartInventory";
            this.textPartInventory.Size = new System.Drawing.Size(100, 28);
            this.textPartInventory.TabIndex = 16;
            this.textPartInventory.TextChanged += new System.EventHandler(this.textPartInventory_TextChanged);
            // 
            // textPartName
            // 
            this.textPartName.Location = new System.Drawing.Point(226, 113);
            this.textPartName.Name = "textPartName";
            this.textPartName.Size = new System.Drawing.Size(100, 28);
            this.textPartName.TabIndex = 17;
            this.textPartName.TextChanged += new System.EventHandler(this.textPartName_TextChanged);
            // 
            // btnAddPartSave
            // 
            this.btnAddPartSave.Location = new System.Drawing.Point(411, 330);
            this.btnAddPartSave.Name = "btnAddPartSave";
            this.btnAddPartSave.Size = new System.Drawing.Size(72, 32);
            this.btnAddPartSave.TabIndex = 18;
            this.btnAddPartSave.Text = "Save";
            this.btnAddPartSave.UseVisualStyleBackColor = true;
            this.btnAddPartSave.Click += new System.EventHandler(this.btnAddPartSave_Click);
            // 
            // btnAddPartCancel
            // 
            this.btnAddPartCancel.Location = new System.Drawing.Point(513, 330);
            this.btnAddPartCancel.Name = "btnAddPartCancel";
            this.btnAddPartCancel.Size = new System.Drawing.Size(72, 32);
            this.btnAddPartCancel.TabIndex = 19;
            this.btnAddPartCancel.Text = "Cancel";
            this.btnAddPartCancel.UseVisualStyleBackColor = true;
            this.btnAddPartCancel.Click += new System.EventHandler(this.btnAddPartCancel_Click);
            // 
            // AddPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(634, 401);
            this.Controls.Add(this.btnAddPartCancel);
            this.Controls.Add(this.btnAddPartSave);
            this.Controls.Add(this.textPartName);
            this.Controls.Add(this.textPartInventory);
            this.Controls.Add(this.textPartPrice);
            this.Controls.Add(this.textPartMin);
            this.Controls.Add(this.textPartSource);
            this.Controls.Add(this.textPartMax);
            this.Controls.Add(this.textPartID);
            this.Controls.Add(this.lblPartSource);
            this.Controls.Add(this.lblPartMaximum);
            this.Controls.Add(this.lblPartMinimum);
            this.Controls.Add(this.lblPartPrice);
            this.Controls.Add(this.lblPartInventory);
            this.Controls.Add(this.lblPartName);
            this.Controls.Add(this.lblPartID);
            this.Controls.Add(this.radioBtnOutSourced);
            this.Controls.Add(this.radioBtnInHouse);
            this.Controls.Add(this.lblAddPart);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "AddPart";
            this.Text = "AddPart";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddPart;
        private System.Windows.Forms.RadioButton radioBtnInHouse;
        private System.Windows.Forms.RadioButton radioBtnOutSourced;
        private System.Windows.Forms.Label lblPartID;
        private System.Windows.Forms.Label lblPartName;
        private System.Windows.Forms.Label lblPartInventory;
        private System.Windows.Forms.Label lblPartPrice;
        private System.Windows.Forms.Label lblPartMinimum;
        private System.Windows.Forms.Label lblPartMaximum;
        private System.Windows.Forms.Label lblPartSource;
        private System.Windows.Forms.TextBox textPartID;
        private System.Windows.Forms.TextBox textPartMax;
        private System.Windows.Forms.TextBox textPartSource;
        private System.Windows.Forms.TextBox textPartMin;
        private System.Windows.Forms.TextBox textPartPrice;
        private System.Windows.Forms.TextBox textPartInventory;
        private System.Windows.Forms.TextBox textPartName;
        private System.Windows.Forms.Button btnAddPartSave;
        private System.Windows.Forms.Button btnAddPartCancel;

        public int AddPartIDText
        {
            get { return int.Parse(textPartID.Text); }
            set { textPartID.Text = value.ToString(); }
        }
        public string AddPartNameText
        {
            get { return textPartName.Text; }
            set { textPartName.Text = value; }
        }
        public int AddPartInventoryText
        {
            get { return int.Parse(textPartInventory.Text); }
            set { textPartInventory.Text = value.ToString(); }
        }
        public decimal AddPartPriceText
        {
            get { return decimal.Parse(textPartPrice.Text); }
            set { textPartPrice.Text = value.ToString(); }
        }
        public int AddPartMinText
        {
            get { return int.Parse(textPartMin.Text); }
            set { textPartMin.Text = value.ToString(); }
        }
        public int AddPartMaxText
        {
            get { return int.Parse(textPartMax.Text); }
            set { textPartMax.Text = value.ToString(); }
        }
        public string AddPartSourceText
        {
            get { return textPartSource.Text; }
            set { textPartSource.Text = value; }
        }
    }

   
}