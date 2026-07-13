namespace Lab02_05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int demCongViec = 1;

        private Panel TaoCard(string tenCongViec)
        {
            Panel card = new Panel();

            card.Width = 250;
            card.Height = 70;

            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;

            card.Margin = new Padding(5);

            Label lbl = new Label();

            lbl.Text = tenCongViec;
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleLeft;

            lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            card.Controls.Add(lbl);

            // Cho phép kéo
            card.MouseDown += Card_MouseDown;
            lbl.MouseDown += Card_MouseDown;

            return card;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            flpCanLam.Controls.Add(TaoCard("Thiết kế giao diện"));
            flpCanLam.Controls.Add(TaoCard("Làm chức năng đăng nhập"));
            flpCanLam.Controls.Add(TaoCard("Viết báo cáo"));
            flpCanLam.AllowDrop = true;
            flpDangLam.AllowDrop = true;
            flpHoanThanh.AllowDrop = true;

            flpCanLam.DragEnter += FlowPanel_DragEnter;
            flpDangLam.DragEnter += FlowPanel_DragEnter;
            flpHoanThanh.DragEnter += FlowPanel_DragEnter;

            flpCanLam.DragDrop += FlowPanel_DragDrop;
            flpDangLam.DragDrop += FlowPanel_DragDrop;
            flpHoanThanh.DragDrop += FlowPanel_DragDrop;
        }

        private void FlowPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Panel)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void FlowPanel_DragDrop(object sender, DragEventArgs e)
        {
            Panel card = (Panel)e.Data.GetData(typeof(Panel));

            FlowLayoutPanel panelDich = (FlowLayoutPanel)sender;

            panelDich.Controls.Add(card);

            if (panelDich == flpCanLam)
            {
                card.BackColor = Color.White;
            }
            else if (panelDich == flpDangLam)
            {
                card.BackColor = Color.Khaki;
            }
            else if (panelDich == flpHoanThanh)
            {
                card.BackColor = Color.LightGreen;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTieuDe.Text))
            {
                MessageBox.Show("Nhập tên công việc!");
                txtTieuDe.Focus();
                return;
            }

            Panel card = TaoCard(txtTieuDe.Text);

            flpCanLam.Controls.Add(card);

            txtTieuDe.Clear();

            txtTieuDe.Focus();
        }

        private void Card_MouseDown(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;

            if (control.Parent is Panel)
            {
                DoDragDrop(control.Parent, DragDropEffects.Move);
            }
            else
            {
                DoDragDrop(control, DragDropEffects.Move);
            }
        }
    }
}
