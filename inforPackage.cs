using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PBL3_fi
{
    public partial class inforPackage : Form
    {
        private string _PackId = null;

        public inforPackage()
        {
            InitializeComponent();
        }
        public inforPackage(string PackId) : this()
        {
            _PackId = PackId;
            LoadPTData(PackId);
        }
        private void LoadPTData(string PackId)
        {
            string query = "SELECT * FROM Goi_tap WHERE Ma_goi_tap = @Ma_goi_tap";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Ma_goi_tap", PackId)
            };
            DataTable dt = DBHelper.Instance.GetRecord(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtMa.Text = row["Ma_goi_tap"].ToString();
                txtTen.Text = row["Ten_goi_tap"].ToString();
                txtGia.Text = row["Don_gia"].ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các trường nhập liệu
            string maGoi = txtMa.Text.Trim();
            string Ten = txtTen.Text.Trim();
            string giaText = txtGia.Text.Trim();
            float gia = float.Parse(giaText);

            // Tạo kết nối đến cơ sở dữ liệu
            if (!string.IsNullOrEmpty(_PackId))
            {
                string query = "UPDATE Goi_tap SET Ma_goi_tap = @Ma_goi_tap, Ten_goi_tap = @Ten_goi_tap, Don_gia = @Don_gia WHERE Ma_goi_tap = @Ma_goi_tap";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@Ma_goi_tap", maGoi),
            new SqlParameter("@Ten_goi_tap", Ten),
            new SqlParameter("@Don_gia", gia)
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
                
                // Insert new record
                string query = "INSERT INTO Goi_tap (Ma_goi_tap, Ten_goi_tap, Don_gia) " +
                               "VALUES (@Ma_goi_tap, @Ten_goi_tap, @Don_gia)";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@Ma_goi_tap", maGoi),
            new SqlParameter("@Ten_goi_tap", Ten),
            new SqlParameter("@Don_gia", gia)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
