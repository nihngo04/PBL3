using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PBL3_fi
{
    public partial class GymDataFormRec : Form
    {
        private DataTable Member, PT, Recep, Machine, Invoice, Pack, Attend, Account;
        private DataTable[] tabData;
        private int currentTabIndex;

        public GymDataFormRec()
        {
            InitializeComponent();
            InitializeTabControl();
            LoadDataFromDatabase();
            InitializeSortComboBox_Menber();
            InitializeSortComboBox_PT();
            InitializeSortComboBox_Recep();
            InitializeSortComboBox_Pack();
            InitializeSortComboBox_Attend();
            InitializeSortComboBox_Acc();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            comboBoxStatisticsType.Items.AddRange(new string[] { "Tháng", "Năm" });
            comboBoxStatisticsType.SelectedIndex = 0; // Chọn mặc định là "Tháng"
            radioButtonQuantity.Checked = true; // Chọn mặc định là "Số lượng"

        }
        private void LoadDataFromDatabase()
        {
            Member = DBHelper.Instance.GetRecord("SELECT ID_khach as [Mã khách], Ho_ten as [Họ và tên], Ma_goi_tap as [Mã gói tập], Ma_HLV as [Mã HLV], Ngay_sinh as [Ngày sinh], So_dien_thoai as [Số điện thoại], Email as [Email], Gioi_tinh as [Giới tính], Ngay_tham_gia as [Ngày tham gia], Dia_chi as [Địa chỉ]  FROM Khach");
            PT = DBHelper.Instance.GetRecord("SELECT Ma_HLV as [Mã PT], Ho_ten as [Họ và tên], Chuyen_mon as [Chuyên môn], Kinh_nghiem as [Kinh nghiệm], Luong as [Lương] FROM Huan_luyen_vien");
            Recep = DBHelper.Instance.GetRecord("SELECT Ma_le_tan as [Mã lễ tân], Ho_ten as [Họ và tên], Chuyen_mon as [Chuyên môn],  Luong as [Lương] FROM Nhan_vien_le_tan");
            Machine = DBHelper.Instance.GetRecord("SELECT Ma_may as [Mã máy],Ten_may as [Tên máy], [Mo_ta] as [Mô tả], [Tinh_trang] as [Tình trạng] FROM May_tap");
            Pack = DBHelper.Instance.GetRecord("SELECT Ma_goi_tap as [Mã gói tập], Ten_goi_tap as [Tên gói tập], Don_gia as [Đơn giá] FROM Goi_tap");
            Invoice = DBHelper.Instance.GetRecord("SELECT Ma_hoa_don as [Mã hóa đơn], Ma_goi_tap as [Mã gói tập], Ma_le_tan as [Mã lễ tân], Ngay_xuat_hoa_don as [Ngày xuất hóa đơn], Ten_khach_hang as [Tên khách hàng], Ten_goi_tap as [Tên gói tập], Thoi_han as [Thời hạn], Ten_HLV as [Tên HLV], Thanh_tien as [Thành tiền], Ten_nhan_vien as [Tên nhân viên] FROM Hoa_don");
            Attend = DBHelper.Instance.GetRecord("SELECT AttendanceID as [Mã điểm danh], ID_khach as [Mã khách], Ho_ten as [Họ và tên], Date as [Ngày] FROM Attendance");
            Account = DBHelper.Instance.GetRecord("SELECT ID_tai_khoan as [Mã tài khoản], Ten_dang_nhap as [Tên đăng nhập], Mat_khau as [Mật khẩu], Loai_nguoi_dung as [Loại người dùng], Ten_nguoi_dung as [Tên người dùng] FROM TAI_KHOAN");
            DGV_Mem.DataSource = Member;
            DGV_PT.DataSource = PT;
            DGV_Recep.DataSource = Recep;
            DGV_Machine.DataSource = Machine;
            DGV_Pack.DataSource = Pack;
            DGV_Invoice.DataSource = Invoice;
            DGV_Attend.DataSource = Attend;
            DGV_Acc.DataSource = Account;
        }
        private void InitializeTabControl()
        {
            tabControlGym.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlGym.SelectedTab == tabMem)
            {
                DGV_Mem.DataSource = Member;
            }
            else if (tabControlGym.SelectedTab == tabPT)
            {
                DGV_PT.DataSource = PT;
            }
            else if (tabControlGym.SelectedTab == tabRecep)
            {
                DGV_Recep.DataSource = Recep;
            }
            else if (tabControlGym.SelectedTab == tabMachine)
            {
                DGV_Machine.DataSource = Machine;
            }
            else if (tabControlGym.SelectedTab == tabInvoice)
            {
                DGV_Pack.DataSource = Invoice;
            }
            else if (tabControlGym.SelectedTab == tabPack)
            {
                DGV_Pack.DataSource = Pack;
            }
            else if (tabControlGym.SelectedTab == tabAttendence)
            {
                DGV_Attend.DataSource = Attend;
            }
            else if (tabControlGym.SelectedTab == tabAccount)
            {
                DGV_Acc.DataSource = Account;
            }
        }
        private void InitializeSortComboBox_Menber()
        {
            Dictionary<string, string> columnMappings = new Dictionary<string, string>
        {
        { "Mã khách", "ID_khach" },
        { "Họ và tên", "Ho_ten" },
        { "Ngày sinh", "Ngay_sinh" },
        { "Số điện thoại", "So_dien_thoai" },
        { "Email", "Email" },
        { "Giới tính", "Gioi_tinh" },
        { "Mã gói tập", "Ma_goi_tap" },
        { "Ngày tham gia", "Ngay_tham_gia" },
        { "Mã HLV", "Ma_HLV" },
        { "Địa chỉ", "Dia_chi" }
        };

            foreach (var column in columnMappings.Keys)
            {
                cbbSort.Items.Add(column);
            }
        }
        private void InitializeSortComboBox_PT()
        {
            Dictionary<string, string> columnMappings_PT = new Dictionary<string, string>
        {
        { "Mã HLV", "Ma_HLV" },
        { "Họ và tên", "Ho_ten" },
        { "Chuyên môn", "Chuyen_mon" },
        { "Kinh nghiệm", "Kinh_nghiem" },
        { "Lương", "Luong" }
        };

            foreach (var column in columnMappings_PT.Keys)
            {
                cbbSort_PT.Items.Add(column);
            }
        }
        private void InitializeSortComboBox_Acc()
        {
            Dictionary<string, string> columnMappings_Acc = new Dictionary<string, string>
        {
        { "Mã tai khoan", "[ID_tai_khoan]" },
        { "Tên đăng nhập", "[Ten_dang_nhap]" },
        { "Mật  khẩu", "[Mat_khau]" },
        { "Kiểu người dùng", "[Loai_nguoi_dung]" },
        { "Tên người dùng", "[Ten_nguoi_dung]" }
        };

            foreach (var column in columnMappings_Acc.Keys)
            {
                cbbSort_Account.Items.Add(column);
            }
        }
        private void InitializeSortComboBox_Attend()
        {
            Dictionary<string, string> columnMappings_Attend = new Dictionary<string, string>
        {
        { "Mã điểm danh", "[AttendanceID]" },
        { "Mã khách", "[ID_khach]" },
        { "Tên khách", "[Ho_ten]" },
        { "Ngày", "[Date]" }
        };

            foreach (var column in columnMappings_Attend.Keys)
            {
                cbbSort_Attend.Items.Add(column);
            }
        }
        private void InitializeSortComboBox_Recep()
        {
            Dictionary<string, string> columnMappings_Recep = new Dictionary<string, string>
        {
        { "Mã HLV", "Ma_HLV" },
        { "Họ và tên", "Ho_ten" },
        { "Chuyên môn", "Chuyen_mon" },
        { "Lương", "Luong" }
        };

            foreach (var column in columnMappings_Recep.Keys)
            {
                cbbSort_Recep.Items.Add(column);
            }
        }
        private void InitializeSortComboBox_Pack()
        {
            Dictionary<string, string> columnMappings_Pack = new Dictionary<string, string>
    {
        { "Mã gói tập", "Ma_goi_tap" },
        { "Tên gói tập", "Ten_goi_tap" },
        { "Đơn giá", "Don_gia" }
    };

            foreach (var column in columnMappings_Pack.Keys)
            {
                cbbSort_Pack.Items.Add(column);
            }
        }


        //
        //Member
        //
        private void btn_Mem_Add_Click(object sender, EventArgs e)
        {
            inforMember addmen = new inforMember();
            addmen.ShowDialog(); // Sử dụng ShowDialog để đảm bảo form mới hiển thị và chờ đợi cho đến khi nó đóng lại
            LoadDataFromDatabase();
        }

        private void btn_Mem_Update_Click(object sender, EventArgs e)
        {
            if (DGV_Mem.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DGV_Mem.SelectedRows[0];
                if (selectedRow.Cells["ID_khach"].Value != null)
                {
                    // Lấy ID_khach của dòng được chọn
                    int khachId = Convert.ToInt32(DGV_Mem.SelectedRows[0].Cells["ID_khach"].Value);

                    // Mở form inforMember với ID_khach để chỉnh sửa thông tin
                  //  inforMember editMemberForm = new inforMember(khachId);
                   // editMemberForm.ShowDialog();

                    // Sau khi đóng form, tải lại dữ liệu để hiển thị các thay đổi mới
                    LoadDataFromDatabase();
                }
                else
                {
                    MessageBox.Show("Dòng được chọn không có thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Mem_Del_Click(object sender, EventArgs e)
        {
            if (DGV_Mem.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = DGV_Mem.SelectedRows[0];

                // Lấy khóa chính của dòng được chọn
                string maMem = selectedRow.Cells["Mã khách"].Value.ToString();

                // Xác nhận việc xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Thực hiện truy vấn SQL DELETE để xóa dữ liệu từ bảng cơ sở dữ liệu
                    string query = "DELETE FROM Khach WHERE ID_khach = @ID_khach";
                    SqlParameter param = new SqlParameter("@ID_khach", maMem);
                    DBHelper.Instance.ExecuteDB(query, param);

                    // Cập nhật lại nguồn dữ liệu của DataGridView để hiển thị các thay đổi mới
                    LoadDataFromDatabase();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trước khi thực hiện xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAttend_Click(object sender, EventArgs e)
        {
            if (DGV_Mem.SelectedRows.Count > 0)
            {
                string selectedMemberID = DGV_Mem.SelectedRows[0].Cells["Mã khách"].Value.ToString();
                string selectedMemberName = DGV_Mem.SelectedRows[0].Cells["Họ và tên"].Value.ToString();

                DateTime currentDate = DateTime.Now;

                string query = "INSERT INTO Attendance (ID_khach, Ho_ten, Date) VALUES (@ID_khach, @Ho_ten, @Date)";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@ID_khach", selectedMemberID),
            new SqlParameter("@Ho_ten", selectedMemberName),
            new SqlParameter("@Date", currentDate)
                };

                try
                {
                    DBHelper.Instance.ExecuteDB(query, parameters);
                    MessageBox.Show("Điểm danh thành công!");
                    LoadDataFromDatabase();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi điểm danh: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thành viên để điểm danh.");
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Bắt đầu tạo truy vấn SQL tìm kiếm
            string query = @"
            SELECT * 
            FROM Khach
            WHERE 
                 ID_khach LIKE @Keyword OR
                 Ho_ten LIKE @Keyword OR 
                 Dia_chi LIKE @Keyword OR 
                 Gioi_tinh LIKE @Keyword OR 
                 So_dien_thoai LIKE @Keyword OR 
                 Email LIKE @Keyword OR 
                 Ma_goi_tap LIKE @Keyword OR 
                 Ma_HLV LIKE @Keyword";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
            new SqlParameter("@Keyword", "%" + keyword + "%")
            };

            // Kiểm tra xem từ khóa có phải là một ngày hợp lệ hay không
            if (DateTime.TryParse(keyword, out DateTime dateValue))
            {
                query += " OR CONVERT(date, Ngay_sinh) = @DateValue OR CONVERT(date, Ngay_tham_gia) = @DateValue";
                parameters.Add(new SqlParameter("@DateValue", dateValue));
            }
            // Kiểm tra xem từ khóa có phải là một tháng hợp lệ hay không
            else if (int.TryParse(keyword, out int month) && month >= 1 && month <= 12)
            {
                query += " OR MONTH(Ngay_sinh) = @Month OR MONTH(Ngay_tham_gia) = @Month";
                parameters.Add(new SqlParameter("@Month", month));
            }
            // Kiểm tra xem từ khóa có phải là một năm hợp lệ hay không
            else if (int.TryParse(keyword, out int year))
            {
                query += " OR YEAR(Ngay_sinh) = @Year OR YEAR(Ngay_tham_gia) = @Year";
                parameters.Add(new SqlParameter("@Year", year));
            }

            try
            {
                DataTable searchResult = DBHelper.Instance.GetRecord(query, parameters.ToArray());
                DGV_Mem.DataSource = searchResult;

                if (searchResult.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            string selectedColumn = cbbSort.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedColumn))
            {
                MessageBox.Show("Vui lòng chọn cột để sắp xếp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Tạo từ điển ánh xạ giữa tên cột hiển thị và tên cột trong cơ sở dữ liệu
            Dictionary<string, string> columnMappings = new Dictionary<string, string>
        {
        { "Mã khách", "ID_khach" },
        { "Họ và tên", "Ho_ten" },
        { "Ngày sinh", "Ngay_sinh" },
        { "Số điện thoại", "So_dien_thoai" },
        { "Email", "Email" },
        { "Giới tính", "Gioi_tinh" },
        { "Mã gói tập", "Ma_goi_tap" },
        { "Ngày tham gia", "Ngay_tham_gia" },
        { "Mã HLV", "Ma_HLV" },
        { "Địa chỉ", "Dia_chi" }
        };

            if (!columnMappings.ContainsKey(selectedColumn))
            {
                MessageBox.Show("Cột được chọn không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string actualColumnName = columnMappings[selectedColumn];

            string query = $@"
            SELECT ID_khach as [Mã khách], Ho_ten as [Họ và tên], Ngay_sinh as [Ngày sinh], So_dien_thoai as [Số điện thoại], Email as [Email], Gioi_tinh as [Giới tính], Ma_goi_tap as [Mã gói tập], Ngay_tham_gia as [Ngày tham gia], Ma_HLV as [Mã HLV], Dia_chi as [Địa chỉ] 
            FROM Khach
            ORDER BY {actualColumnName}";

            try
            {
                DataTable sortedResult = DBHelper.Instance.GetRecord(query);
                DGV_Mem.DataSource = sortedResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_soluongkhach_Click(object sender, EventArgs e)
        {
            int numberOfMembers = Member.Rows.Count;
            MessageBox.Show("Số lượng khách hàng: " + numberOfMembers.ToString(), "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //
        //Receptionist
        //
        private void btn_add_Recep_Click(object sender, EventArgs e)
        {
            inforRecep addRecep = new inforRecep();
            addRecep.ShowDialog();
            LoadDataFromDatabase();
        }

        private void btn_update_Recep_Click(object sender, EventArgs e)
        {
            if (DGV_Recep.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DGV_Recep.SelectedRows[0];
                if (selectedRow.Cells["Mã lễ tân"].Value != null)
                {

                    // Lấy ID_khach của dòng được chọn
                    string LTId = DGV_Recep.SelectedRows[0].Cells["Mã lễ tân"].Value.ToString();

                    // Mở form inforMember với ID_khach để chỉnh sửa thông tin
                    inforRecep editRecepForm = new inforRecep(LTId);
                    editRecepForm.ShowDialog();

                    // Sau khi đóng form, tải lại dữ liệu để hiển thị các thay đổi mới
                    LoadDataFromDatabase();
                }
                else
                {
                    MessageBox.Show("Dòng được chọn không có thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một lễ tân để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Delete_Recep_Click(object sender, EventArgs e)
        {
            if (DGV_Recep.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = DGV_Recep.SelectedRows[0];

                // Lấy khóa chính của dòng được chọn
                string maLT = selectedRow.Cells["Mã lễ tân"].Value.ToString();

                // Xác nhận việc xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Thực hiện truy vấn SQL DELETE để xóa dữ liệu từ bảng cơ sở dữ liệu
                    string query = "DELETE FROM Nhan_vien_le_tan WHERE Ma_le_tan = @Ma_le_tan";
                    SqlParameter param = new SqlParameter("@Ma_le_tan", maLT);
                    DBHelper.Instance.ExecuteDB(query, param);

                    // Cập nhật lại nguồn dữ liệu của DataGridView để hiển thị các thay đổi mới
                    LoadDataFromDatabase();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trước khi thực hiện xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Recep_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch_Recep.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Bắt đầu tạo truy vấn SQL tìm kiếm
            string query = @"
            SELECT * 
            FROM Nhan_vien_le_tan
            WHERE 
                 Ma_le_tan LIKE @Keyword OR
                 Ho_ten LIKE @Keyword OR 
                 Chuyen_mon LIKE @Keyword OR 
                 Luong LIKE @Keyword "
                ;

            List<SqlParameter> parameters = new List<SqlParameter>
            {
            new SqlParameter("@Keyword", "%" + keyword + "%")
            };

            try
            {
                DataTable searchResult = DBHelper.Instance.GetRecord(query, parameters.ToArray());
                DGV_Recep.DataSource = searchResult;

                if (searchResult.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSort_Recep_Click(object sender, EventArgs e)
        {
            string selectedColumn = cbbSort_Recep.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedColumn))
            {
                MessageBox.Show("Vui lòng chọn cột để sắp xếp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Dictionary<string, string> columnMappings_Recep = new Dictionary<string, string>
            {
                { "Mã lễ tân", "Ma_le_tan" },
                { "Họ và tên", "Ho_ten" },
                { "Chuyên môn", "Chuyen_mon" },
                { "Lương", "Luong" }
            };

            if (!columnMappings_Recep.ContainsKey(selectedColumn))
            {
                MessageBox.Show("Cột được chọn không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string actualColumnName = columnMappings_Recep[selectedColumn];

            string query = $@"
            SELECT Ma_le_tan as [Mã lễ tân], Ho_ten as [Họ và tên], Chuyen_mon as [Chuyên môn], Luong as [Lương]
            FROM Nhan_vien_le_tan
            ORDER BY {actualColumnName}";

            try
            {
                DataTable sortedResult = DBHelper.Instance.GetRecord(query);
                DGV_Recep.DataSource = sortedResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        //PT
        //
        private void addPT_Click(object sender, EventArgs e)
        {
            inforPT addPT = new inforPT();
            addPT.ShowDialog();
            LoadDataFromDatabase();
        }

        private void btn_PT_Update_Click(object sender, EventArgs e)
        {
            if (DGV_PT.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DGV_PT.SelectedRows[0];
                if (selectedRow.Cells["Mã PT"].Value != null)
                {

                    // Lấy ID_khach của dòng được chọn
                    string HLVId = DGV_PT.SelectedRows[0].Cells["Mã PT"].Value.ToString();

                    // Mở form inforMember với ID_khach để chỉnh sửa thông tin
                    inforPT editPTForm = new inforPT(HLVId);
                    editPTForm.ShowDialog();

                    // Sau khi đóng form, tải lại dữ liệu để hiển thị các thay đổi mới
                    LoadDataFromDatabase();
                }
                else
                {
                    MessageBox.Show("Dòng được chọn không có thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một huấn luyện viên để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_PT_del_Click(object sender, EventArgs e)
        {
            if (DGV_PT.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = DGV_PT.SelectedRows[0];

                // Lấy khóa chính của dòng được chọn
                string maPT = selectedRow.Cells["Mã PT"].Value.ToString();

                // Xác nhận việc xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Thực hiện truy vấn SQL DELETE để xóa dữ liệu từ bảng cơ sở dữ liệu
                    string query = "DELETE FROM Huan_luyen_vien WHERE Ma_HLV = @Ma_HLV";
                    SqlParameter param = new SqlParameter("@Ma_HLV", maPT);
                    DBHelper.Instance.ExecuteDB(query, param);

                    // Cập nhật lại nguồn dữ liệu của DataGridView để hiển thị các thay đổi mới
                    LoadDataFromDatabase();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trước khi thực hiện xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_PT_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch_PT.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Bắt đầu tạo truy vấn SQL tìm kiếm
            string query = @"
            SELECT * 
            FROM Huan_luyen_vien
            WHERE 
                 Ma_HLV LIKE @Keyword OR
                 Ho_ten LIKE @Keyword OR 
                 Chuyen_mon LIKE @Keyword OR 
                 Kinh_nghiem LIKE @Keyword OR
                 Luong LIKE @Keyword "
                ;

            List<SqlParameter> parameters = new List<SqlParameter>
            {
            new SqlParameter("@Keyword", "%" + keyword + "%")
            };

            try
            {
                DataTable searchResult = DBHelper.Instance.GetRecord(query, parameters.ToArray());
                DGV_PT.DataSource = searchResult;

                if (searchResult.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnSort_PT_Click(object sender, EventArgs e)
        {
            string selectedColumn = cbbSort_PT.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedColumn))
            {
                MessageBox.Show("Vui lòng chọn cột để sắp xếp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Tạo từ điển ánh xạ giữa tên cột hiển thị và tên cột trong cơ sở dữ liệu
            Dictionary<string, string> columnMappings_PT = new Dictionary<string, string>
        {
        { "Mã HLV", "Ma_HLV" },
        { "Họ và tên", "Ho_ten" },
        { "Chuyên môn", "Chuyen_mon" },
        { "Kinh nghiệm", "Kinh_nghiem" },
        { "Lương", "Luong" }
        };

            if (!columnMappings_PT.ContainsKey(selectedColumn))
            {
                MessageBox.Show("Cột được chọn không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string actualColumnName = columnMappings_PT[selectedColumn];

            string query = $@"
            SELECT Ma_HLV as [Mã HLV], Ho_ten as [Họ và tên], Chuyen_mon as [Chuyên môn], Kinh_nghiem as [Kinh nghiệm], Luong as [Lương]
            FROM Huan_luyen_vien
            ORDER BY {actualColumnName}";

            try
            {
                DataTable sortedResult = DBHelper.Instance.GetRecord(query);
                DGV_PT.DataSource = sortedResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        //Account
        //
        private void btn_add_acc_Click(object sender, EventArgs e)
        {

        }

        

        private void btn_edit_acc_Click(object sender, EventArgs e)
        {

        }

       

        private void btn_del_acc_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Account_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch_Account.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Bắt đầu tạo truy vấn SQL tìm kiếm
            string query = @"
            SELECT * 
            FROM [TAI_KHOAN]
            WHERE 
                 ID_tai_khoan LIKE @Keyword OR
                 Ten_dang_nhap LIKE @Keyword OR 
                 Mat_khau LIKE @Keyword OR 
                 Loai_nguoi_dung LIKE @Keyword OR 
                 Ten_nguoi_dung LIKE @Keyword "
                ;

            List<SqlParameter> parameters = new List<SqlParameter>
            {
            new SqlParameter("@Keyword", "%" + keyword + "%")
            };

            try
            {
                DataTable searchResult = DBHelper.Instance.GetRecord(query, parameters.ToArray());
                DGV_Acc.DataSource = searchResult;

                if (searchResult.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSort_Account_Click(object sender, EventArgs e)
        {
            string selectedColumn = cbbSort_Account.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedColumn))
            {
                MessageBox.Show("Vui lòng chọn cột để sắp xếp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Dictionary<string, string> columnMappings_Acc = new Dictionary<string, string>
        {
          { "Mã tai khoan", "[ID_tai_khoan]" },
        { "Tên đăng nhập", "[Ten_dang_nhap]" },
        { "Mật  khẩu", "[Mat_khau]" },
        { "Kiểu người dùng", "[Loai_nguoi_dung]" },
        { "Tên người dùng", "[Ten_nguoi_dung]" }
        };

            if (!columnMappings_Acc.ContainsKey(selectedColumn))
            {
                MessageBox.Show("Cột được chọn không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string actualColumnName = columnMappings_Acc[selectedColumn];
            string query = $@"
        SELECT ID_tai_khoan as [Mã tai khoan], Ten_dang_nhap as [Tên đăng nhập], Mat_khau as [Mật  khẩu], Loai_nguoi_dung as [Kiểu người dùng], Ten_nguoi_dung as [Tên người dùng]
        FROM [TAI_KHOAN]
        ORDER BY {actualColumnName}";

            try
            {
                DataTable sortedResult = DBHelper.Instance.GetRecord(query);
                DGV_Acc.DataSource = sortedResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        //Statistics
        //
        private void tabStatistics_Click(object sender, EventArgs e)
        {
            string type = comboBoxStatisticsType.SelectedItem.ToString();
            LoadSalesStatistics(type);
        }
        private void LoadSalesStatistics(string type)
        {
            string dataType = radioButtonQuantity.Checked ? "Số lượng" : "Doanh thu";
            DataTable dt = DBHelper.Instance.GetSalesStatistics(type); // Sử dụng phương thức GetSalesStatistics hiện tại
            dataGridViewStatistics.DataSource = dt;

            // Hiển thị dữ liệu lên Chart
            chartStatistics.Series.Clear();
            string yValueMember = dataType == "Số lượng" ? "So_luong_goi_tap_ban" : "Tong_tien_thu_ve";

            if (type == "Tháng")
            {
                foreach (DataRow row in dt.Rows)
                {
                    string yearMonth = $"{row["Nam"]}-{row["Thang"]:00}"; // Format Tháng thành hai chữ số (01, 02, ..., 12)
                    string seriesName = $"{row["Ten_goi_tap"]}";

                    Series series = chartStatistics.Series.FindByName(seriesName);
                    if (series == null)
                    {
                        series = new Series(seriesName);
                        series.ChartType = SeriesChartType.Column;
                        series.XValueType = ChartValueType.String;
                        series.IsValueShownAsLabel = true;
                        chartStatistics.Series.Add(series);
                    }

                    series.Points.AddXY(yearMonth, row[yValueMember]);
                }

            }
            else // Năm
            {
                foreach (DataRow row in dt.Rows)
                {
                    string year = row["Nam"].ToString();
                    string seriesName = $"{row["Ten_goi_tap"]}";

                    Series series = chartStatistics.Series.FindByName(seriesName);
                    if (series == null)
                    {
                        series = new Series(seriesName);
                        series.ChartType = SeriesChartType.Column;
                        series.XValueType = ChartValueType.String;
                        series.IsValueShownAsLabel = true;
                        chartStatistics.Series.Add(series);
                    }

                    series.Points.AddXY(year, row[yValueMember]);
                }

            }

            // Cập nhật lại trục y để thể hiện giá trị cao nhất
            chartStatistics.ChartAreas[0].RecalculateAxesScale();
        }

        

        private void buttonGetStatistics_Click(object sender, EventArgs e)
        {
            string type = comboBoxStatisticsType.SelectedItem.ToString();
            LoadSalesStatistics(type);
        }
        //
        //Package
        //
        private void btnSearch_Pack_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch_Pack.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string query = @"
    SELECT * 
    FROM Goi_tap
    WHERE 
         Ma_goi_tap LIKE @Keyword OR
         Ten_goi_tap LIKE @Keyword OR 
         Don_gia LIKE @Keyword";

            List<SqlParameter> parameters = new List<SqlParameter>
    {
        new SqlParameter("@Keyword", "%" + keyword + "%")
    };

            try
            {
                DataTable searchResult = DBHelper.Instance.GetRecord(query, parameters.ToArray());
                DGV_Pack.DataSource = searchResult;

                if (searchResult.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSort_Pack_Click(object sender, EventArgs e)
        {
            string selectedColumn = cbbSort_Pack.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedColumn))
            {
                MessageBox.Show("Vui lòng chọn cột để sắp xếp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Dictionary<string, string> columnMappings_Pack = new Dictionary<string, string>
        {
            { "Mã gói tập", "Ma_goi_tap" },
            { "Tên gói tập", "Ten_goi_tap" },
            { "Đơn giá", "Don_gia" }
        };

            if (!columnMappings_Pack.ContainsKey(selectedColumn))
            {
                MessageBox.Show("Cột được chọn không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string actualColumnName = columnMappings_Pack[selectedColumn];
            string query = $@"
        SELECT Ma_goi_tap as [Mã gói tập], Ten_goi_tap as [Tên gói tập], Don_gia as [Đơn giá]
        FROM Goi_tap
        ORDER BY {actualColumnName}";

            try
            {
                DataTable sortedResult = DBHelper.Instance.GetRecord(query);
                DGV_Pack.DataSource = sortedResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_add_pack_Click(object sender, EventArgs e)
        {
            inforPackage addPack = new inforPackage();
            addPack.ShowDialog();
            LoadDataFromDatabase();
        }

        private void btn_edit_pack_Click(object sender, EventArgs e)
        {
            if (DGV_Pack.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DGV_Pack.SelectedRows[0];
                if (selectedRow.Cells["Mã gói tập"].Value != null)
                {

                    // Lấy ID_khach của dòng được chọn
                    string HLVId = DGV_Pack.SelectedRows[0].Cells["Mã gói tập"].Value.ToString();

                    // Mở form inforMember với ID_khach để chỉnh sửa thông tin
                    inforPackage editPTForm = new inforPackage(HLVId);
                    editPTForm.ShowDialog();

                    // Sau khi đóng form, tải lại dữ liệu để hiển thị các thay đổi mới
                    LoadDataFromDatabase();
                }
                else
                {
                    MessageBox.Show("Dòng được chọn không có thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một gói để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btn_del_pack_Click(object sender, EventArgs e)
        {
            if (DGV_Pack.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = DGV_Pack.SelectedRows[0];

                // Lấy khóa chính của dòng được chọn
                string maPT = selectedRow.Cells["Mã gói tập"].Value.ToString();

                // Xác nhận việc xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Thực hiện truy vấn SQL DELETE để xóa dữ liệu từ bảng cơ sở dữ liệu
                    string query = "DELETE FROM Goi_tap WHERE  Ma_goi_tap = @Ma_goi_tap";
                    SqlParameter param = new SqlParameter("@Ma_goi_tap", maPT);
                    DBHelper.Instance.ExecuteDB(query, param);

                    // Cập nhật lại nguồn dữ liệu của DataGridView để hiển thị các thay đổi mới
                    LoadDataFromDatabase();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trước khi thực hiện xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //
        //Machine
        //


        private void btnSearch_Machine_Click_1(object sender, EventArgs e)
        {
            string keyword = txtSearch_Machine.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string query = @"
    SELECT * 
    FROM [May_tap]
    WHERE 
         Ma_may LIKE @Keyword OR
         Ten_may LIKE @Keyword OR
         Mo_ta LIKE @Keyword OR
         Tinh_trang LIKE @Keyword";

            List<SqlParameter> parameters = new List<SqlParameter>
    {
        new SqlParameter("@Keyword", "%" + keyword + "%")
    };

            try
            {
                DataTable searchResult = DBHelper.Instance.GetRecord(query, parameters.ToArray());
                DGV_Machine.DataSource = searchResult;

                if (searchResult.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_add_machine_Click(object sender, EventArgs e)
        {

        }

        private void btn_edit_machine_Click(object sender, EventArgs e)
        {

        }

        private void btn_del_machine_Click(object sender, EventArgs e)
        {

        }
        //
        //Attend
        //
        private void tabAttendence_Click(object sender, EventArgs e)
        {

        }
        private void btnSearch_Attend_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch_Attend.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string query = @"
    SELECT * 
    FROM [Attendance]
    WHERE 
         AttendanceID LIKE @Keyword OR
         ID_khach LIKE @Keyword OR
         Ho_ten LIKE @Keyword OR
         Date LIKE @Keyword";

            List<SqlParameter> parameters = new List<SqlParameter>
    {
        new SqlParameter("@Keyword", "%" + keyword + "%")
    };

            try
            {
                DataTable searchResult = DBHelper.Instance.GetRecord(query, parameters.ToArray());
                DGV_Attend.DataSource = searchResult;

                if (searchResult.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSort_Attend_Click(object sender, EventArgs e)
        {
            string selectedColumn = cbbSort_Attend.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedColumn))
            {
                MessageBox.Show("Vui lòng chọn cột để sắp xếp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Dictionary<string, string> columnMappings_Attend = new Dictionary<string, string>
        {
             { "Mã điểm danh", "[AttendanceID]" },
             { "Mã khách", "[ID_khach]" },
             { "Tên khách", "[Ho_ten]" },
             { "Ngày", "[Date]" }
        };

            if (!columnMappings_Attend.ContainsKey(selectedColumn))
            {
                MessageBox.Show("Cột được chọn không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string actualColumnName = columnMappings_Attend[selectedColumn];
            string query = $@"
        SELECT AttendanceID as [Mã điểm danh], ID_khach as [Mã khách], Ho_ten as [Tên khách], Date as [Ngày]
        FROM Attendance
        ORDER BY {actualColumnName}";

            try
            {
                DataTable sortedResult = DBHelper.Instance.GetRecord(query);
                DGV_Attend.DataSource = sortedResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        //
        //
        private void tabLogOut_Enter(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác nhận đăng xuất ?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Home home = new Home();
                this.Hide();
                home.Show();
            }
        }
    }
}



