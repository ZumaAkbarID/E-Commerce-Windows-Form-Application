namespace Ecommerce.View
{
    partial class Profile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profile));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.Label();
            this.txtRole = new System.Windows.Forms.Label();
            this.lvwProfile = new System.Windows.Forms.ListView();
            this.btnBack = new System.Windows.Forms.Label();
            this.pictureBoxLogout = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogout)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(97, 43);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(49, 23);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Phone";
            // 
            // txtPhone
            // 
            this.txtPhone.AutoSize = true;
            this.txtPhone.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(97, 66);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(50, 23);
            this.txtPhone.TabIndex = 3;
            this.txtPhone.Text = "Phone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Role";
            // 
            // txtAddress
            // 
            this.txtAddress.AutoSize = true;
            this.txtAddress.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(97, 89);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(64, 23);
            this.txtAddress.TabIndex = 6;
            this.txtAddress.Text = "Address";
            // 
            // txtRole
            // 
            this.txtRole.AutoSize = true;
            this.txtRole.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRole.Location = new System.Drawing.Point(97, 112);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(37, 23);
            this.txtRole.TabIndex = 7;
            this.txtRole.Text = "Role";
            // 
            // lvwProfile
            // 
            this.lvwProfile.HideSelection = false;
            this.lvwProfile.Location = new System.Drawing.Point(24, 205);
            this.lvwProfile.Name = "lvwProfile";
            this.lvwProfile.Size = new System.Drawing.Size(1034, 386);
            this.lvwProfile.TabIndex = 8;
            this.lvwProfile.UseCompatibleStateImageBehavior = false;
            this.lvwProfile.SelectedIndexChanged += new System.EventHandler(this.lvwProfile_SelectedIndexChanged);
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = true;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Font = new System.Drawing.Font("Poppins", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(20, 9);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(51, 19);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "<- Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pictureBoxLogout
            // 
            this.pictureBoxLogout.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogout.Image")));
            this.pictureBoxLogout.Location = new System.Drawing.Point(1038, 9);
            this.pictureBoxLogout.Name = "pictureBoxLogout";
            this.pictureBoxLogout.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogout.TabIndex = 184;
            this.pictureBoxLogout.TabStop = false;
            this.pictureBoxLogout.Click += new System.EventHandler(this.pictureBoxLogout_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 28);
            this.label5.TabIndex = 185;
            this.label5.Text = "History";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 28);
            this.label6.TabIndex = 186;
            this.label6.Text = "All Orders";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(983, 611);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 187;
            this.button1.Text = "Pay";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 646);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBoxLogout);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lvwProfile);
            this.Controls.Add(this.txtRole);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "Profile";
            this.Text = "Profile";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Profile_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtAddress;
        private System.Windows.Forms.Label txtRole;
        private System.Windows.Forms.ListView lvwProfile;
        private System.Windows.Forms.Label btnBack;
        private System.Windows.Forms.PictureBox pictureBoxLogout;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
    }
}