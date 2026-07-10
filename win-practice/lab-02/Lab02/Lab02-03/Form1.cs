using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_03
{
    public partial class Form1: Form
    {
        private const int GIA_VE = 80000;
        private const int MAX_GHE = 8;

        private List<Button> gheDangChon = new List<Button>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TaoSoDoGhe();

            if (cboPhim.Items.Count > 0)
                cboPhim.SelectedIndex = 0;
        }

        private void TaoSoDoGhe()
        {
            panelSoDoGhe.Controls.Clear();

            int kichThuoc = 45;
            int khoangCach = 5;

            for (int hang = 0; hang < 5; hang++)
            {
                for (int cot = 0; cot < 8; cot++)
                {
                    Button btn = new Button();

                    btn.Width = kichThuoc;
                    btn.Height = kichThuoc;

                    btn.Left = cot * (kichThuoc + khoangCach);
                    btn.Top = hang * (kichThuoc + khoangCach);

                    btn.Text = $"{(char)('A' + hang)}{cot + 1}";

                    btn.BackColor = Color.White;

                    btn.FlatStyle = FlatStyle.Flat;

                    btn.Tag = "Trong";

                    btn.Click += btnGhe_Click;

                    panelSoDoGhe.Controls.Add(btn);
                }
            }
        }

        private void btnGhe_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            string trangThai = btn.Tag.ToString();

            // Ghế đã bán
            if (trangThai == "DaBan")
            {
                MessageBox.Show("Ghế đã được đặt!");
                return;
            }

            // Ghế đang trống
            if (trangThai == "Trong")
            {
                // Giới hạn 8 ghế
                if (gheDangChon.Count >= MAX_GHE)
                {
                    MessageBox.Show("Chỉ được chọn tối đa 8 ghế!");
                    return;
                }

                btn.BackColor = Color.Gold;
                btn.Tag = "DangChon";

                gheDangChon.Add(btn);
            }
            else // Ghế đang chọn
            {
                btn.BackColor = Color.White;
                btn.Tag = "Trong";

                gheDangChon.Remove(btn);
            }

            CapNhatThongTin();
        }

        private void CapNhatThongTin()
        {
            if (gheDangChon.Count == 0)
            {
                lblGheDaChon.Text = "";
                lblTongTien.Text = "0đ";
                return;
            }

            lblGheDaChon.Text =
                string.Join(", ", gheDangChon.Select(x => x.Text));

            lblTongTien.Text =
                (gheDangChon.Count * GIA_VE).ToString("N0") + "đ";
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (gheDangChon.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn ít nhất 1 ghế!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string danhSach = string.Join(", ", gheDangChon.Select(g => g.Text));
            int tongTien = gheDangChon.Count * GIA_VE;

            DialogResult ketQua = MessageBox.Show(
                $"Xác nhận đặt {gheDangChon.Count} ghế:\n{danhSach}\n\nTổng tiền: {tongTien:N0}đ",
                "Xác nhận đặt vé",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ketQua == DialogResult.Yes)
            {
                foreach (Button ghe in gheDangChon)
                {
                    ghe.BackColor = Color.IndianRed;
                    ghe.Tag = "DaBan";
                }

                gheDangChon.Clear();

                CapNhatThongTin();

                MessageBox.Show(
                    "Đặt vé thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnHuyChon_Click(object sender, EventArgs e)
        {
            foreach (Button ghe in gheDangChon)
            {
                ghe.BackColor = Color.White;
                ghe.Tag = "Trong";
            }

            gheDangChon.Clear();

            CapNhatThongTin();
        }

        private void cboPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Nếu không có ghế đang chọn thì reset luôn
            if (gheDangChon.Count == 0)
            {
                ResetSoDoGhe();
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn đang chọn ghế.\nĐổi phim sẽ mất lựa chọn.\nTiếp tục?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                ResetSoDoGhe();
            }
        }

        private void ResetSoDoGhe()
        {
            foreach (Control control in panelSoDoGhe.Controls)
            {
                if (control is Button btn)
                {
                    btn.BackColor = Color.White;
                    btn.Tag = "Trong";
                }
            }

            gheDangChon.Clear();

            CapNhatThongTin();
        }
    }
}
