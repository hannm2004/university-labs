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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int btnWidth = 50;
            int btnHeight = 40;
            int padding = 15;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int seatNumber = i * 5 + j + 1;
                    Button btnSeat = new Button();
                    btnSeat.Name = "btnSeat" + seatNumber;
                    btnSeat.Text = seatNumber.ToString();
                    btnSeat.Size = new Size(btnWidth, btnHeight);
                    btnSeat.BackColor = Color.White;
                    btnSeat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
                    btnSeat.Location = new Point(padding + j * (btnWidth + padding), padding + i * (btnHeight + padding));
                    btnSeat.Click += new EventHandler(btnChooseASeat);
                    grpSeats.Controls.Add(btnSeat);
                }
            }
        }

        private void btnChooseASeat(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            if (btn.BackColor == Color.White)
            {
                btn.BackColor = Color.Blue;
            }
            else if (btn.BackColor == Color.Blue)
            {
                btn.BackColor = Color.White;
            }
            else if (btn.BackColor == Color.Yellow)
            {
                MessageBox.Show("Ghế đã được bán!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            long totalAmount = 0;
            foreach (Control ctrl in grpSeats.Controls)
            {
                if (ctrl is Button)
                {
                    Button btn = (Button)ctrl;
                    if (btn.BackColor == Color.Blue)
                    {
                        int seatNumber = int.Parse(btn.Text);
                        int price = 0;

                        if (seatNumber >= 1 && seatNumber <= 5) price = 30000;
                        else if (seatNumber >= 6 && seatNumber <= 10) price = 40000;
                        else if (seatNumber >= 11 && seatNumber <= 15) price = 50000;
                        else if (seatNumber >= 16 && seatNumber <= 20) price = 80000;

                        totalAmount += price;
                        btn.BackColor = Color.Yellow;
                    }
                }
            }

            txtTotalAmount.Text = totalAmount.ToString("N0") + " VNĐ";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in grpSeats.Controls)
            {
                if (ctrl is Button)
                {
                    Button btn = (Button)ctrl;
                    if (btn.BackColor == Color.Blue)
                    {
                        btn.BackColor = Color.White;
                    }
                }
            }
            txtTotalAmount.Text = "0 VNĐ";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
