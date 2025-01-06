using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ecommerce.Model.Entity;
using Ecommerce.Controller;
using Ecommerce.Helper;

namespace Ecommerce.View.Admin.Categories
{
    public partial class EntryCategory : Form
    {
        public delegate void CreateUpdateEventHandler(Model.Entity.Categories cat);
        public event CreateUpdateEventHandler OnCreate;
        public event CreateUpdateEventHandler OnUpdate;
        private CategoriesController controller;
        private bool isNewData;
        private Model.Entity.Categories cat;
        private GrabUser grabUser;

        public EntryCategory()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        public EntryCategory(string title, CategoriesController controller) : this()
        {
            this.Text = title;
            this.controller = controller;
            isNewData = true;
        }

        public EntryCategory(string title, Model.Entity.Categories obj, CategoriesController controller) : this()
        {
            this.Text = title;
            this.controller = controller;

            isNewData = false;
            cat = obj;
            txtCategoryName.Text = cat.Name;
        }

        private void btnSaveEC_Click(object sender, EventArgs e)
        {
            if (isNewData) cat = new Model.Entity.Categories();
            grabUser = new GrabUser();

            cat.CreatedByName = grabUser.Data().NameUser;
            cat.Name = txtCategoryName.Text;

            int result = 0;

            if (isNewData)
            {
                result = controller.Create(txtCategoryName.Text);
                if (result == 1)
                {
                    OnCreate(cat);
                    txtCategoryName.Text = "";
                } 
                else if (result == 2)
                {
                    MessageBox.Show("Danh mục đã đạt giới hạn 5", "Thất bại!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Hide();
                } 
                else
                {
                    MessageBox.Show("Tạo dữ liệu thất bại", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                result = controller.Update(cat);
                if (result > 0)
                {
                    OnUpdate(cat);
                } 
                else
                {
                    MessageBox.Show("Cập nhật dữ liệu thất bại", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                this.Hide();
            }
        }

        private void btnCancelEC_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void EntryCategory_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }
    }
}
