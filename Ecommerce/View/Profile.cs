using Ecommerce.Controller;
using Ecommerce.Helper;
using Ecommerce.View.Admin.Products;
using Ecommerce.View.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ecommerce.Model.Entity;

namespace Ecommerce.View
{
    public partial class Profile : Form
    {
        private GrabUser grabUser;
        private ImageList imageList;
        private Currency currency;
        private List<Transactions> listOfTrx = new List<Transactions>();
        private ProfileController controller;
        private string role;
        public Profile()
        {
            InitializeComponent();
            this.CenterToScreen();
            
            controller = new ProfileController();
            grabUser = new GrabUser();
            currency = new Currency();

            var user = grabUser.Data();
            role = user.RoleUser;

            LoadProfile();
            InisialisasiListView();
            LoadData();
        }

        private void LoadProfile()
        {
            var user = grabUser.Data();
            txtName.Text = user.NameUser;
            txtAddress.Text = user.AddressUser;
            txtPhone.Text = user.PhoneUser;
            txtRole.Text = user.RoleUser;
            if(role == "Admin")
            {
                label6.Show();
                label5.Hide();
                button1.Text = "Kiểm tra";
            } else
            {
                label6.Hide();
                label5.Show();
                button1.Text = "Thanh toán";
            }
        }

        private void InisialisasiListView()
        {
            imageList = new ImageList();
            imageList.ImageSize = new Size(150, 150);

            lvwProfile.View = System.Windows.Forms.View.Details;
            lvwProfile.FullRowSelect = true;
            lvwProfile.GridLines = true;
            lvwProfile.Columns.Add("Hình ảnh", 150, HorizontalAlignment.Center);
            lvwProfile.Columns.Add("Hóa đơn", 100, HorizontalAlignment.Left);
            if (role == "Admin")
            {
                lvwProfile.Columns.Add("Tên người dùng", 110, HorizontalAlignment.Left);
                lvwProfile.Columns.Add("Danh mục", 100, HorizontalAlignment.Left);
                lvwProfile.Columns.Add("Sản phẩm", 100, HorizontalAlignment.Left);
            }
            else
            {
                lvwProfile.Columns.Add("Danh mục", 130, HorizontalAlignment.Left);
                lvwProfile.Columns.Add("Sản phẩm", 200, HorizontalAlignment.Left);
            }
            lvwProfile.Columns.Add("Số lượng", 70, HorizontalAlignment.Center);
            lvwProfile.Columns.Add("Giá", 120, HorizontalAlignment.Center);
            lvwProfile.Columns.Add("Số tiền thanh toán", 120, HorizontalAlignment.Left);
            lvwProfile.Columns.Add("Ngày", 130, HorizontalAlignment.Left);
        }

        private void AddListViewItemFromUrl(int noUrut, Transactions t)
        {
            try
            {
                // Tải hình ảnh từ URL
                WebClient webClient = new WebClient();
                byte[] imageBytes = webClient.DownloadData(t.ImageProduct);

                // Chuyển đổi byte thành đối tượng Image
                using (MemoryStream stream = new MemoryStream(imageBytes))
                {
                    Image image = Image.FromStream(stream);

                    // Thêm hình ảnh vào ImageList
                    imageList.Images.Add(t.ImageProduct, image);

                    // Tạo đối tượng ListViewItem
                    ListViewItem item = new ListViewItem();
                    item.ImageKey = t.ImageProduct; // Đặt khóa hình ảnh theo tên

                    // Thêm văn bản bổ sung vào ListViewItem
                    item.SubItems.Add(t.InvoiceNumber);
                    if(role == "Admin")
                    {
                        item.SubItems.Add(t.UserName);
                    }
                    item.SubItems.Add(t.CategoryName);
                    item.SubItems.Add(t.ProductName);
                    item.SubItems.Add("1x");
                    item.SubItems.Add(currency.ConvertToIdn(t.Price));
                    if (t.Payed == 0)
                    {
                        item.SubItems.Add("Chưa thanh toán");
                    } else
                    {
                        item.SubItems.Add(currency.ConvertToIdn(t.Payed));
                    }
                    item.SubItems.Add(t.DateTime.ToString());

                    // Thêm ListViewItem vào ListView
                    lvwProfile.Items.Add(item);
                    lvwProfile.SmallImageList = imageList;
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu xảy ra khi tải xuống hoặc chuyển đổi hình ảnh
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void LoadData()
        {
            // Xóa danh sách trong listview
            lvwProfile.Items.Clear();
            // Gọi phương thức ReadAll và lưu dữ liệu vào collection
            if(role == "Admin")
            {
                listOfTrx = controller.ReadAllTransaction();
            } else
            {
                listOfTrx = controller.ReadAllTransactionWhereUser(grabUser.Data().IdUser);
            }
            
            // Trích xuất đối tượng từ collection
            foreach (var t in listOfTrx)
            {
                var noUrut = lvwProfile.Items.Count + 1;
                AddListViewItemFromUrl(noUrut, t);

            }
        }

        private void Profile_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LandingPage landing = new LandingPage();
            landing.Show();
            Visible = false;
        }

        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            UsersController usersController = new UsersController();
            if (usersController.Logout() > 0)
            {
                Login login = new Login();
                login.Show();
                Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lvwProfile.SelectedItems.Count > 0)
            {
                // Lấy đối tượng giao dịch muốn chỉnh sửa từ collection
                Model.Entity.Transactions t = listOfTrx[lvwProfile.SelectedIndices[0]];
                // Tạo đối tượng form nhập dữ liệu giao dịch
                if(role == "Admin")
                {
                    Invoice inv = new Invoice(t, true, true);
                    // Hiển thị form nhập
                    inv.ShowDialog();
                } else
                {
                    Invoice inv = new Invoice(t, true);
                    // Đăng ký phương thức xử lý sự kiện để phản hồi sự kiện OnUpdate
                    inv.OnUpdate += LoadData;
                    // Hiển thị form nhập
                    inv.ShowDialog();
                }
                
            }
            else // Dữ liệu chưa được chọn
            {
                MessageBox.Show("Chưa chọn dữ liệu", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lvwProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(role == "Admin") { return; }

            if (lvwProfile.SelectedItems.Count > 0)
            {
                // Lấy đối tượng giao dịch muốn chỉnh sửa từ collection
                Model.Entity.Transactions t = listOfTrx[lvwProfile.SelectedIndices[0]];
                if (t.Status == "paid")
                {
                    button1.Text = "Xem";
                } else
                {
                    button1.Text = "Thanh toán";
                }
            }
        }
    }
}
