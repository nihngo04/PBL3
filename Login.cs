using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PBL3_fi
{
    public partial class Login : Form
    {
        // Biến để lưu trữ ID tài khoản và tên người dùng đăng nhập
        private string currentUserId;
        private string currentUsername;

        public Login()
        {
            InitializeComponent();
        }

        private void GetUserType(string username, string password, out string userType, out string userId, out string userDisplayName)
        {
            userType = string.Empty;
            userId = string.Empty;
            userDisplayName = string.Empty;

            string query = "SELECT ID_tai_khoan, Loai_nguoi_dung, Ten_nguoi_dung FROM TAI_KHOAN WHERE Ten_dang_nhap = @Ten_dang_nhap AND Mat_khau = @Mat_khau";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Ten_dang_nhap", username),
                new SqlParameter("@Mat_khau", password)
            };

            DataTable dt = DBHelper.Instance.GetRecord(query, parameters);
            if (dt.Rows.Count > 0)
            {
                userId = dt.Rows[0]["ID_tai_khoan"].ToString();
                userType = dt.Rows[0]["Loai_nguoi_dung"].ToString();
                userDisplayName = dt.Rows[0]["Ten_nguoi_dung"].ToString();
            }
        }

        private void btlogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPass.Text.Trim();
                string userType, userId, userDisplayName;

                GetUserType(username, password, out userType, out userId, out userDisplayName);

                if (!string.IsNullOrEmpty(userType))
                {
                    // Đăng nhập thành công
                    this.DialogResult = DialogResult.OK;

                    // Lưu trữ thông tin người dùng đã đăng nhập
                    UserSession.UserId = userId;
                    UserSession.Username = userDisplayName;

                    Form nextForm;
                    if (userType == "admin")
                    {
                        MessageBox.Show("Admin login successful", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        nextForm = new GymDataFormRec();
                    }
                    else if (userType == "PT")
                    {
                        MessageBox.Show("PT login successful", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        nextForm = new GymDataFormPT();
                    }
                    else
                    {
                        MessageBox.Show("Unknown user type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    nextForm.Show();
                    this.Hide(); // Ẩn form hiện tại thay vì đóng để kiểm tra
                }
                else
                {
                    // Sai tên người dùng hoặc mật khẩu
                    MessageBox.Show("Incorrect Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Text = "";
                    txtPass.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            // Người dùng nhấn Cancel
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}


/*using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PBL3_fi
{
    public partial class Login : Form
    {
        // Biến để lưu trữ ID tài khoản và tên người dùng đăng nhập
        private string currentUserId;
        private string currentUsername;

        public Login()
        {
            InitializeComponent();
        }

        private void GetUserType(string username, string password, out string userType, out string userId, out string userDisplayName)
        {
            userType = string.Empty;
            userId = string.Empty;
            userDisplayName = string.Empty;

            string query = "SELECT ID_tai_khoan, Loai_nguoi_dung, Ten_nguoi_dung FROM TAI_KHOAN WHERE Ten_dang_nhap = @Ten_dang_nhap AND Mat_khau = @Mat_khau";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Ten_dang_nhap", username),
                new SqlParameter("@Mat_khau", password)
            };

            DataTable dt = DBHelper.Instance.GetRecord(query, parameters);
            if (dt.Rows.Count > 0)
            {
                userId = dt.Rows[0]["ID_tai_khoan"].ToString().Trim();
                userType = dt.Rows[0]["Loai_nguoi_dung"].ToString().Trim();
                userDisplayName = dt.Rows[0]["Ten_nguoi_dung"].ToString().Trim();
            }
        }

        private void btlogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPass.Text.Trim();
                string userType, userId, userDisplayName;

                GetUserType(username, password, out userType, out userId, out userDisplayName);

                if (!string.IsNullOrEmpty(userType))
                {
                    // Đăng nhập thành công
                    this.DialogResult = DialogResult.OK;

                    // Lưu trữ thông tin người dùng đã đăng nhập
                    currentUserId = userId;
                    currentUsername = userDisplayName;

                    Form nextForm;
                    if (userType == "admin")
                    {
                        nextForm = new GymDataFormRec();
                    }
                    else if (userType == "PT")
                    {
                        nextForm = new GymDataFormPT();
                    }
                    else
                    {
                        MessageBox.Show("Unknown user type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    nextForm.Show();
                    this.Close();
                }
                else
                {
                    // Sai tên người dùng hoặc mật khẩu
                    MessageBox.Show("Incorrect Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Text = "";
                    txtPass.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            // Người dùng nhấn Cancel
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Phương thức để lấy ID tài khoản của người dùng đã đăng nhập
        public string GetCurrentUserId()
        {
            return currentUserId;
        }

        // Phương thức để lấy tên người dùng đã đăng nhập
        public string GetCurrentUsername()
        {
            return currentUsername;
        }
    }
}*/