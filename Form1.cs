using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Text.RegularExpressions;
using PdfSharp.Fonts;

namespace invoice_generator
{
    public partial class form : Form
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                savePdf();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private string FONT_FAMILY = "JetBrains Mono NL";
        private decimal GRAND_TOTAL = 0;

        public form()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            InitializeComponent();

            GlobalFontSettings.FontResolver = new JBFontResolver();
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 1:
                    {
                        // Quantity
                        string? strVal = e.Value?.ToString();
                        if (strVal == null) return;

                        // Apply formatting
                        if (!decimal.TryParse(strVal, out decimal decVal)) return;
                        e.Value = decVal.ToString("0.##");

                        e.FormattingApplied = true;
                        break;
                    }

                case 2:
                    {
                        // Rate
                        string? strVal = e.Value?.ToString();
                        if (strVal == null) return;

                        // Apply formatting
                        if (!decimal.TryParse(strVal, out decimal decVal)) return;
                        e.Value = decVal.ToString("$0.00");

                        e.FormattingApplied = true;
                        break;
                    }
            }
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView.RowCount)
                {
                    decimal decTotal;

                    // Get quantity
                    string? strQty = dataGridView[1, e.RowIndex]?.Value?.ToString();
                    if (strQty == null) return;
                    if (!decimal.TryParse(strQty, out decimal decQty)) return;

                    // Get rate
                    string? strUC = dataGridView[2, e.RowIndex]?.Value?.ToString();
                    if (strUC == null) return;
                    if (!decimal.TryParse(strUC, out decimal decUC)) return;

                    // Calculate total
                    decTotal = decQty * decUC;

                    // Format value
                    dataGridView[3, e.RowIndex].Value = decTotal.ToString("$0.00");

                    // Update grand total
                    updateGrandTotal();
                }
            }
        }

        private void dataGridView_UserDeletedRow(object sender, object e)
        {
            updateGrandTotal();
        }

        private void updateGrandTotal()
        {
            decimal decGrandTotal = 0;

            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                if (dataGridView.Rows[i].IsNewRow) { continue; }

                string? strRowAmount = dataGridView[3, i]?.Value?.ToString();
                if (strRowAmount == null) continue;

                string? strFormattedRowAmount = Regex.Match(strRowAmount, @"(\d+(\.\d+)?)|(\.\d+)")?.ToString();
                if (strFormattedRowAmount == null) continue;

                if (!decimal.TryParse(strFormattedRowAmount, out decimal decRowTotal)) continue;

                decGrandTotal += decRowTotal;
            }

            GRAND_TOTAL = decGrandTotal;
            label_total.Text = "Total: " + string.Format("${0:#,##0.00}", GRAND_TOTAL);
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            savePdf();
        }

        private void savePdf()
        {
            saveFileDialog.FileName = "invoice.pdf";
            saveFileDialog.Filter = "PDF Document|*.pdf";
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            string filename = saveFileDialog.FileName;

            string FROM = input_from.Text;
            string ID = input_id.Text != string.Empty ? "#" + input_id.Text : string.Empty;
            string TO = input_to.Text;

            int MARGIN_X = 36;
            int MARGIN_Y = 24;
            int CONTENT_INSET = 12;
            int GAP = 36;
            int TOTAL_GAP = 48;

            int TITLE_SIZE = 28;
            int BODY1_SIZE = 10;
            int BODY2_SIZE = 12;

            int QTY_WIDTH = 64;
            int RATE_WIDTH = 72;
            int AMOUNT_WIDTH = 96;
            int TABLE_HEADER_HEIGHT = BODY1_SIZE + 12;
            int TABLE_ROW_HEIGHT = BODY1_SIZE + 8;

            XBrush grayBrush = new XSolidBrush(XColor.FromArgb(119, 119, 119));
            XBrush lightGrayBrush = new XSolidBrush(XColor.FromArgb(240, 240, 240));
            XBrush darkGrayBrush = new XSolidBrush(XColor.FromArgb(50, 50, 50));

            PdfDocument document = new();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font_title = new(FONT_FAMILY, TITLE_SIZE, XFontStyle.Regular);
            XFont font_body1_regular = new(FONT_FAMILY, BODY1_SIZE, XFontStyle.Regular);
            XFont font_body2_regular = new(FONT_FAMILY, BODY2_SIZE, XFontStyle.Regular);
            XFont font_body1_bold = new(FONT_FAMILY, BODY1_SIZE, XFontStyle.Bold);
            XFont font_body2_bold = new(FONT_FAMILY, BODY2_SIZE, XFontStyle.Bold);

            // Draw FROM
            int FROM_OFFSETX = MARGIN_X + CONTENT_INSET;
            gfx.DrawString(
                FROM,
                font_body2_regular,
                XBrushes.Black,
                new XRect(
                    FROM_OFFSETX, MARGIN_Y,
                    page.Width - FROM_OFFSETX * 2, page.Height - MARGIN_Y * 2
                ),
                XStringFormats.TopLeft
            );

            // Draw title
            gfx.DrawString(
                "INVOICE",
                font_title,
                XBrushes.Black,
                new XRect(
                    MARGIN_X, MARGIN_Y,
                    page.Width - MARGIN_X * 2, page.Height - MARGIN_X * 2
                ),
                XStringFormats.TopRight
            );

            // Draw ID
            int ID_OFFSETX = MARGIN_X;
            int ID_OFFSETY = MARGIN_Y + TITLE_SIZE + 8;
            gfx.DrawString(
                ID,
                font_body1_regular,
                grayBrush,
                new XRect(
                    ID_OFFSETX, ID_OFFSETY,
                    page.Width - ID_OFFSETX * 2, page.Height - ID_OFFSETY * 2
                ),
                XStringFormats.TopRight
            );

            // Draw DATE label
            double DATE_LABEL_OFFSETX = page.Width / 2;
            int DATE_LABEL_OFFSETY = ID_OFFSETY + BODY2_SIZE + GAP;
            gfx.DrawString(
                "Date:",
                font_body1_regular,
                grayBrush,
                new XRect(
                    DATE_LABEL_OFFSETX, DATE_LABEL_OFFSETY,
                    (page.Width / 2 - MARGIN_X) / 2, page.Height - DATE_LABEL_OFFSETY * 2
                ),
                XStringFormats.TopRight
            );

            // Draw DATE
            string date = input_date.Value.ToString("MMM d, yyyy");
            int DATE_OFFSETX = MARGIN_X + CONTENT_INSET;
            int DATE_OFFSETY = DATE_LABEL_OFFSETY;
            gfx.DrawString(
                date,
                font_body1_regular,
                XBrushes.Black,
                new XRect(
                    DATE_OFFSETX, DATE_OFFSETY,
                    page.Width - DATE_OFFSETX * 2, page.Height - DATE_OFFSETY * 2
                ),
                XStringFormats.TopRight
            );

            // Draw BALDUE background
            int BALDUE_BG_OFFSETY = DATE_OFFSETY + BODY1_SIZE + 8;
            gfx.DrawRoundedRectangle(
                lightGrayBrush,
                page.Width / 2, BALDUE_BG_OFFSETY,
                page.Width / 2 - MARGIN_X, BODY2_SIZE + 16,
                4, 4
            );

            // Draw BALDUE label
            double BALDUE_LABEL_OFFSETX = page.Width / 2;
            int BALDUE_LABEL_OFFSETY = BALDUE_BG_OFFSETY + 6;
            gfx.DrawString(
                "Balance Due:",
                font_body2_bold,
                XBrushes.Black,
                new XRect(
                    BALDUE_LABEL_OFFSETX, BALDUE_LABEL_OFFSETY,
                    (page.Width / 2 - MARGIN_X) / 2, page.Height - BALDUE_LABEL_OFFSETY * 2
                ),
                XStringFormats.TopRight
            );

            // Draw BALDUE
            int BALDUE_OFFSETX = MARGIN_X + CONTENT_INSET;
            int BALDUE_OFFSETY = BALDUE_LABEL_OFFSETY;
            gfx.DrawString(
                string.Format("${0:#,##0.00}", GRAND_TOTAL),
                font_body2_bold,
                XBrushes.Black,
                new XRect(
                    BALDUE_OFFSETX, BALDUE_OFFSETY,
                    page.Width - BALDUE_OFFSETX * 2, page.Height - BALDUE_OFFSETY * 2
                ),
                XStringFormats.TopRight
            );

            // Draw TO label
            int BILLTO_LABEL_OFFSETX = MARGIN_X + CONTENT_INSET;
            int BILLTO_LABEL_OFFSETY = MARGIN_Y;
            gfx.DrawString(
                "Bill To:",
                font_body1_regular,
                grayBrush,
                new XRect(
                    BILLTO_LABEL_OFFSETX, BILLTO_LABEL_OFFSETY,
                    page.Width - BILLTO_LABEL_OFFSETX * 2, BALDUE_BG_OFFSETY + (BODY2_SIZE + 16) - BODY1_SIZE * 3 - 8
                ),
                XStringFormats.BottomLeft
            );

            // Draw TO
            int TO_OFFSETX = MARGIN_X + CONTENT_INSET;
            int TO_OFFSETY = MARGIN_Y;
            gfx.DrawString(
                TO,
                font_body1_regular,
                XBrushes.Black,
                new XRect(
                    TO_OFFSETX, TO_OFFSETY,
                    page.Width - TO_OFFSETX * 2, BALDUE_BG_OFFSETY + (BODY2_SIZE + 16) - BODY1_SIZE * 2 - 4
                ),
                XStringFormats.BottomLeft
            );

            // Draw table background
            int TABLEHEADER_BG_OFFSETX = MARGIN_X;
            int TABLEHEADER_BG_OFFSETY = BALDUE_BG_OFFSETY + BODY2_SIZE + 16 + GAP;
            gfx.DrawRoundedRectangle(
                darkGrayBrush,
                TABLEHEADER_BG_OFFSETX, TABLEHEADER_BG_OFFSETY,
                page.Width - TABLEHEADER_BG_OFFSETX * 2, TABLE_HEADER_HEIGHT,
                4, 4
            );

            // Draw ITEM label
            int ITEM_OFFSETX = MARGIN_X + CONTENT_INSET;
            int ITEM_OFFSETY = TABLEHEADER_BG_OFFSETY + 6;
            double ITEM_WIDTH = page.Width - MARGIN_X * 2 - CONTENT_INSET * 2 - QTY_WIDTH - RATE_WIDTH - AMOUNT_WIDTH;
            gfx.DrawString(
                "Item",
                font_body1_bold,
                XBrushes.White,
                new XRect(
                    ITEM_OFFSETX, ITEM_OFFSETY,
                    ITEM_WIDTH, BODY1_SIZE
                ),
                XStringFormats.CenterLeft
            );

            // Draw QTY label
            double QTY_LABEL_OFFSETX = MARGIN_X + CONTENT_INSET + ITEM_WIDTH;
            int QTY_LABEL_OFFSETY = TABLEHEADER_BG_OFFSETY + 6;
            gfx.DrawString(
                "Quantity",
                font_body1_bold,
                XBrushes.White,
                new XRect(
                    QTY_LABEL_OFFSETX, QTY_LABEL_OFFSETY,
                    QTY_WIDTH, BODY1_SIZE
                ),
                XStringFormats.CenterLeft
            );

            // Draw RATE label
            double RATE_LABEL_OFFSETX = MARGIN_X + CONTENT_INSET + ITEM_WIDTH + QTY_WIDTH;
            int RATE_LABEL_OFFSETY = TABLEHEADER_BG_OFFSETY + 6;
            gfx.DrawString(
                "Rate",
                font_body1_bold,
                XBrushes.White,
                new XRect(
                    RATE_LABEL_OFFSETX, RATE_LABEL_OFFSETY,
                    RATE_WIDTH, BODY1_SIZE
                ),
                XStringFormats.CenterRight
            );

            // Draw AMOUNT label
            double AMOUNT_LABEL_OFFSETX = MARGIN_X + CONTENT_INSET + ITEM_WIDTH + QTY_WIDTH + RATE_WIDTH;
            int AMOUNT_LABEL_OFFSETY = TABLEHEADER_BG_OFFSETY + 6;
            gfx.DrawString(
                "Amount",
                font_body1_bold,
                XBrushes.White,
                new XRect(
                    AMOUNT_LABEL_OFFSETX, AMOUNT_LABEL_OFFSETY,
                    AMOUNT_WIDTH, BODY1_SIZE
                ),
                XStringFormats.CenterRight
            );

            // Draw table rows
            double LAST_SAFE_PIXEL = page.Height - MARGIN_Y;
            double LAST_SAFE_ROW_START = LAST_SAFE_PIXEL - BODY1_SIZE - TOTAL_GAP - TABLE_ROW_HEIGHT;

            int LATEST_ROW_OFFSET = TABLEHEADER_BG_OFFSETY + TABLE_HEADER_HEIGHT;

            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                if (dataGridView.Rows[i].IsNewRow) { continue; }
                if (LATEST_ROW_OFFSET > LAST_SAFE_ROW_START)
                {
                    // Create new page
                    PdfPage nextPage = document.AddPage();
                    gfx = XGraphics.FromPdfPage(nextPage);

                    // Restart from top
                    LATEST_ROW_OFFSET = MARGIN_Y;
                }

                int TEXT_OFFSETY = LATEST_ROW_OFFSET + TABLE_ROW_HEIGHT / 2 - BODY1_SIZE / 2;

                // Get decimal cell values
                string _strRowRate = dataGridView[2, i]?.Value?.ToString() ?? "0";
                string _strCleanRowRate = (Regex.Match(_strRowRate, @"(\d+(\.\d+)?)|(\.\d+)")?.ToString()) ?? "0";
                if (!decimal.TryParse(_strCleanRowRate, out decimal rate)) rate = 0;

                string _strRowAmount = dataGridView[3, i]?.Value?.ToString() ?? "0";
                string _strCleanRowAmount = (Regex.Match(_strRowAmount, @"(\d+(\.\d+)?)|(\.\d+)")?.ToString()) ?? "0";
                if (!decimal.TryParse(_strCleanRowAmount, out decimal amount)) amount = 0;

                // Draw ITEM cell
                gfx.DrawString(
                    dataGridView[0, i]?.FormattedValue?.ToString() ?? string.Empty,
                    font_body1_bold,
                    XBrushes.Black,
                    new XRect(
                        ITEM_OFFSETX, TEXT_OFFSETY,
                        ITEM_WIDTH, BODY1_SIZE
                    ),
                    XStringFormats.CenterLeft
                );

                // Draw QTY cell
                gfx.DrawString(
                    dataGridView[1, i]?.FormattedValue?.ToString() ?? string.Empty,
                    font_body1_regular,
                    XBrushes.Black,
                    new XRect(
                        QTY_LABEL_OFFSETX, TEXT_OFFSETY,
                        ITEM_WIDTH, BODY1_SIZE
                    ),
                    XStringFormats.CenterLeft
                );

                // Draw RATE cell
                gfx.DrawString(
                    string.Format("${0:#,##0.00}", rate),
                    font_body1_regular,
                    XBrushes.Black,
                    new XRect(
                        RATE_LABEL_OFFSETX, TEXT_OFFSETY,
                        RATE_WIDTH, BODY1_SIZE
                    ),
                    XStringFormats.CenterRight
                );

                // Draw AMOUNT cell
                gfx.DrawString(
                    string.Format("${0:#,##0.00}", amount),
                    font_body1_regular,
                    XBrushes.Black,
                    new XRect(
                        AMOUNT_LABEL_OFFSETX, TEXT_OFFSETY,
                        AMOUNT_WIDTH, BODY1_SIZE
                    ),
                    XStringFormats.CenterRight
                );

                LATEST_ROW_OFFSET += TABLE_ROW_HEIGHT;
            }

            // Draw TOTAL label
            double TOTAL_LABEL_OFFSETX = page.Width / 2;
            int TOTAL_OFFSETY = LATEST_ROW_OFFSET + TOTAL_GAP;
            double TOTAL_LABEL_WIDTH = (page.Width / 2 - MARGIN_X) / 2;
            double TOTAL_LABEL_HEIGHT = BODY1_SIZE;
            gfx.DrawString(
                "Total:",
                font_body1_regular,
                grayBrush,
                new XRect(
                    TOTAL_LABEL_OFFSETX, TOTAL_OFFSETY,
                    TOTAL_LABEL_WIDTH, TOTAL_LABEL_HEIGHT
                ),
                XStringFormats.CenterRight
            );

            // Draw TOTAL
            double TOTAL_OFFSETX = TOTAL_LABEL_OFFSETX + TOTAL_LABEL_WIDTH;
            double TOTAL_WIDTH = page.Width - TOTAL_OFFSETX - MARGIN_X - CONTENT_INSET;
            double TOTAL_HEIGHT = BODY1_SIZE;
            gfx.DrawString(
                string.Format("${0:#,##0.00}", GRAND_TOTAL),
                font_body1_regular,
                XBrushes.Black,
                new XRect(
                    TOTAL_OFFSETX, TOTAL_OFFSETY,
                    TOTAL_WIDTH, TOTAL_HEIGHT
                ),
                XStringFormats.CenterRight
            );

            // Save document
            document.Save(filename);
        }

        private void button_font_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                FONT_FAMILY = fontDialog.Font.Name;
            }
        }
    }
}