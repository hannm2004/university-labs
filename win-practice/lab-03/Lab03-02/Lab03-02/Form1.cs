using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace Lab03_02
{
    public partial class Form1 : Form
    {
        // Theo dõi đường dẫn file hiện tại
        private string currentFilePath = null;
        // Đánh dấu văn bản mới chưa lưu
        private bool isNewFile = true;

        public Form1()
        {
            InitializeComponent();
            LoadFonts();
            LoadSizes();
            SetDefaults();
        }

        // ─────────────── Khởi tạo dữ liệu ───────────────

        /// <summary>Tải tất cả font chữ của hệ thống vào ComboBox Fonts</summary>
        private void LoadFonts()
        {
            using (InstalledFontCollection ifc = new InstalledFontCollection())
            {
                foreach (FontFamily font in ifc.Families)
                {
                    cmbFonts.Items.Add(font.Name);
                }
            }
        }

        /// <summary>Tải các kích thước cố định vào ComboBox Size</summary>
        private void LoadSizes()
        {
            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (int s in sizes)
                cmbSize.Items.Add(s);
        }

        /// <summary>Thiết lập giá trị mặc định ban đầu: Font Tahoma, Size 14</summary>
        private void SetDefaults()
        {
            cmbFonts.Text = "Tahoma";
            cmbSize.Text = "14";
            richText.Font = new Font("Tahoma", 14);
        }

        // ─────────────── Menu Hệ Thống ───────────────

        /// <summary>Tạo văn bản mới (Ctrl+N)</summary>
        private void taoVanBanMoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.Clear();
            currentFilePath = null;
            isNewFile = true;
            SetDefaults();
            this.Text = "Soạn thảo văn bản";
        }

        /// <summary>Mở tập tin (*.txt hoặc *.rtf)</summary>
        private void moTapTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text files (*.txt)|*.txt|RTF files (*.rtf)|*.rtf|All files (*.*)|*.*";
            dlg.Title = "Mở tập tin văn bản";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                richText.LoadFile(dlg.FileName,
                    dlg.FileName.EndsWith(".rtf", StringComparison.OrdinalIgnoreCase)
                        ? RichTextBoxStreamType.RichText
                        : RichTextBoxStreamType.PlainText);

                currentFilePath = dlg.FileName;
                isNewFile = false;
                this.Text = "Soạn thảo văn bản - " + Path.GetFileName(currentFilePath);
            }
        }

        /// <summary>Lưu nội dung văn bản (Ctrl+S)</summary>
        private void luuNoiDungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveContent();
        }

        /// <summary>Thoát ứng dụng</summary>
        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>Logic lưu file: nếu là file mới thì mở SaveDialog, ngược lại ghi đè</summary>
        private void SaveContent()
        {
            if (isNewFile || currentFilePath == null)
            {
                // Văn bản mới → mở hộp thoại lưu
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "RTF files (*.rtf)|*.rtf|Text files (*.txt)|*.txt";
                dlg.Title = "Lưu văn bản";
                dlg.DefaultExt = "rtf";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    richText.SaveFile(dlg.FileName,
                        dlg.FileName.EndsWith(".rtf", StringComparison.OrdinalIgnoreCase)
                            ? RichTextBoxStreamType.RichText
                            : RichTextBoxStreamType.PlainText);

                    currentFilePath = dlg.FileName;
                    isNewFile = false;
                    this.Text = "Soạn thảo văn bản - " + Path.GetFileName(currentFilePath);
                    MessageBox.Show("Lưu văn bản thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // File đã được mở trước đó → lưu trực tiếp
                richText.SaveFile(currentFilePath,
                    currentFilePath.EndsWith(".rtf", StringComparison.OrdinalIgnoreCase)
                        ? RichTextBoxStreamType.RichText
                        : RichTextBoxStreamType.PlainText);
                MessageBox.Show("Lưu văn bản thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ─────────────── Menu Định Dạng ───────────────

        /// <summary>Mở FontDialog để định dạng font cho vùng văn bản được chọn</summary>
        private void dinhDangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;

            // Áp dụng ngay khi click Apply
            fontDlg.Apply += (s, ev) =>
            {
                richText.SelectionColor = fontDlg.Color;
                richText.SelectionFont = fontDlg.Font;
            };

            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richText.SelectionColor = fontDlg.Color;
                richText.SelectionFont = fontDlg.Font;
            }
        }

        // ─────────────── ToolStrip: ComboBox Font & Size ───────────────

        private void cmbFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFontChange();
        }

        private void cmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFontChange();
        }

        /// <summary>Áp dụng font và size từ ComboBox lên vùng được chọn (hoặc toàn bộ nếu không chọn)</summary>
        private void ApplyFontChange()
        {
            if (cmbFonts.Text == "" || cmbSize.Text == "") return;
            if (!float.TryParse(cmbSize.Text, out float size)) return;

            try
            {
                Font newFont = new Font(cmbFonts.Text, size);
                if (richText.SelectionLength > 0)
                    richText.SelectionFont = newFont;
                else
                    richText.Font = newFont;
            }
            catch { }
        }

        // ─────────────── ToolStrip: Bold / Italic / Underline ───────────────

        /// <summary>Bật/tắt Bold cho vùng đang chọn</summary>
        private void btnBold_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Bold);
        }

        /// <summary>Bật/tắt Italic cho vùng đang chọn</summary>
        private void btnItalic_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Italic);
        }

        /// <summary>Bật/tắt Underline cho vùng đang chọn</summary>
        private void btnUnderline_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Underline);
        }

        /// <summary>Toggle một FontStyle: nếu đang có thì bỏ, nếu chưa có thì thêm</summary>
        private void ToggleFontStyle(FontStyle style)
        {
            if (richText.SelectionFont == null) return;

            Font currentFont = richText.SelectionFont;
            FontStyle newStyle;

            if (currentFont.Style.HasFlag(style))
                newStyle = currentFont.Style & ~style;   // bỏ style
            else
                newStyle = currentFont.Style | style;    // thêm style

            richText.SelectionFont = new Font(currentFont, newStyle);
        }

        // ─────────────── ToolStrip: Nút New / Open / Save ───────────────

        private void btnNew_Click(object sender, EventArgs e)
        {
            taoVanBanMoiToolStripMenuItem_Click(sender, e);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            moTapTinToolStripMenuItem_Click(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveContent();
        }

        // ─────────────── Phím tắt ───────────────

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.N))
            {
                taoVanBanMoiToolStripMenuItem_Click(null, null);
                return true;
            }
            if (keyData == (Keys.Control | Keys.S))
            {
                SaveContent();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
