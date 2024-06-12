using System.Drawing;
using System.Windows.Forms;

namespace PBL3_fi
{
    partial class inforPT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLuong = new System.Windows.Forms.TextBox();
            this.txtChuyenmon = new System.Windows.Forms.RichTextBox();
            this.txtKinhnghiem = new System.Windows.Forms.RichTextBox();
            this.btcancel = new System.Windows.Forms.Button();
            this.bt_savePT = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(64, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ tên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(418, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mức lương:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(19, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Kinh nghiệm:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(418, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Chuyên môn:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(153, 162);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(194, 31);
            this.txtName.TabIndex = 5;
            // 
            // txtLuong
            // 
            this.txtLuong.Location = new System.Drawing.Point(552, 265);
            this.txtLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLuong.Name = "txtLuong";
            this.txtLuong.Size = new System.Drawing.Size(194, 31);
            this.txtLuong.TabIndex = 7;
            // 
            // txtChuyenmon
            // 
            this.txtChuyenmon.Location = new System.Drawing.Point(552, 162);
            this.txtChuyenmon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtChuyenmon.Name = "txtChuyenmon";
            this.txtChuyenmon.Size = new System.Drawing.Size(193, 72);
            this.txtChuyenmon.TabIndex = 9;
            this.txtChuyenmon.Text = "";
            // 
            // txtKinhnghiem
            // 
            this.txtKinhnghiem.Location = new System.Drawing.Point(153, 265);
            this.txtKinhnghiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtKinhnghiem.Name = "txtKinhnghiem";
            this.txtKinhnghiem.Size = new System.Drawing.Size(193, 35);
            this.txtKinhnghiem.TabIndex = 10;
            this.txtKinhnghiem.Text = "";
            // 
            // btcancel
            // 
            this.btcancel.Location = new System.Drawing.Point(458, 392);
            this.btcancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btcancel.Name = "btcancel";
            this.btcancel.Size = new System.Drawing.Size(101, 45);
            this.btcancel.TabIndex = 28;
            this.btcancel.Text = "Cancel";
            this.btcancel.UseVisualStyleBackColor = true;
            this.btcancel.Click += new System.EventHandler(this.btcancel_Click);
            // 
            // bt_savePT
            // 
            this.bt_savePT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bt_savePT.Location = new System.Drawing.Point(236, 392);
            this.bt_savePT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_savePT.Name = "bt_savePT";
            this.bt_savePT.Size = new System.Drawing.Size(101, 45);
            this.bt_savePT.TabIndex = 27;
            this.bt_savePT.Text = "Save";
            this.bt_savePT.UseVisualStyleBackColor = false;
            this.bt_savePT.Click += new System.EventHandler(this.bt_savePT_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = global::PBL3_fi.Properties.Resources._344_Fitness_Gym_Logo_removebg_preview;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(367, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(74, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Lucida Handwriting", 14F);
            this.label8.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label8.Location = new System.Drawing.Point(344, 76);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 36);
            this.label8.TabIndex = 36;
            this.label8.Text = "NVGym";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(752, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 25);
            this.label3.TabIndex = 38;
            this.label3.Text = "VND";
            // 
            // inforPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PBL3_fi.Properties.Resources.hand_painted_watercolor_abstract_background_150556667;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(831, 494);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btcancel);
            this.Controls.Add(this.bt_savePT);
            this.Controls.Add(this.txtKinhnghiem);
            this.Controls.Add(this.txtChuyenmon);
            this.Controls.Add(this.txtLuong);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "inforPT";
            this.Text = "Thông tin PT";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private TextBox txtName;
        private TextBox txtLuong;
        private RichTextBox txtChuyenmon;
        private RichTextBox txtKinhnghiem;
        private Button btcancel;
        private Button bt_savePT;
        private PictureBox pictureBox1;
        private Label label8;
        private Label label3;
    }
}