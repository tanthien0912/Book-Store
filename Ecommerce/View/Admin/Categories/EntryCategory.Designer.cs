﻿namespace Ecommerce.View.Admin.Categories
{
    partial class EntryCategory
    {
        /// <summary>
        /// Biến thiết kế yêu cầu.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Dọn dẹp bất kỳ tài nguyên nào đang được sử dụng.
        /// </summary>
        /// <param name="disposing">true nếu tài nguyên quản lý nên được giải phóng; ngược lại, false.</param>
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
        /// Phương thức yêu cầu cho hỗ trợ thiết kế - không sửa đổi
        /// nội dung của phương thức này với trình chỉnh sửa mã.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryCategory));
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
            this.label1.Text = "Tên Danh Mục";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryName.Location = new System.Drawing.Point(171, 25);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(319, 24);
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
            this.btnCancelEC.Text = "Hủy";
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
            this.btnSaveEC.Text = "Lưu";
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EntryCategory";
            this.Text = "Nhập Danh Mục";
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