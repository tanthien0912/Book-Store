using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ecommerce.Controller;
using Ecommerce.Model.Entity;

namespace Ecommerce.View.Admin.Categories
{
    public partial class ListCategories : Form
    {
        private List<Model.Entity.Categories> danhSachDanhMuc = new List<Model.Entity.Categories>();

        private CategoriesController controller;
        private Model.Entity.Categories danhMuc;

        public ListCategories()
        {
            InitializeComponent();
            this.CenterToScreen();
            controller = new CategoriesController();
            KhoiTaoListView();
            TaiDuLieu();
        }

        private void KhoiTaoListView()
        {
            lvwCategory.View = System.Windows.Forms.View.Details;
            lvwCategory.FullRowSelect = true;
            lvwCategory.GridLines = true;
            lvwCategory.Columns.Add("STT", 35, HorizontalAlignment.Center);
            lvwCategory.Columns.Add("Người Tạo", 350, HorizontalAlignment.Left);
            lvwCategory.Columns.Add("Danh Mục", 400, HorizontalAlignment.Left);
        }

        private void TaiDuLieu()
        {
            lvwCategory.Items.Clear();
            danhSachDanhMuc = controller.ReadAll();
            foreach (var cat in danhSachDanhMuc)
            {
                var stt = lvwCategory.Items.Count + 1;
                var item = new ListViewItem(stt.ToString());
                item.SubItems.Add(cat.CreatedByName);
                item.SubItems.Add(cat.Name);
                lvwCategory.Items.Add(item);
            }
        }

        private void XuLySuKienTao(Model.Entity.Categories cat)
        {
            danhSachDanhMuc.Add(cat);
            int stt = lvwCategory.Items.Count + 1;
            ListViewItem item = new ListViewItem(stt.ToString());
            item.SubItems.Add(cat.CreatedByName);
            item.SubItems.Add(cat.Name);
            lvwCategory.Items.Add(item);
        }

        private void XuLySuKienCapNhat(Model.Entity.Categories cat)
        {
            int index = lvwCategory.SelectedIndices[0];
            ListViewItem itemRow = lvwCategory.Items[index];
            itemRow.SubItems[1].Text = cat.CreatedByName;
            itemRow.SubItems[2].Text = cat.Name;
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            EntryCategory frmEntry = new EntryCategory("Thêm Danh Mục", controller);
            frmEntry.OnCreate += XuLySuKienTao;
            frmEntry.ShowDialog();
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            if (lvwCategory.SelectedItems.Count > 0)
            {
                Model.Entity.Categories cat = danhSachDanhMuc[lvwCategory.SelectedIndices[0]];
                EntryCategory frmEntry = new EntryCategory("Chỉnh Sửa Danh Mục", cat, controller);
                frmEntry.OnUpdate += XuLySuKienCapNhat;
                frmEntry.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chưa chọn dữ liệu", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (lvwCategory.SelectedItems.Count > 0)
            {
                var confirm = MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (confirm == DialogResult.Yes)
                {
                    var result = controller.Delete(danhSachDanhMuc[lvwCategory.SelectedIndices[0]].Id);
                    if (result > 0) TaiDuLieu();
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn dữ liệu", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancelCategory_Click(object sender, EventArgs e)
        {
            LandingPage landing = new LandingPage();
            landing.Show();
            Visible = false;
        }

        private void ListCategories_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
