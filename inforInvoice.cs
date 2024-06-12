using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3_fi
{
    public partial class inforInvoice : Form
    {
        private DateTime _ngayXuatHoaDon;
        private string _tenKhachHang;
        private DateTime _thoiHan;
        private float _thanhTien;
        private string _tenLeTan;
        private string _tenPT;
        private string _tenGoiTap;
        private string _maHoaDon;
        private string _soDienThoai;
        private string _diaChi;
        public inforInvoice(DateTime ngayXuatHoaDon, string tenKhachHang, DateTime thoiHan, float thanhTien, string tenLeTan, string tenPT, string tenGoiTap, string maHoaDon, string soDienThoai, string diaChi)
        {
            InitializeComponent();

            // Set values to the controls
            dtpNgayXuatHoaDon.Value = ngayXuatHoaDon;
            txtTenKhachHang.Text = tenKhachHang;
            dtpThoiHan.Value = thoiHan;
            txtThanhTien.Text = thanhTien.ToString();
            txtTenLeTan.Text = tenLeTan;
            txtPT.Text = tenPT;
            txtTenGoiTap.Text = tenGoiTap;
            txtMaHoaDon.Text = maHoaDon;

            // Set values to the private variables
            _ngayXuatHoaDon = ngayXuatHoaDon;
            _tenKhachHang = tenKhachHang;
            _thoiHan = thoiHan;
            _thanhTien = thanhTien;
            _tenLeTan = tenLeTan;
            _tenPT = tenPT;
            _tenGoiTap = tenGoiTap;
            _maHoaDon = maHoaDon;
            _soDienThoai = soDienThoai;
            _diaChi = diaChi;
        }

        private void btnPrint_Invoice_Click(object sender, EventArgs e)
        {
            SaveInvoiceToFile();
        }
        private void SaveInvoiceToFile()
        {
            // Create a string with the invoice information
            string invoiceContent =
$@"                      NVGYM CENTER

                        HÓA ĐƠN

Mã hóa đơn: {_maHoaDon}

Tên nhân viên: {_tenLeTan,-30} Ngày: {_ngayXuatHoaDon:dd/MM/yyyy}

Tên khách hàng: {_tenKhachHang}

Số điện thoại: {_soDienThoai}

Địa chỉ: {_diaChi}

Gói tập: {_tenGoiTap,-30} Thời hạn: {_thoiHan:dd/MM/yyyy}

Tên PT: {_tenPT}

-----------------------------------------

Thành tiền: {_thanhTien} VND
";

            MessageBox.Show(invoiceContent, "Hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);


            // Specify the file path on E:\Notepad
            string folderPath = @"E:\Notepad";
            string filePath = Path.Combine(folderPath, "Invoice.txt");

            try
            {
                // Ensure the directory exists
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Write the content to the file
                File.WriteAllText(filePath, invoiceContent);
                MessageBox.Show("Invoice saved successfully");
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving invoice: {ex.Message}");
            }
        }


        private void btnCancel_Invoice_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
