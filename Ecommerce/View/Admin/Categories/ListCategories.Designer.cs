﻿namespace Ecommerce.View.Admin.Categories
{
    partial class ListCategories
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

        #region Mã được tạo bởi trình thiết kế Windows Form

        /// <summary>
        /// Phương thức yêu cầu cho hỗ trợ thiết kế - không sửa đổi nội dung của phương thức này với trình chỉnh sửa mã.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListCategories));
            this.lvwCategory = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchCategory = new System.Windows.Forms.TextBox();
            this.btnSearchCategory = new System.Windows.Forms.Button();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnUpdateCategory = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.btnCancelCategory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwCategory
            // 
            this.lvwCategory.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwCategory.HideSelection = false;
            this.lvwCategory.Location = new System.Drawing.Point(25, 77);
            this.lvwCategory.Name = "lvwCategory";
            this.lvwCategory.Size = new System.Drawing.Size(806, 412);
            this.lvwCategory.TabIndex = 0;
            this.lvwCategory.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tìm kiếm danh mục sản phẩm";
            // 
            // txtSearchCategory
            // 
            this.txtSearchCategory.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCategory.Location = new System.Drawing.Point(201, 26);
            this.txtSearchCategory.Multiline = true;
            this.txtSearchCategory.Name = "txtSearchCategory";
            this.txtSearchCategory.Size = new System.Drawing.Size(488, 35);
            this.txtSearchCategory.TabIndex = 2;
            // 
            // btnSearchCategory
            // 
            this.btnSearchCategory.BackColor = System.Drawing.Color.Ivory;
            this.btnSearchCategory.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCategory.Location = new System.Drawing.Point(709, 26);
            this.btnSearchCategory.Name = "btnSearchCategory";
            this.btnSearchCategory.Size = new System.Drawing.Size(122, 35);
            this.btnSearchCategory.TabIndex = 3;
            this.btnSearchCategory.Text = "Tìm kiếm";
            this.btnSearchCategory.UseVisualStyleBackColor = false;
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.BackColor = System.Drawing.Color.Beige;
            this.btnAddCategory.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCategory.Location = new System.Drawing.Point(25, 495);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(122, 35);
            this.btnAddCategory.TabIndex = 4;
            this.btnAddCategory.Text = "Thêm";
            this.btnAddCategory.UseVisualStyleBackColor = false;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnUpdateCategory
            // 
            this.btnUpdateCategory.BackColor = System.Drawing.Color.Bisque;
            this.btnUpdateCategory.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateCategory.Location = new System.Drawing.Point(153, 495);
            this.btnUpdateCategory.Name = "btnUpdateCategory";
            this.btnUpdateCategory.Size = new System.Drawing.Size(122, 35);
            this.btnUpdateCategory.TabIndex = 5;
            this.btnUpdateCategory.Text = "Cập nhật";
            this.btnUpdateCategory.UseVisualStyleBackColor = false;
            this.btnUpdateCategory.Click += new System.EventHandler(this.btnUpdateCategory_Click);
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.BackColor = System.Drawing.Color.LightPink;
            this.btnDeleteCategory.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCategory.Location = new System.Drawing.Point(281, 495);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(122, 35);
            this.btnDeleteCategory.TabIndex = 6;
            this.btnDeleteCategory.Text = "Xóa";
            this.btnDeleteCategory.UseVisualStyleBackColor = false;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // btnCancelCategory
            // 
            this.btnCancelCategory.BackColor = System.Drawing.Color.Ivory;
            this.btnCancelCategory.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelCategory.Location = new System.Drawing.Point(709, 495);
            this.btnCancelCategory.Name = "btnCancelCategory";
            this.btnCancelCategory.Size = new System.Drawing.Size(122, 35);
            this.btnCancelCategory.TabIndex = 7;
            this.btnCancelCategory.Text = "Hủy";
            this.btnCancelCategory.UseVisualStyleBackColor = false;
            this.btnCancelCategory.Click += new System.EventHandler(this.btnCancelCategory_Click);
            // 
            // ListCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 561);
            this.Controls.Add(this.btnCancelCategory);
            this.Controls.Add(this.btnDeleteCategory);
            this.Controls.Add(this.btnUpdateCategory);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.btnSearchCategory);
            this.Controls.Add(this.txtSearchCategory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwCategory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListCategories";
            this.Text = "Danh sách danh mục";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ListCategories_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchCategory;
        private System.Windows.Forms.Button btnSearchCategory;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnUpdateCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Button btnCancelCategory;
    }
}