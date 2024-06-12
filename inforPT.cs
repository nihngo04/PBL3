using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PBL3_fi
{
    public partial class inforPT : Form
    {
        private string _HLVId = null;

        public inforPT()
        {
            InitializeComponent();
        }
        public inforPT(string HLVId) : this()
        {
            _HLVId = HLVId;
            LoadPTData(HLVId);
        }
        private void LoadPTData(string HLVId)
        {
            string query = "SELECT * FROM Huan_luyen_vien WHERE Ma_HLV = @Ma_HLV";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Ma_HLV", HLVId)
            };
            DataTable dt = DBHelper.Instance.GetRecord(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtName.Text = row["Ho_ten"].ToString();
                txtChuyenmon.Text = row["Chuyen_mon"].ToString();
                txtKinhnghiem.Text = row["Kinh_nghiem"].ToString();
                txtLuong.Text = row["Luong"].ToString();
            }
        }
        private string GeneratePTID()
        {
            string query = "SELECT Ma_HLV FROM Huan_luyen_vien ORDER BY Ma_HLV DESC";
            DataTable dt = DBHelper.Instance.GetRecord(query);
            string nextId = "PT01";

            if (dt.Rows.Count > 0)
            {
                string maxId = dt.Rows[0]["Ma_HLV"].ToString();
                int maxNumber = int.Parse(maxId.Substring(2));
                bool isUnique = false;

                while (!isUnique)
                {
                    maxNumber++;
                    nextId = "PT" + maxNumber.ToString("D2");
                    query = "SELECT COUNT(*) FROM Huan_luyen_vien WHERE Ma_HLV = @Ma_HLV";
                    SqlParameter param = new SqlParameter("@Ma_HLV", nextId);
                    int count = (int)DBHelper.Instance.ExecuteScalar(query, param);
                    if (count == 0)
                    {
                        isUnique = true;
                    }
                }
            }

            return nextId;
        }
        private void bt_savePT_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các trường nhập liệu
            string hoTen = txtName.Text.Trim();
            string chuyenMon = txtChuyenmon.Text.Trim();
            string kinhNghiem = txtKinhnghiem.Text.Trim();
            float luong = float.Parse(txtLuong.Text.Trim());

            // Tạo kết nối đến cơ sở dữ liệu
            if (!string.IsNullOrEmpty(_HLVId))
            {
                string query = "UPDATE Huan_luyen_vien SET Ma_HLV = @Ma_HLV, Ho_ten = @Ho_ten, Chuyen_mon = @Chuyen_mon, Kinh_nghiem = @Kinh_nghiem, Luong = @Luong WHERE Ma_HLV = @Ma_HLV";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@Ho_ten", hoTen),
            new SqlParameter("@Chuyen_mon", chuyenMon),
            new SqlParameter("@Kinh_nghiem", kinhNghiem),
            new SqlParameter("@Luong", luong)
                };

                try
                {
                    DBHelper.Instance.ExecuteDB(query, parameters);
                    MessageBox.Show("Data updated successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                // Sinh mã PT mới
                string newPTId = GeneratePTID();

                // Insert new record
                string query = "INSERT INTO Huan_luyen_vien (Ma_HLV, Ho_ten, Chuyen_mon, Kinh_nghiem, Luong) " +
                               "VALUES (@Ma_HLV, @Ho_ten, @Chuyen_mon, @Kinh_nghiem, @Luong)";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@Ma_HLV", newPTId),
            new SqlParameter("@Ho_ten", hoTen),
            new SqlParameter("@Chuyen_mon", chuyenMon),
            new SqlParameter("@Kinh_nghiem", kinhNghiem),
            new SqlParameter("@Luong", luong)
                };

                try
                {
                    DBHelper.Instance.ExecuteDB(query, parameters);
                    MessageBox.Show("Data saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btcancel_Click(object sender, EventArgs e)
        {
            // Đóng form khi nhấn nút Cancel
            this.Close();
        }

        private void inforPT_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
