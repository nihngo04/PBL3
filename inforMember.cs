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
    public partial class inforMember : Form
    {
        private int? _khachId = null;

        public inforMember()
        {
            InitializeComponent();
            AddItemsToPackageComboBox();
            LoadHLVData();
        }
        public inforMember(int khachId) : this()
        {
            _khachId = khachId;
            LoadKhachData(khachId);
        }
        private void LoadKhachData(int khachId)
        {
            string query = "SELECT Ho_ten as [Họ và tên], Ngay_sinh as [Ngày sinh], So_dien_thoai as [Số điện thoại], Email as [Email], Gioi_tinh as [Giới tính], Ma_goi_tap as [Mã gói tập], Ngay_tham_gia as [Ngày tham gia], Ma_HLV as [Mã HLV], Dia_chi as [Địa chỉ]FROM Khach WHERE ID_khach = @ID_khach";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@ID_khach", khachId)
            };
            DataTable dt = DBHelper.Instance.GetRecord(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txthoten.Text = row["Họ và tên"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row["Ngày sinh"]);
                txtsdt.Text = row["Số điện thoại"].ToString();
                txtemail.Text = row["Email"].ToString();
                string gioiTinh = row["Giới tính"].ToString();
                radioNam.Checked = gioiTinh == "Nam";
                radioNu.Checked = gioiTinh == "Nữ";
                string maGoiTap = row["Mã gói tập"].ToString();
                cbbgoitap.SelectedItem = GetGoiTapName(maGoiTap);
                dateTimePicker2.Value = Convert.ToDateTime(row["Ngày tham gia"]);
                richTextBox1.Text = row["Địa chỉ"].ToString();
            }
        }
        private void AddItemsToPackageComboBox()
        {
            // Thêm các mục vào ComboBox cbbgoitap
            cbbgoitap.Items.Add("01 buổi");
            cbbgoitap.Items.Add("01 tháng");
            cbbgoitap.Items.Add("03 tháng");
            cbbgoitap.Items.Add("06 tháng");
            cbbgoitap.Items.Add("12 tháng");
        }
        private void LoadHLVData()
        {
            string query = "SELECT Ma_HLV, Ho_ten FROM Huan_luyen_vien";
            DataTable dt = DBHelper.Instance.GetRecord(query);

            // Thêm một hàng "None" vào DataTable
            DataRow newRow = dt.NewRow();
            newRow["Ma_HLV"] = DBNull.Value; // hoặc bạn có thể đặt giá trị cụ thể như 0 hay -1
            newRow["Ho_ten"] = "None";
            dt.Rows.InsertAt(newRow, 0); // Thêm hàng vào đầu DataTable

            cbbHLV.DataSource = dt;
            cbbHLV.DisplayMember = "Ho_ten";
            cbbHLV.ValueMember = "Ma_HLV";
        }

        private string GenerateCustomerID()
        {
            string query = "SELECT ID_khach FROM Khach ORDER BY ID_khach DESC";
            DataTable dt = DBHelper.Instance.GetRecord(query);
            string nextId = "KH000001";

            if (dt.Rows.Count > 0)
            {
                string maxId = dt.Rows[0]["ID_khach"].ToString();
                int maxNumber = int.Parse(maxId.Substring(2));
                bool isUnique = false;

                while (!isUnique)
                {
                    maxNumber++;
                    nextId = "KH" + maxNumber.ToString("D6");
                    query = "SELECT COUNT(*) FROM Khach WHERE ID_khach = @ID_khach";
                    SqlParameter param = new SqlParameter("@ID_khach", nextId);
                    int count = (int)DBHelper.Instance.ExecuteScalar(query, param);
                    if (count == 0)
                    {
                        isUnique = true;
                    }
                }
            }

            return nextId;
        }
        private void btsave_Click(object sender, EventArgs e)
        {
            string hoten = txthoten.Text;
            DateTime ngaysinh = dateTimePicker1.Value;
            string sdt = txtsdt.Text;
            string email = txtemail.Text;
            string gioitinh = radioNam.Checked ? "Nam" : "Nu";
            string goitap = cbbgoitap.SelectedItem.ToString();
            string magoitap = GetMaGoiTap(goitap);
            DateTime ngaythamgia = dateTimePicker2.Value;
            string maHLV = cbbHLV.SelectedValue.ToString();
            string diachi = richTextBox1.Text;

            if (_khachId.HasValue)
            {
                // Update existing record
                string query = "UPDATE Khach SET Ho_ten = @Ho_ten, Ngay_sinh = @Ngay_sinh, So_dien_thoai = @So_dien_thoai, Email = @Email, Gioi_tinh = @Gioi_tinh, Ma_goi_tap = @Ma_goi_tap, Ngay_tham_gia = @Ngay_tham_gia, Ma_HLV = @Ma_HLV, Dia_chi = @Dia_chi WHERE ID_khach = @ID_khach";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@Ho_ten", hoten),
            new SqlParameter("@Ngay_sinh", ngaysinh),
            new SqlParameter("@So_dien_thoai", sdt),
            new SqlParameter("@Email", email),
            new SqlParameter("@Gioi_tinh", gioitinh),
            new SqlParameter("@Ma_goi_tap", magoitap),
            new SqlParameter("@Ngay_tham_gia", ngaythamgia),
            new SqlParameter("@Ma_HLV", maHLV),
            new SqlParameter("@Dia_chi", diachi),
            new SqlParameter("@ID_khach", _khachId.Value)
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
                string newCustomerId = GenerateCustomerID();

                string query = "INSERT INTO Khach (ID_khach, Ho_ten, Ngay_sinh, So_dien_thoai, Email, Gioi_tinh, Ma_goi_tap, Ngay_tham_gia, Ma_HLV, Dia_chi) " +
                               "VALUES (@ID_khach, @Ho_ten, @Ngay_sinh, @So_dien_thoai, @Email, @Gioi_tinh, @Ma_goi_tap, @Ngay_tham_gia, @Ma_HLV, @Dia_chi)";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@ID_khach", newCustomerId),
            new SqlParameter("@Ho_ten", hoten),
            new SqlParameter("@Ngay_sinh", ngaysinh),
            new SqlParameter("@So_dien_thoai", sdt),
            new SqlParameter("@Email", email),
            new SqlParameter("@Gioi_tinh", gioitinh),
            new SqlParameter("@Ma_goi_tap", magoitap),
            new SqlParameter("@Ngay_tham_gia", ngaythamgia),
            new SqlParameter("@Ma_HLV", maHLV),
            new SqlParameter("@Dia_chi", diachi)
                };
                try
                {
                    DBHelper.Instance.ExecuteDB(query, parameters);
                    MessageBox.Show("Data saved successfully!");
                    this.Hide();
                    // Gọi hàm tạo và in hóa đơn
                    CreateAndPrintInvoice(newCustomerId, goitap);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void CreateAndPrintInvoice(string customerId, string packageName)
        {
            string newInvoiceID = GenerateInvoiceID();
            string hoten = txthoten.Text;
            string sdt = txtsdt.Text;
            string diachi = richTextBox1.Text;
            string goitap = cbbgoitap.SelectedItem.ToString();
            string magoitap = GetMaGoiTap(goitap);
            string maHLV = cbbHLV.SelectedValue.ToString();
            string tenHLV = cbbHLV.GetItemText(cbbHLV.SelectedItem); // Lấy tên HLV từ ComboBox

            // Tính toán thời hạn dựa trên tên gói tập và ngày xuất hóa đơn
            DateTime invoiceDate = DateTime.Now;
            int duration = GetPackageDuration(goitap);
            DateTime expiryDate = invoiceDate.AddDays(duration);

            // Lấy giá của gói tập từ bảng Goi_tap
            float packagePrice = GetPackagePrice(magoitap);

            string invoiceQuery = "INSERT INTO hoa_don (Ma_hoa_don, Ma_goi_tap, Ma_le_tan, Ngay_xuat_hoa_don, Ten_khach_hang, Ten_goi_tap, Thoi_han, Ten_HLV, Thanh_tien, Ten_nhan_vien, SDT_khach, Dia_chi_khach) " +
                                  "VALUES (@Ma_hoa_don, @Ma_goi_tap, @Ma_le_tan, @Ngay_xuat_hoa_don, @Ten_khach_hang, @Ten_goi_tap, @Thoi_han, @Ten_HLV, @Thanh_tien, @Ten_nhan_vien, @SDT_khach, @Dia_chi_khach)";
            SqlParameter[] invoiceParameters = new SqlParameter[]
            {
        new SqlParameter("@Ma_hoa_don", newInvoiceID),
        new SqlParameter("@Ma_goi_tap", magoitap),
        new SqlParameter("@Ma_le_tan", UserSession.UserId),
        new SqlParameter("@Ngay_xuat_hoa_don", invoiceDate),
        new SqlParameter("@Ten_khach_hang", hoten),
        new SqlParameter("@Ten_goi_tap", goitap),
        new SqlParameter("@Thoi_han", expiryDate),
        new SqlParameter("@Ten_HLV", tenHLV),
        new SqlParameter("@Thanh_tien", packagePrice),
        new SqlParameter("@Ten_nhan_vien", UserSession.Username),
        new SqlParameter("@SDT_khach", sdt),
        new SqlParameter("@Dia_chi_khach", diachi)
            };
            try
            {
                DBHelper.Instance.ExecuteDB(invoiceQuery, invoiceParameters);
                MessageBox.Show("Hóa đơn đã được tạo thành công!");
                // Hiển thị form inforInvoice nếu người dùng chọn Yes
                DialogResult result = MessageBox.Show("Bạn có muốn in hóa đơn không?", "Xác nhận in hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Hiển thị form inforInvoice với thông tin hóa đơn
                    inforInvoice invoiceForm = new inforInvoice(invoiceDate, hoten, expiryDate, packagePrice, UserSession.Username, tenHLV, goitap, newInvoiceID, sdt, diachi);
                    invoiceForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //
        /*private void CreateAndPrintInvoice(string customerId, string packageName)
        {
            string newInvoiceID = GenerateInvoiceID();
            string hoten = txthoten.Text;
            string sdt = txtsdt.Text;
            string diachi = richTextBox1.Text;
            string goitap = cbbgoitap.SelectedItem.ToString();
            string magoitap = GetMaGoiTap(goitap);
            string maHLV = cbbHLV.SelectedValue.ToString();
            string tenHLV = cbbHLV.GetItemText(cbbHLV.SelectedItem); // Lấy tên HLV từ ComboBox

            // Tính toán thời hạn dựa trên tên gói tập và ngày xuất hóa đơn
            DateTime invoiceDate = DateTime.Now;
            int duration = GetPackageDuration(goitap);
            DateTime expiryDate = invoiceDate.AddDays(duration);

            // Lấy giá của gói tập từ bảng Goi_tap
            float packagePrice = GetPackagePrice(magoitap);

            string invoiceQuery = "INSERT INTO hoa_don (Ma_hoa_don, Ma_goi_tap, Ma_le_tan, Ngay_xuat_hoa_don, Ten_khach_hang, Ten_goi_tap, Thoi_han, Ten_HLV, Thanh_tien, Ten_nhan_vien, SDT_khach, Dia_chi_khach) VALUES (@Ma_hoa_don, @Ma_goi_tap, @Ma_le_tan, @Ngay_xuat_hoa_don, @Ten_khach_hang, @Ten_goi_tap, @Thoi_han, @Ten_HLV, @Thanh_tien, @Ten_nhan_vien, @SDT_khach, @Dia_chi_khach)";
            SqlParameter[] invoiceParameters = new SqlParameter[]
            {
        new SqlParameter("@Ma_hoa_don", newInvoiceID),
        new SqlParameter("@Ma_goi_tap", magoitap),
        new SqlParameter("@Ma_le_tan", _currentUserId),
        new SqlParameter("@Ngay_xuat_hoa_don", invoiceDate),
        new SqlParameter("@Ten_khach_hang", hoten),
        new SqlParameter("@Ten_goi_tap", goitap),
        new SqlParameter("@Thoi_han", expiryDate),
        new SqlParameter("@Ten_HLV", tenHLV),
        new SqlParameter("@Thanh_tien", packagePrice),
        new SqlParameter("@Ten_nhan_vien", _currentUsername),
        new SqlParameter("@SDT_khach", sdt),
        new SqlParameter("@Dia_chi_khach", diachi)
            };
            try
            {
                DBHelper.Instance.ExecuteDB(invoiceQuery, invoiceParameters);
                MessageBox.Show("Hóa đơn đã được tạo thành công!");
                // Hiển thị form inforInvoice nếu người dùng chọn Yes
                DialogResult result = MessageBox.Show("Bạn có muốn in hóa đơn không?", "Xác nhận in hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Hiển thị form inforInvoice với thông tin hóa đơn
                    inforInvoice invoiceForm = new inforInvoice(invoiceDate, hoten, expiryDate, packagePrice, _currentUsername, tenHLV, goitap, newInvoiceID, sdt, diachi);
                    invoiceForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }*/

        private int GetPackageDuration(string packageName)
        {
            int duration = 0;
            switch (packageName)
            {
                case "01 tháng":
                    duration = 30;
                    break;
                case "03 tháng":
                    duration = 90;
                    break;
                case "06 tháng":
                    duration = 180;
                    break;
                case "12 tháng":
                    duration = 365;
                    break;
                case "01 buổi":
                    duration = 1;
                    break;
                default:
                    break;
            }
            return duration;
        }
        private float GetPackagePrice(string maGoiTap)
        {
            string query = "SELECT Don_gia FROM Goi_tap WHERE Ma_goi_tap = @Ma_goi_tap";
            SqlParameter param = new SqlParameter("@Ma_goi_tap", maGoiTap);
            object result = DBHelper.Instance.ExecuteScalar(query, param);

            if (result != null && result != DBNull.Value)
            {
                return Convert.ToSingle(result);
            }
            return 0;
        }

        private string GenerateInvoiceID()
        {
            DateTime now = DateTime.Now;
            string datePart = now.ToString("yyyyMMdd"); // Định dạng ngày tháng năm
            string timePart = now.ToString("HHmmss"); // Định dạng thời gian
            return $"HD{datePart}{timePart}";
        }

        //
        private void btcancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string GetMaGoiTap(string goiTap)
        {
            string maGoiTap = "";
            switch (goiTap)
            {
                case "01 tháng":
                    maGoiTap = "GT01";
                    break;
                case "03 tháng":
                    maGoiTap = "GT03";
                    break;
                case "06 tháng":
                    maGoiTap = "GT06";
                    break;
                case "12 tháng":
                    maGoiTap = "GT12";
                    break;
                case "01 buổi":
                    maGoiTap = "GT1N";
                    break;
                default: break;
            }
            return maGoiTap;
        }
        private string GetGoiTapName(string maGoiTap)
        {
            string goiTap = "";
            switch (maGoiTap)
            {
                case "GT01":
                    goiTap = "01 tháng";
                    break;
                case "GT03":
                    goiTap = "03 tháng";
                    break;
                case "GT06":
                    goiTap = "06 tháng";
                    break;
                case "GT12":
                    goiTap = "12 tháng";
                    break;
                case "GT1N":
                    goiTap = "01 buổi";
                    break;
                default:
                    break;
            }
            return goiTap;
        }

    }
}


