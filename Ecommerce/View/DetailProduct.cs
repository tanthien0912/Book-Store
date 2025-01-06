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
using Ecommerce.Helper;
using Ecommerce.Model.Entity;

namespace Ecommerce.View
{
    public partial class DetailProduct : Form
    {
        private ProductsController productController;
        private TransactionsController trxController;
        private Products product;
        private Currency currency;
        private int IdProduct;
        private Transactions trx;
        private GrabUser grabUser;

        public DetailProduct()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        public DetailProduct(int Id, bool directBuy = false) : this()
        {
            if (directBuy)
            {
                productController = new ProductsController();
                product = new Products();
                currency = new Currency();
                IdProduct = Id;

                product = productController.ReadDetailProduct(Id);

                BELI_OM();
                return;
            }
            LoadData(Id);
        }

        public void LoadData(int Id)
        {
            productController = new ProductsController();
            product = new Products();
            currency = new Currency();
            IdProduct = Id;

            product = productController.ReadDetailProduct(Id);
            this.Text = "Chi tiết " + product.Name;
            ImageBB.DownloadAndSetImage(product.Image, pictureBox1);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            lblNameProduct.Text = product.Name;
            lblPrice.Text = currency.ConvertToIdn(product.Price);
            txtStock.Text = "Số lượng: " + product.Stock.ToString();
            txtDescProduct.Text = product.Description;
            txtDescProduct.Enabled = false;
            if(product.Stock == 0)
            {
                btnOutOfStock.Show();
                btnBuy.Hide();
            } else
            {
                btnOutOfStock.Hide();
                btnBuy.Show();
            }
        }

        private void DetailProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LandingPage landing = new LandingPage();
            landing.Show();
            Visible = false;
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            BELI_OM();
        }

        public void BELI_OM()
        {
            grabUser = new GrabUser();

            if (grabUser.Data() == null)
            {
                MessageBox.Show("Bạn cần đăng nhập", "Thông tin!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (grabUser.Data().RoleUser == "Admin")
            {
                MessageBox.Show("ĐÂY LÀ ADMIN! TÔI ĐÃ LÀM XONG");
                return;
            }

            trxController = new TransactionsController();
            trx = new Transactions();
            trx.IdUser = grabUser.Data().IdUser;
            trx.UserName = grabUser.Data().NameUser;
            trx.IdProduct = IdProduct;
            trx.ProductName = product.Name;
            trx.CategoryName = product.CategoryName;
            trx.Price = product.Price;
            trx.Status = "unpaid";
            trx.InvoiceNumber = InvoiceGenerator.GenerateInvoiceNumber();
            trx.DateTime = DateTime.UtcNow;

            if (trxController.Create(trx) > 0)
            {
                Invoice inv = new Invoice(trx);
                inv.Show();
                Visible = false;
            }
        }
    }
}
