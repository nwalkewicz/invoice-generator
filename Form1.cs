using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Text.RegularExpressions;

namespace invoice_generator
{
    public partial class form : Form
    {
        public form()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            InitializeComponent();
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
                        // Unit Cost
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

                    // Get unit cost
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
                string? strRowTotal = dataGridView[3, i]?.Value?.ToString();
                if (strRowTotal == null) break;
                //label_total.Text = strRowTotal.ToString();
                string? strFormattedRowTotal = Regex.Match(strRowTotal, @"(\d+(\.\d+)?)|(\.\d+)")?.ToString();
                if (strFormattedRowTotal == null) break;
                if (!decimal.TryParse(strFormattedRowTotal, out decimal decRowTotal)) break;

                decGrandTotal += decRowTotal;
            }

            label_total_value.Text = decGrandTotal.ToString("$0.00");
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "invoice.pdf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                savePdf(saveFileDialog.FileName);
            }
        }

        private void savePdf(string filename)
        {
            int MARGIN = 12;
            int TITLE_SIZE = 36;
            int SUBTITLE_SIZE = 36;
            int GAP = 8;
            bool CENTERED = checkBox_centered.Checked;

            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Draw title
            XFont font_title = new("Inter", TITLE_SIZE, XFontStyle.Regular);
            gfx.DrawString(
                "Almanor Computers",
                font_title,
                XBrushes.Black,
                new XRect(
                    CENTERED ? 0 : MARGIN, MARGIN,
                    page.Width, page.Height - MARGIN
                ),
                CENTERED ? XStringFormats.TopCenter : XStringFormats.TopLeft
            );

            // Draw subtitle
            XFont font_subtitle = new("Inter", SUBTITLE_SIZE, XFontStyle.Bold);
            gfx.DrawString(
                "INVOICE",
                font_subtitle,
                XBrushes.DarkGray,
                new XRect(
                    CENTERED ? 0 : MARGIN, MARGIN + GAP + TITLE_SIZE,
                    page.Width, page.Height - (MARGIN + GAP + TITLE_SIZE)
                ),
                CENTERED ? XStringFormats.TopCenter : XStringFormats.TopLeft
            );

            document.Save(filename);
        }
    }
}