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
    public partial class inforRecep : Form
    {
        private string _LTId = null;
        public inforRecep()
        {
            InitializeComponent();
        }

        public inforRecep(string LTId) : this()
        {
            _LTId = LTId;
            LoadRecepData(LTId);
        }

        private void LoadRecepData(string LTId)
        {
            string query = "SELECT * FROM Nhan_vien_le_tan WHERE Ma_le_tan = @Ma_le_tan";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Ma_le_tan", LTId)
            };
            DataTable dt = DBHelper.Instance.GetRecord(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtName.Text = row["Ho_ten"].ToString();
                txtChuyenmon.Text = row["Chuyen_mon"].ToString();
                txtSalary.Text = row["Luong"].ToString();
            }
        }
        private string GetNextReceptionistID()
        {
            string query = "SELECT Ma_le_tan FROM Nhan_vien_le_tan ORDER BY Ma_le_tan DESC";
            DataTable dt = DBHelper.Instance.GetRecord(query);
            string nextId = "LT01";

            if (dt.Rows.Count > 0)
            {
                string maxId = dt.Rows[0]["Ma_le_tan"].ToString();
                int maxNumber = int.Parse(maxId.Substring(2));
                bool isUnique = false;

                while (!isUnique)
                {
                    maxNumber++;
                    nextId = "LT" + maxNumber.ToString("D2");
                    query = "SELECT COUNT(*) FROM Nhan_vien_le_tan WHERE Ma_le_tan = @Ma_le_tan";
                    SqlParameter param = new SqlParameter("@Ma_le_tan", nextId);
                    int count = (int)DBHelper.Instance.ExecuteScalar(query, param);
                    if (count == 0)
                    {
                        isUnique = true;
                    }
                }
            }

            return nextId;
        }
        private void bt_save_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các trường nhập liệu
            string hoTen = txtName.Text.Trim();
            string chuyenMon = txtChuyenmon.Text.Trim();
            float luong = float.Parse(txtSalary.Text.Trim());

            if (!string.IsNullOrEmpty(_LTId))
            {
                // Update existing record
                string query = "UPDATE Nhan_vien_le_tan SET Ho_ten = @Ho_ten, Chuyen_mon = @Chuyen_mon, Luong = @Luong WHERE Ma_le_tan = @Ma_le_tan";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@Ho_ten", hoTen),
            new SqlParameter("@Chuyen_mon", chuyenMon),
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
                // Insert new record
                string maLT = GetNextReceptionistID();

                string query = "INSERT INTO Nhan_vien_le_tan (Ma_le_tan, Ho_ten, Chuyen_mon, Luong) " +
                               "VALUES (@Ma_le_tan, @Ho_ten, @Chuyen_mon, @Luong)";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@Ma_le_tan", maLT),
            new SqlParameter("@Ho_ten", hoTen),
            new SqlParameter("@Chuyen_mon", chuyenMon),
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
            this.Close();
        }
    }

}
