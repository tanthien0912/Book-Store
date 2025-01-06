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

namespace Ecommerce.View.Auth
{
    public partial class Register : Form
    {
        private UsersController controller;

        private Users user;

        public Register()
        {
            InitializeComponent();
            this.CenterToScreen();


            txtPhone.KeyPress += txtPhone_KeyPress;
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            int result = 0;

            if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtPhone.Text) || String.IsNullOrEmpty(txtAddress.Text) || String.IsNullOrEmpty(txtPassword.Text) || String.IsNullOrEmpty(txtCPassword.Text))
            {
                MessageBox.Show("Vui lòng điền tất cả các trường.", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } else if (txtPassword.TextLength < 6)
            {
                MessageBox.Show("Mật khẩu tối thiểu 6 ký tự.", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } else if (txtCPassword.Text != txtPassword.Text)
            {
                MessageBox.Show("Xác nhận mật khẩu phải giống nhau.", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Users user = new Users();
            user.NameUser = txtName.Text;
            user.PhoneUser = txtPhone.Text;
            user.AddressUser = txtAddress.Text;
            user.PasswordUser = txtPassword.Text;

            UsersController controller = new UsersController();
            result = controller.Register(user);
            if (result == 69) {
                MessageBox.Show("Số điện thoại đã được đăng ký", "Thất bại!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Text = "";
            } else if (result > 0)
            {
                txtName.Text = "";
                txtPhone.Text = "";
                txtAddress.Text = "";
                txtPassword.Text = "";
                txtCPassword.Text = "";

                DialogResult dialogResult = MessageBox.Show("Tài khoản của bạn đã được tạo thành công.", "Thành công!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Login FormLogin = new Login();
                
                FormLogin.Show();
                Visible = false;
            } else
            {
                MessageBox.Show("Tạo tài khoản của bạn không thành công.", "Thất bại!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            Login lgn = new Login();
            lgn.Show();
            Visible = false;
        }
    }
}