namespace Ecommerce.View
{
    partial class DetailProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailProduct));
            this.txtDescProduct = new System.Windows.Forms.TextBox();
            this.btnBuy = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblNameProduct = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtStock = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Label();
            this.btnOutOfStock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescProduct
            // 
            this.txtDescProduct.BackColor = System.Drawing.SystemColors.Control;
            this.txtDescProduct.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescProduct.Location = new System.Drawing.Point(365, 143);
            this.txtDescProduct.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescProduct.Multiline = true;
            this.txtDescProduct.Name = "txtDescProduct";
            this.txtDescProduct.Size = new System.Drawing.Size(250, 142);
            this.txtDescProduct.TabIndex = 12;
            // 
            // btnBuy
            // 
            this.btnBuy.BackColor = System.Drawing.Color.Lavender;
            this.btnBuy.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuy.Location = new System.Drawing.Point(362, 308);
            this.btnBuy.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(250, 35);
            this.btnBuy.TabIndex = 11;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = false;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(362, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Description Product";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(359, 77);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(104, 25);
            this.lblPrice.TabIndex = 9;
            this.lblPrice.Text = "Price Product";
            // 
            // lblNameProduct
            // 
            this.lblNameProduct.AutoSize = true;
            this.lblNameProduct.Font = new System.Drawing.Font("Poppins", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameProduct.Location = new System.Drawing.Point(359, 35);
            this.lblNameProduct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNameProduct.Name = "lblNameProduct";
            this.lblNameProduct.Size = new System.Drawing.Size(152, 34);
            this.lblNameProduct.TabIndex = 8;
            this.lblNameProduct.Text = "Judul Product";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(25, 36);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // txtStock
            // 
            this.txtStock.AutoSize = true;
            this.txtStock.Font = new System.Drawing.Font("Poppins", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStock.Location = new System.Drawing.Point(361, 101);
            this.txtStock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(48, 19);
            this.txtStock.TabIndex = 13;
            this.txtStock.Text = "Stok Jir";
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = true;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Font = new System.Drawing.Font("Poppins", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(21, 9);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(51, 19);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "<- Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnOutOfStock
            // 
            this.btnOutOfStock.BackColor = System.Drawing.Color.Maroon;
            this.btnOutOfStock.Cursor = System.Windows.Forms.Cursors.No;
            this.btnOutOfStock.Enabled = false;
            this.btnOutOfStock.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOutOfStock.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOutOfStock.Location = new System.Drawing.Point(362, 308);
            this.btnOutOfStock.Margin = new System.Windows.Forms.Padding(2);
            this.btnOutOfStock.Name = "btnOutOfStock";
            this.btnOutOfStock.Size = new System.Drawing.Size(250, 35);
            this.btnOutOfStock.TabIndex = 15;
            this.btnOutOfStock.Text = "Out Of Stock";
            this.btnOutOfStock.UseVisualStyleBackColor = false;
            // 
            // DetailProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 366);
            this.Controls.Add(this.btnOutOfStock);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtDescProduct);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblNameProduct);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DetailProduct";
            this.Text = "DetailProduct";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DetailProduct_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescProduct;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblNameProduct;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txtStock;
        private System.Windows.Forms.Label btnBack;
        private System.Windows.Forms.Button btnOutOfStock;
    }
}