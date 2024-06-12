using System.Drawing;
using System.Windows.Forms;

namespace PBL3_fi
{
    partial class inforInvoice
    {
        private System.ComponentModel.IContainer components = null;
        private DateTimePicker dtpNgayXuatHoaDon;
        private TextBox txtTenKhachHang;
        private DateTimePicker dtpThoiHan;
        private TextBox txtThanhTien;
        private Button btnPrint_Invoice;
        private Button btnCancel_Invoice;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(inforInvoice));
            this.dtpNgayXuatHoaDon = new System.Windows.Forms.DateTimePicker();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.dtpThoiHan = new System.Windows.Forms.DateTimePicker();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.btnPrint_Invoice = new System.Windows.Forms.Button();
            this.btnCancel_Invoice = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTenLeTan = new System.Windows.Forms.TextBox();
            this.txtPT = new System.Windows.Forms.TextBox();
            this.txtTenGoiTap = new System.Windows.Forms.TextBox();
            this.txtMaHoaDon = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpNgayXuatHoaDon
            // 
            this.dtpNgayXuatHoaDon.Location = new System.Drawing.Point(515, 186);
            this.dtpNgayXuatHoaDon.Name = "dtpNgayXuatHoaDon";
            this.dtpNgayXuatHoaDon.Size = new System.Drawing.Size(200, 26);
            this.dtpNgayXuatHoaDon.TabIndex = 3;
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Location = new System.Drawing.Point(127, 267);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.Size = new System.Drawing.Size(200, 26);
            this.txtTenKhachHang.TabIndex = 4;
            // 
            // dtpThoiHan
            // 
            this.dtpThoiHan.Location = new System.Drawing.Point(515, 267);
            this.dtpThoiHan.Name = "dtpThoiHan";
            this.dtpThoiHan.Size = new System.Drawing.Size(200, 26);
            this.dtpThoiHan.TabIndex = 6;
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Location = new System.Drawing.Point(333, 429);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.Size = new System.Drawing.Size(157, 26);
            this.txtThanhTien.TabIndex = 8;
            // 
            // btnPrint_Invoice
            // 
            this.btnPrint_Invoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPrint_Invoice.Location = new System.Drawing.Point(279, 503);
            this.btnPrint_Invoice.Name = "btnPrint_Invoice";
            this.btnPrint_Invoice.Size = new System.Drawing.Size(75, 37);
            this.btnPrint_Invoice.TabIndex = 9;
            this.btnPrint_Invoice.Text = "Print";
            this.btnPrint_Invoice.UseVisualStyleBackColor = false;
            this.btnPrint_Invoice.Click += new System.EventHandler(this.btnPrint_Invoice_Click);
            // 
            // btnCancel_Invoice
            // 
            this.btnCancel_Invoice.Location = new System.Drawing.Point(434, 503);
            this.btnCancel_Invoice.Name = "btnCancel_Invoice";
            this.btnCancel_Invoice.Size = new System.Drawing.Size(75, 37);
            this.btnCancel_Invoice.TabIndex = 10;
            this.btnCancel_Invoice.Text = "Cancel";
            this.btnCancel_Invoice.UseVisualStyleBackColor = true;
            this.btnCancel_Invoice.Click += new System.EventHandler(this.btnCancel_Invoice_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Tên khách:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Lễ tân:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Gói tập:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(384, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Ngày:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(384, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Huấn luyên viên:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(384, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Thời hạn:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(239, 429);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Thành tiền:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(487, 432);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "VND";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::PBL3_fi.Properties.Resources._344_Fitness_Gym_Logo_removebg_preview;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(366, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label9.Location = new System.Drawing.Point(346, 63);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 31);
            this.label9.TabIndex = 36;
            this.label9.Text = "NVGym";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTenLeTan
            // 
            this.txtTenLeTan.Location = new System.Drawing.Point(127, 184);
            this.txtTenLeTan.Name = "txtTenLeTan";
            this.txtTenLeTan.Size = new System.Drawing.Size(200, 26);
            this.txtTenLeTan.TabIndex = 38;
            // 
            // txtPT
            // 
            this.txtPT.Location = new System.Drawing.Point(515, 341);
            this.txtPT.Name = "txtPT";
            this.txtPT.Size = new System.Drawing.Size(200, 26);
            this.txtPT.TabIndex = 39;
            // 
            // txtTenGoiTap
            // 
            this.txtTenGoiTap.Location = new System.Drawing.Point(127, 343);
            this.txtTenGoiTap.Name = "txtTenGoiTap";
            this.txtTenGoiTap.Size = new System.Drawing.Size(200, 26);
            this.txtTenGoiTap.TabIndex = 40;
            // 
            // txtMaHoaDon
            // 
            this.txtMaHoaDon.Location = new System.Drawing.Point(333, 117);
            this.txtMaHoaDon.Name = "txtMaHoaDon";
            this.txtMaHoaDon.Size = new System.Drawing.Size(157, 26);
            this.txtMaHoaDon.TabIndex = 41;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(226, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 20);
            this.label10.TabIndex = 42;
            this.label10.Text = "Mã hóa  đơn:";
            // 
            // inforInvoice
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(738, 572);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMaHoaDon);
            this.Controls.Add(this.txtTenGoiTap);
            this.Controls.Add(this.txtPT);
            this.Controls.Add(this.txtTenLeTan);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpNgayXuatHoaDon);
            this.Controls.Add(this.txtTenKhachHang);
            this.Controls.Add(this.dtpThoiHan);
            this.Controls.Add(this.txtThanhTien);
            this.Controls.Add(this.btnPrint_Invoice);
            this.Controls.Add(this.btnCancel_Invoice);
            this.DoubleBuffered = true;
            this.Name = "inforInvoice";
            this.Text = "Thông tin hóa đơn";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private PictureBox pictureBox1;
        private Label label9;
        private TextBox txtTenLeTan;
        private TextBox txtPT;
        private TextBox txtTenGoiTap;
        private TextBox txtMaHoaDon;
        private Label label10;
    }
}