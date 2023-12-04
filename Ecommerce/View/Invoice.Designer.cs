namespace Ecommerce.View
{
    partial class Invoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Invoice));
            this.label1 = new System.Windows.Forms.Label();
            this.txtDear = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOkInvoice = new System.Windows.Forms.Button();
            this.btnCancelInvoice = new System.Windows.Forms.Button();
            this.txtDuit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPaid = new System.Windows.Forms.Button();
            this.btnUnpaid = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(303, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "INVOICE";
            // 
            // txtDear
            // 
            this.txtDear.AutoSize = true;
            this.txtDear.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDear.Location = new System.Drawing.Point(33, 53);
            this.txtDear.Name = "txtDear";
            this.txtDear.Size = new System.Drawing.Size(47, 23);
            this.txtDear.TabIndex = 1;
            this.txtDear.Text = "Dear, ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Invoice Number";
            // 
            // txtDate
            // 
            this.txtDate.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Location = new System.Drawing.Point(160, 86);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(237, 24);
            this.txtDate.TabIndex = 4;
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNumber.Location = new System.Drawing.Point(160, 119);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.ReadOnly = true;
            this.txtInvoiceNumber.Size = new System.Drawing.Size(237, 24);
            this.txtInvoiceNumber.TabIndex = 5;
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(32, 166);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(617, 215);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 408);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "Payment";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 431);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(232, 23);
            this.label6.TabIndex = 8;
            this.label6.Text = "Name                         : Toko Serba Ada";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(32, 454);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(221, 23);
            this.label7.TabIndex = 9;
            this.label7.Text = "Account Number  : 462431240654";
            // 
            // btnOkInvoice
            // 
            this.btnOkInvoice.BackColor = System.Drawing.Color.Cornsilk;
            this.btnOkInvoice.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOkInvoice.Location = new System.Drawing.Point(399, 481);
            this.btnOkInvoice.Name = "btnOkInvoice";
            this.btnOkInvoice.Size = new System.Drawing.Size(122, 35);
            this.btnOkInvoice.TabIndex = 10;
            this.btnOkInvoice.Text = "Ok";
            this.btnOkInvoice.UseVisualStyleBackColor = false;
            this.btnOkInvoice.Click += new System.EventHandler(this.btnOkInvoice_Click);
            // 
            // btnCancelInvoice
            // 
            this.btnCancelInvoice.BackColor = System.Drawing.Color.Ivory;
            this.btnCancelInvoice.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelInvoice.Location = new System.Drawing.Point(527, 481);
            this.btnCancelInvoice.Name = "btnCancelInvoice";
            this.btnCancelInvoice.Size = new System.Drawing.Size(122, 35);
            this.btnCancelInvoice.TabIndex = 11;
            this.btnCancelInvoice.Text = "Cancel";
            this.btnCancelInvoice.UseVisualStyleBackColor = false;
            this.btnCancelInvoice.Click += new System.EventHandler(this.btnCancelInvoice_Click);
            // 
            // txtDuit
            // 
            this.txtDuit.BackColor = System.Drawing.SystemColors.Control;
            this.txtDuit.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuit.Location = new System.Drawing.Point(365, 444);
            this.txtDuit.Name = "txtDuit";
            this.txtDuit.Size = new System.Drawing.Size(284, 24);
            this.txtDuit.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(361, 418);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Masukin duit lu, ceritane payment gateway\r\n";
            // 
            // btnPaid
            // 
            this.btnPaid.BackColor = System.Drawing.Color.LightGreen;
            this.btnPaid.Enabled = false;
            this.btnPaid.FlatAppearance.BorderSize = 0;
            this.btnPaid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaid.Font = new System.Drawing.Font("Poppins Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaid.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPaid.Location = new System.Drawing.Point(527, 53);
            this.btnPaid.Name = "btnPaid";
            this.btnPaid.Size = new System.Drawing.Size(122, 35);
            this.btnPaid.TabIndex = 14;
            this.btnPaid.Text = "PAID";
            this.btnPaid.UseVisualStyleBackColor = false;
            // 
            // btnUnpaid
            // 
            this.btnUnpaid.BackColor = System.Drawing.Color.Yellow;
            this.btnUnpaid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUnpaid.Enabled = false;
            this.btnUnpaid.FlatAppearance.BorderSize = 0;
            this.btnUnpaid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnpaid.Font = new System.Drawing.Font("Poppins Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnpaid.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUnpaid.Location = new System.Drawing.Point(527, 53);
            this.btnUnpaid.Name = "btnUnpaid";
            this.btnUnpaid.Size = new System.Drawing.Size(122, 35);
            this.btnUnpaid.TabIndex = 15;
            this.btnUnpaid.Text = "UNPAID";
            this.btnUnpaid.UseVisualStyleBackColor = false;
            // 
            // Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(684, 528);
            this.Controls.Add(this.btnUnpaid);
            this.Controls.Add(this.btnPaid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDuit);
            this.Controls.Add(this.btnCancelInvoice);
            this.Controls.Add(this.btnOkInvoice);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.txtInvoiceNumber);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDear);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Invoice";
            this.Text = "Invoice";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Invoice_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtDear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtInvoiceNumber;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnOkInvoice;
        private System.Windows.Forms.Button btnCancelInvoice;
        private System.Windows.Forms.TextBox txtDuit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPaid;
        private System.Windows.Forms.Button btnUnpaid;
    }
}