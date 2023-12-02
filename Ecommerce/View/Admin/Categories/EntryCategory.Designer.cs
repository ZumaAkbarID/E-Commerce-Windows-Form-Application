namespace Ecommerce.View.Admin.Categories
{
    partial class EntryCategory
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
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.btnCancelEC = new System.Windows.Forms.Button();
            this.btnSaveEC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category Name";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(171, 25);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(319, 20);
            this.txtCategoryName.TabIndex = 1;
            // 
            // btnCancelEC
            // 
            this.btnCancelEC.BackColor = System.Drawing.Color.Ivory;
            this.btnCancelEC.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelEC.Location = new System.Drawing.Point(368, 94);
            this.btnCancelEC.Name = "btnCancelEC";
            this.btnCancelEC.Size = new System.Drawing.Size(122, 35);
            this.btnCancelEC.TabIndex = 8;
            this.btnCancelEC.Text = "Cancel";
            this.btnCancelEC.UseVisualStyleBackColor = false;
            this.btnCancelEC.Click += new System.EventHandler(this.btnCancelEC_Click);
            // 
            // btnSaveEC
            // 
            this.btnSaveEC.BackColor = System.Drawing.Color.Cornsilk;
            this.btnSaveEC.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveEC.Location = new System.Drawing.Point(240, 94);
            this.btnSaveEC.Name = "btnSaveEC";
            this.btnSaveEC.Size = new System.Drawing.Size(122, 35);
            this.btnSaveEC.TabIndex = 9;
            this.btnSaveEC.Text = "Save";
            this.btnSaveEC.UseVisualStyleBackColor = false;
            this.btnSaveEC.Click += new System.EventHandler(this.btnSaveEC_Click);
            // 
            // EntryCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 188);
            this.Controls.Add(this.btnSaveEC);
            this.Controls.Add(this.btnCancelEC);
            this.Controls.Add(this.txtCategoryName);
            this.Controls.Add(this.label1);
            this.Name = "EntryCategory";
            this.Text = "EntryCategory";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EntryCategory_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Button btnCancelEC;
        private System.Windows.Forms.Button btnSaveEC;
    }
}