namespace Ecommerce.View.Admin.Products
{
    partial class EntryProduct
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtDescProduct = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSaveProduct = new System.Windows.Forms.Button();
            this.btnCancelProduct = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSelectPicture = new System.Windows.Forms.Button();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Stock";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Picture";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(176, 82);
            this.txtProductName.Multiline = true;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(400, 30);
            this.txtProductName.TabIndex = 5;
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(176, 130);
            this.txtStock.Multiline = true;
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(400, 30);
            this.txtStock.TabIndex = 6;
            this.txtStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStock_KeyPress);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(176, 187);
            this.txtPrice.Multiline = true;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(400, 30);
            this.txtPrice.TabIndex = 7;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // txtDescProduct
            // 
            this.txtDescProduct.Location = new System.Drawing.Point(176, 243);
            this.txtDescProduct.Multiline = true;
            this.txtDescProduct.Name = "txtDescProduct";
            this.txtDescProduct.Size = new System.Drawing.Size(400, 60);
            this.txtDescProduct.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(176, 331);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btnSaveProduct
            // 
            this.btnSaveProduct.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveProduct.Location = new System.Drawing.Point(485, 677);
            this.btnSaveProduct.Name = "btnSaveProduct";
            this.btnSaveProduct.Size = new System.Drawing.Size(122, 35);
            this.btnSaveProduct.TabIndex = 11;
            this.btnSaveProduct.Text = "Save";
            this.btnSaveProduct.UseVisualStyleBackColor = true;
            this.btnSaveProduct.Click += new System.EventHandler(this.btnSaveProduct_Click);
            // 
            // btnCancelProduct
            // 
            this.btnCancelProduct.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelProduct.Location = new System.Drawing.Point(613, 677);
            this.btnCancelProduct.Name = "btnCancelProduct";
            this.btnCancelProduct.Size = new System.Drawing.Size(122, 35);
            this.btnCancelProduct.TabIndex = 10;
            this.btnCancelProduct.Text = "Cancel";
            this.btnCancelProduct.UseVisualStyleBackColor = true;
            this.btnCancelProduct.Click += new System.EventHandler(this.btnCancelProduct_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "Category";
            // 
            // btnSelectPicture
            // 
            this.btnSelectPicture.Location = new System.Drawing.Point(176, 637);
            this.btnSelectPicture.Name = "btnSelectPicture";
            this.btnSelectPicture.Size = new System.Drawing.Size(86, 23);
            this.btnSelectPicture.TabIndex = 14;
            this.btnSelectPicture.Text = "Select Picture";
            this.btnSelectPicture.UseVisualStyleBackColor = true;
            this.btnSelectPicture.Click += new System.EventHandler(this.btnSelectPicture_Click);
            // 
            // cmbCategories
            // 
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(176, 32);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(400, 21);
            this.cmbCategories.TabIndex = 15;
            // 
            // EntryProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 724);
            this.Controls.Add(this.cmbCategories);
            this.Controls.Add(this.btnSelectPicture);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSaveProduct);
            this.Controls.Add(this.btnCancelProduct);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtDescProduct);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EntryProduct";
            this.Text = "EntryProduct";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EntryProduct_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtDescProduct;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSaveProduct;
        private System.Windows.Forms.Button btnCancelProduct;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSelectPicture;
        private System.Windows.Forms.ComboBox cmbCategories;
    }
}