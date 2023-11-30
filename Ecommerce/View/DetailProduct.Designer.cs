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
            this.txtDescProduct = new System.Windows.Forms.TextBox();
            this.btnBuy = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblNameProduct = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescProduct
            // 
            this.txtDescProduct.Location = new System.Drawing.Point(363, 112);
            this.txtDescProduct.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescProduct.Multiline = true;
            this.txtDescProduct.Name = "txtDescProduct";
            this.txtDescProduct.Size = new System.Drawing.Size(250, 142);
            this.txtDescProduct.TabIndex = 12;
            // 
            // btnBuy
            // 
            this.btnBuy.BackColor = System.Drawing.Color.MistyRose;
            this.btnBuy.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuy.Location = new System.Drawing.Point(363, 296);
            this.btnBuy.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(250, 35);
            this.btnBuy.TabIndex = 11;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(360, 92);
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
            this.lblPrice.Location = new System.Drawing.Point(360, 65);
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
            this.lblNameProduct.Location = new System.Drawing.Point(360, 23);
            this.lblNameProduct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNameProduct.Name = "lblNameProduct";
            this.lblNameProduct.Size = new System.Drawing.Size(152, 34);
            this.lblNameProduct.TabIndex = 8;
            this.lblNameProduct.Text = "Judul Product";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(26, 24);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // DetailProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 356);
            this.Controls.Add(this.txtDescProduct);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblNameProduct);
            this.Controls.Add(this.pictureBox1);
            this.Name = "DetailProduct";
            this.Text = "DetailProduct";
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
    }
}