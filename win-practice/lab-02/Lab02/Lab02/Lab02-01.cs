using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            try
            {
                float number1 = float.Parse(txtNhapA.Text);
                float number2 = float.Parse(txtNhapB.Text);
                float result = number1 + number2;
                txtKetQua.Text = result.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            try
            {
                float number1 = float.Parse(txtNhapA.Text);
                float number2 = float.Parse(txtNhapB.Text);
                float result = number1 - number2;
                txtKetQua.Text = result.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            try
            {
                float number1 = float.Parse(txtNhapA.Text);
                float number2 = float.Parse(txtNhapB.Text);
                float result = number1 * number2;
                txtKetQua.Text = result.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnChia_Click(object sender, EventArgs e)
        {
            try
            {
                float number1 = float.Parse(txtNhapA.Text);
                float number2 = float.Parse(txtNhapB.Text);
                float result = number1 / number2;
                txtKetQua.Text = result.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtNhapA_TextChanged(object sender, EventArgs e)
        {
            if(!checkNum(txtNhapA.Text))
                MessageBox.Show("Bạn vui lòng nhập đúng định dạng!", "Cảnh báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
        }

        private bool checkNum(string text)
        {
            bool temp = float.TryParse(text, out float KQ);
            if (!temp)
                return true;
            return false;
        }
    }
}
